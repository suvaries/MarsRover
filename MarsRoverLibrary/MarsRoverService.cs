namespace MarsRoverLibrary
{
    internal class MarsRoverService: IMarsRoverService
    {
        private readonly IMovementService _movementService;
        private readonly IRestrictionsService _restrictionsService;

        public MarsRoverService(IMovementService movementService, IRestrictionsService restrictionsService)
        {
            _movementService = movementService;
            _restrictionsService = restrictionsService;
        }

        public string DoInstructionsForRover(RoverParameter roverParameter)
        {
            var position = roverParameter.StartPosition;
            if (_restrictionsService.OursideTheBoundries(position.Coordinates))
            {
                return "Start coordinates are out of the boundries.";
            }

            if (_restrictionsService.PositionIsOccupied(position.Coordinates))
            {
                return "Start coordinates are occupied by a previous rover.";
            }

            foreach (var instruction in roverParameter.Instructions)
            {
                var newPosition = _movementService.Move(position, instruction);

                if (_restrictionsService.OursideTheBoundries(newPosition.Coordinates))
                {
                    _restrictionsService.OccupyCoordinates(position.Coordinates);
                    return $"{position} Going out of the boundries";
                }

                if (_restrictionsService.PositionIsOccupied(newPosition.Coordinates))
                {
                    _restrictionsService.OccupyCoordinates(position.Coordinates);
                    return $"{position} Going over an previously occupied coordinates";
                }

                position = newPosition;
            }

            _restrictionsService.OccupyCoordinates(position.Coordinates);
            return $"{position}";
        }
    }
}
