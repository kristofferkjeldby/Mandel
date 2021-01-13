namespace Mandel.Colors
{
    using Mandel.Colors.Models;
    using Mandel.Models;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class GradientControl
    {
        public PictureBox PictureBox { get; set; }
        public Gradient Gradient { get; set; }
        public bool Active { get; set; }

        public GradientControl(PictureBox pictureBox, Gradient gradient)
        {
            PictureBox = pictureBox;
            Gradient = gradient;
        }

        public void Draw()
        {
            var stepSize = 1f / PictureBox.Width;

            Bitmap bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);

            for (int x = 0; x < PictureBox.Width; x++)
            {
                var color = Gradient.GetColor(x * stepSize);

                for (int y = 0; y < PictureBox.Height; y++)
                {
                    bitmap.SetPixel(x, y, color);
                }
            }

            PictureBox.Image = bitmap;
        }

        public void SetColor(Coordinate coordinate)
        {
            var colorPoint = Gradient.ColorPoints.FirstOrDefault(c => !c.Locked);
            colorPoint.Value = (1f / PictureBox.Width) * coordinate.X;
        }
    }
}
