using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRoverLibrary
{
    internal class RestrictionsService : IRestrictionsService
    {
        private readonly HashSet<Point> _occupiedCoordinates;

        private readonly int _northBoundry;
        private readonly int _southBoundry;
        private readonly int _westBoundry;
        private readonly int _eastBoundry;

        public RestrictionsService(Point firstCornerPoint, Point lastCornerPoint)
        {
            _occupiedCoordinates = new HashSet<Point>();

            _northBoundry = Math.Max(firstCornerPoint.Y, lastCornerPoint.Y);
            _southBoundry = Math.Min(firstCornerPoint.Y, lastCornerPoint.Y);
            _westBoundry = Math.Min(firstCornerPoint.X, lastCornerPoint.X);
            _eastBoundry = Math.Max(firstCornerPoint.X, lastCornerPoint.X);
        }

        public void OccupyCoordinates(Point coordinates)
        {
            _occupiedCoordinates.Add(coordinates);
        }

        public bool OutsideTheBoundries(Point coordinates)
        {
            if (coordinates.X > _eastBoundry)
            {
                return true;
            }

            if (coordinates.X < _westBoundry)
            {
                return true;
            }

            if (coordinates.Y > _northBoundry)
            {
                return true;
            }

            if (coordinates.Y < _southBoundry)
            {
                return true;
            }

            return false;
        }

        public bool PositionIsOccupied(Point coordinates)
        {
            return _occupiedCoordinates.Contains(coordinates);
        }
    }
}
