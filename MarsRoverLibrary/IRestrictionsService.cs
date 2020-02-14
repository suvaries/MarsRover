using System.Drawing;

namespace MarsRoverLibrary
{
    internal interface IRestrictionsService
    {
        bool OutsideTheBoundries(Point coordinates);
        bool PositionIsOccupied(Point coordinates);
        void OccupyCoordinates(Point coordinates);
    }
}
