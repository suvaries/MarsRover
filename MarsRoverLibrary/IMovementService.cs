namespace MarsRoverLibrary
{
    internal interface IMovementService
    {
        Position Move(Position position, string instruction);
    }
}
