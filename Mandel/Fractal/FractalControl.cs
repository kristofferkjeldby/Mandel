namespace Mandel.Fractal
{
    using Mandel.Colors.Models;
    using Mandel.Extensions;
    using Mandel.Models;
    using System.Drawing;
    using System.Windows.Forms;


    public class FractalControl
    {
        private Area zoomedPictureBoxArea;
        private Area selectionArea;
        private Brush selectionBrush;
        private Coordinate selectionStart;

        public PictureBox PictureBox { get; set; }

        public ISet Set { get; set; }

        public TrackBar LoopsTrackBar { get; set; }

        public Gradient Gradient { get; set; }

        public TextBox LimitTextBox { get; set; }

        public Area Area { get; set; }

        public FractalControl(PictureBox pictureBox, ISet set, TrackBar loopsTrackBar, Gradient gradient, TextBox limitTextBox)
        {
            PictureBox = pictureBox;
            Set = set;
            LoopsTrackBar = loopsTrackBar;
            Gradient = gradient;
            LimitTextBox = limitTextBox;

            // Setup selection
            selectionArea = new Area();
            selectionStart = new Coordinate();
            selectionBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255));

            // Setup zoom
            Area = new Area(Constants.Min, Constants.Max);
            zoomedPictureBoxArea = PictureBox.GetArea();
        }

        public void Draw()
        {
            PictureBox.Image = GetBitmap(PictureBox.Width, PictureBox.Height);
            zoomedPictureBoxArea = new Area(new Coordinate(0, 0), new Coordinate(PictureBox.Image.Width, PictureBox.Image.Height));
        }

        internal void StartSelection(Coordinate coordinate)
        {
            selectionStart = coordinate;
        }

        public Bitmap GetBitmap(int width, int height)
        {
            var values = new double?[width, height];
            var area = new Area(new Coordinate(0, 0), new Coordinate(width, height));
            var limit = 2d;
            if (double.TryParse(LimitTextBox.Text, out var customLimit))
            {
                limit = customLimit;
            }

            for (var y = 0; y < values.GetLength(1); y++)
            {
                for (var x = 0; x < values.GetLength(0); x++)
                {
                    var pictureCoordinate = new Coordinate(x, y);
                    var c = pictureCoordinate.Transform(area, Area).ToComplex();
                    var value = Set.GetValue(c, LoopsTrackBar.Value, limit);
                    values[x, y] = value;
                }
            }

            if (Constants.Normalize)
                values.Normalize();

            Bitmap bitmap = new Bitmap(width, height);
            var stepSize = Area.Size / area.Size;

            for (var y = 0; y < values.GetLength(1); y++)
            {
                for (var x = 0; x < values.GetLength(0); x++)
                {
                    var pictureCoordinate = new Coordinate(x, y);
                    var coordinate = pictureCoordinate.Transform(area, Area);
                    var value = values[x, y];
                    var color = Gradient.GetColor(value);
                    bitmap.SetPixel((int)pictureCoordinate.X, (int)pictureCoordinate.Y, color);
                }
            }

            return bitmap;
        }

        public void SetSelection(Coordinate selectionEnd)
        {
            var pictureBoxArea = PictureBox.GetArea();

            selectionArea.Min = new Coordinate(
                System.Math.Min(selectionStart.X, selectionEnd.X),
                System.Math.Min(selectionStart.Y, selectionEnd.Y));
            selectionArea.Max = new Coordinate(
                System.Math.Max(selectionStart.X, selectionEnd.X),
                System.Math.Max(selectionStart.Y, selectionEnd.Y));

            if (selectionArea.Min.X < 0)
                selectionArea.Min.X = 0;

            if (selectionArea.Max.X > pictureBoxArea.Max.X)
                selectionArea.Max.X = pictureBoxArea.Max.X;

            if (selectionArea.Min.Y < 0)
                selectionArea.Min.Y = 0;

            if (selectionArea.Max.Y > pictureBoxArea.Max.Y)
                selectionArea.Max.Y = pictureBoxArea.Max.Y;
        }

        public void EndSelection(Coordinate coordinate)
        {
            if (selectionStart == null || !selectionArea.IsSet())
                return;

            var pictureBoxArea = PictureBox.GetArea();

            var newZoomedPictureBoxArea = selectionArea.Transform(pictureBoxArea, zoomedPictureBoxArea);
            var newZoomedPictureBoxRetangle = newZoomedPictureBoxArea.ToRectangle().GetValueOrDefault();

            if (newZoomedPictureBoxRetangle != null)
            {
                Image image = PictureBox.Image;
                Bitmap bitmap = new Bitmap(image);
                var zoomedBitmap = bitmap.Clone(newZoomedPictureBoxRetangle, image.PixelFormat);

                PictureBox.Image = bitmap.Clone(newZoomedPictureBoxRetangle, image.PixelFormat);
                image.Dispose();

                Area = newZoomedPictureBoxArea.Transform(zoomedPictureBoxArea, Area);

                zoomedPictureBoxArea = new Area(new Coordinate(0, 0), new Coordinate(zoomedBitmap.Width, zoomedBitmap.Height));


                selectionArea = new Area();
            }
        }

        public void Paint(PaintEventArgs e)
        {
            if (PictureBox.Image != null)
            {
                var selectionRetangle = selectionArea.ToRectangle().GetValueOrDefault();

                if (selectionRetangle != null)
                {
                    e.Graphics.FillRectangle(selectionBrush, selectionRetangle);
                }
            }
        }
    }
}
