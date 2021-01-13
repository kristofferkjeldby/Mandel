namespace Mandel.Fractal
{
    using Mandel.Colors.Models;
    using Mandel.Extensions;
    using Mandel.Math.Models;
    using Mandel.Models;
    using System.Linq;
    using System.Drawing;
    using System.Windows.Forms;


    public class FractalControl
    {
        private Area zoomedArea;
        private Area zoomedPictureBoxArea;
        private Area selectionArea;
        private Brush selectionBrush;
        private Coordinate selectionStart;

        public PictureBox PictureBox { get; set; }

        public ISet Set { get; set; }

        public TrackBar LoopsTrackBar { get; set; }

        public Gradient Gradient { get; set; }

        public FractalControl(PictureBox pictureBox, ISet set, TrackBar loopsTrackBar, Gradient gradient)
        {
            PictureBox = pictureBox;
            Set = set;
            LoopsTrackBar = loopsTrackBar;
            Gradient = gradient;

            // Setup selection
            selectionArea = new Area();
            selectionStart = new Coordinate();
            selectionBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255));

            // Setup zoom
            zoomedArea = new Area(Constants.Min, Constants.Max);
            zoomedPictureBoxArea = PictureBox.GetArea();
        }

        public void Draw()
        {
            var pictureBoxArea = PictureBox.GetArea();
            var values = new double?[PictureBox.Width, PictureBox.Height];

            double? minValue = null;
            double? maxValue = null;

            for (var y = 0; y < values.GetLength(1); y++)
            {
                for (var x = 0; x < values.GetLength(0); x++)
                {
                    var pictureCoordinate = new Coordinate(x, y);
                    var coordinate = pictureCoordinate.Transform(pictureBoxArea, zoomedArea);
                    var value = Set.GetValue(coordinate, LoopsTrackBar.Value); 

                    if (value.HasValue)
                    {
                        if (!maxValue.HasValue || value.Value > maxValue)
                            maxValue = value;

                        if (!minValue.HasValue || value.Value < minValue)
                            minValue = value;
                    }

                    values[x, y] = value;
                }
            }

            for (var y = 0; y < values.GetLength(1); y++)
            {
                for (var x = 0; x < values.GetLength(0); x++)
                {
                    var oldValue = values[x, y];

                    if (oldValue.HasValue)
                    {
                        values[x, y] = (oldValue - minValue) / (maxValue - minValue);
                    }
                }
            }

            Bitmap bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            var stepSize = zoomedArea.Size / pictureBoxArea.Size;

            for (var y = 0; y < values.GetLength(1); y++)
            {
                for (var x = 0; x < values.GetLength(0); x++)
                {
                    var pictureCoordinate = new Coordinate(x, y);
                    var coordinate = pictureCoordinate.Transform(pictureBoxArea, zoomedArea);
                    var value = values[x, y];
                    var color = Gradient.GetColor(value);
                    bitmap.SetPixel((int)pictureCoordinate.X, (int)pictureCoordinate.Y, color);
                }
            }

            zoomedPictureBoxArea = new Area(new Coordinate(0, 0), new Coordinate(bitmap.Width, bitmap.Height));

            PictureBox.Image = bitmap;
        }

        internal void StartSelection(Coordinate coordinate)
        {
            selectionStart = coordinate;
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

                zoomedArea = newZoomedPictureBoxArea.Transform(zoomedPictureBoxArea, zoomedArea);

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
