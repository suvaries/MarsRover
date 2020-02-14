using System.Drawing;

namespace MarsRoverLibrary
{
    internal interface IRestrictionsService
    {
        bool OursideTheBoundries(Point coordinates);
        bool PositionIsOccupied(Point coordinates);
        void OccupyCoordinates(Point coordinates);
    }
}
