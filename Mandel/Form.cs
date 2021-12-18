namespace Mandel
{
    using Mandel.Colors;
    using Mandel.Colors.Models;
    using Mandel.Models;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Mandel.Fractal;
    using Mandel.Sets;
    using System.Drawing.Imaging;
    using Mandel.Generators;
    using Mandel.Extensions;

    public partial class Form : System.Windows.Forms.Form
    {
        private FractalControl fractalControl;
        private Mandelbrot set;
        private Gradient gradient;
        private GradientControl gradientControl;

        public Form()
        {
            InitializeComponent();
            set = new Mandelbrot();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Reset();
            fractalControl.Area = new Area(Constants.Min, Constants.Max);
            DrawGradient();
            DrawFractal();
        }

        private void Reset()
        {
            gradient = new Gradient(Color.DarkBlue, Color.Yellow, Color.Black);
            gradient.ColorPoints.Add(new ColorPoint(Color.Red, 0.3, false));
            gradientControl = new GradientControl(GradientPictureBox, gradient);
            fractalControl = new FractalControl(FractalPictureBox, set, LoopsTrackBar, gradient, LimitTextBox);

        }

        private void DrawGradient()
        {
            gradientControl.Draw();
        }

        private void DrawFractal()
        {
            fractalControl.Draw();
            StripStatusLabel.Text = $"Done: {DateTime.Now}, Loops {LoopsTrackBar.Value}, Area: {fractalControl.Area}";
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            DrawFractal();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
            DrawGradient();
            DrawFractal();
        }

        private void FractalPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            fractalControl.StartSelection(new Coordinate(e.Location));
            Invalidate();
        }

        private void FractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            fractalControl.SetSelection(new Coordinate(e.Location));

            FractalPictureBox.Invalidate();
        }

        private void FractalPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            fractalControl.EndSelection(new Coordinate(e.Location));
        }

        private void FractalPictureBox_Paint(object sender, PaintEventArgs e)
        {
            fractalControl.Paint(e);
        }

        private void GradientPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            gradientControl.Active = true;
        }

        private void GradientPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!gradientControl.Active)
                return;

            gradientControl.SetColor(new Coordinate(e.Location));
            gradientControl.Draw();
        }

        private void GradientPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            gradientControl.Active = false;
        }

        private void AnimateButton_Click(object sender, EventArgs e)
        {
            var steps = 2000;

            LoopsTrackBar.Maximum = 100000;

            var loops = new Linear(50, 10000, steps).GetEnumerator();
            var center = new Coordinate(-0.104892712882917, 0.927903647312639);
            var factor = 0.93;
            for (int n = 0; n < steps; n++)
            {
                loops.MoveNext();
                fractalControl.Area = fractalControl.Area.Resize(center, factor);
                LoopsTrackBar.Value = (int)loops.Current;
                var bitmap = fractalControl.GetBitmap(1920, 1080);

                var chars = steps.ToString().Length - n.ToString().Length;
                var prefix = new string('0', chars);

                bitmap.Save($"mandelbrot{prefix}{n}.jpg", ImageFormat.Png);
            }
        }
    }
}
