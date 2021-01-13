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
            DrawGradient();
            DrawFractal();
        }

        private void Reset()
        {
            gradient = new Gradient(Color.FromArgb(0, 20, 0), Color.Yellow, Color.Black);
            gradient.ColorPoints.Add(new ColorPoint(Color.Red, 0.4, false));
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
            var steps = 500;

            var loops = new Linear(100, 300, steps).GetEnumerator();
            var minX = new Linear(-2.1, -0.741528684186793, steps).GetEnumerator();
            var minY = new Linear(-1.3, -0.186572693657556, steps).GetEnumerator();
            var maxX = new Linear(1, -0.741089987866163, steps).GetEnumerator();
            var maxY = new Linear(1.3, -0.186096669790823, steps).GetEnumerator();

            for (int n = 0; n < steps; n++)
            {
                loops.MoveNext();
                minX.MoveNext();
                minY.MoveNext();
                maxX.MoveNext();
                maxY.MoveNext();

                fractalControl.Area = new Area(new Coordinate(minX.Current, minY.Current), new Coordinate(maxX.Current, maxY.Current));
                LoopsTrackBar.Value = (int)loops.Current;

                var bitmap = fractalControl.GetBitmap(192, 108);
                bitmap.Save($"mandelbrot{n}.jpg", ImageFormat.Png);
            }

        }
    }
}
