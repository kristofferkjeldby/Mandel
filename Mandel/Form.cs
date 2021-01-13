namespace Mandel
{
    using Mandel.Colors;
    using Mandel.Colors.Models;
    using Mandel.Math;
    using Mandel.Extensions;
    using Mandel.Models;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Mandel.Math.Models;
    using Mandel.Fractal;

    public partial class Form : System.Windows.Forms.Form
    {
        private FractalControl fractalControl;
        private ISet set;
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
            gradient = new Gradient(Color.Blue, Color.Yellow);
            gradient.ColorPoints.Add(new ColorPoint(Color.Red, 0.4, false));
            gradientControl = new GradientControl(GradientPictureBox, gradient);
            fractalControl = new FractalControl(FractalPictureBox, set, LoopsTrackBar, gradient);

        }

        private void DrawGradient()
        {
            gradientControl.Draw();
        }

        private void DrawFractal()
        {
            fractalControl.Draw();
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
    }
}
