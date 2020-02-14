using System.Drawing;

namespace MarsRoverLibrary
{
    internal class Position
    {
        public Point Coordinates { get; set; }
        public string Orientation { get; set; }

        public override string ToString()
        {
            return $"{Coordinates.X} {Coordinates.Y} {Orientation}";
        }
    }
}
