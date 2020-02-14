using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRoverLibrary
{
    internal class RestrictionsService : IRestrictionsService
    {
        private readonly HashSet<Point> _occupiedCoordinates;

        private readonly Rectangle _rectangle;

        public RestrictionsService(Point firstCornerPoint, Point lastCornerPoint)
        {
            _occupiedCoordinates = new HashSet<Point>();

            var x = Math.Min(firstCornerPoint.X, lastCornerPoint.X);
            var y = Math.Max(firstCornerPoint.Y, lastCornerPoint.Y);
            var width = Math.Abs(firstCornerPoint.X - lastCornerPoint.X);
            var height = Math.Abs(firstCornerPoint.Y - lastCornerPoint.Y);
            _rectangle = new Rectangle(x, y, width, height);
        }

        public void OccupyCoordinates(Point coordinates)
        {
            _occupiedCoordinates.Add(coordinates);
        }

        public bool OursideTheBoundries(Point coordinates)
        {
            return !_rectangle.Contains(coordinates);
        }

        public bool PositionIsOccupied(Point coordinates)
        {
            return _occupiedCoordinates.Contains(coordinates);
        }
    }
}
