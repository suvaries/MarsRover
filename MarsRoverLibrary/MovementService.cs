using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MarsRoverLibrary
{
    internal class MovementService : IMovementService
    {
        private readonly Dictionary<string, Size> _movementDictionary;
        private readonly Dictionary<string, string> _turnRightDictionary;
        private readonly Dictionary<string, string> _turnLeftDictionary;

        public MovementService()
        {
            _movementDictionary = new Dictionary<string, Size>
            {
                { "N", new Size(0, 1) },
                { "E", new Size(1, 0) },
                { "S", new Size(0, -1) },
                { "W", new Size(-1, 0) }
            };

            _turnRightDictionary = new Dictionary<string, string>
            {
                {"N", "E" },
                {"E", "S" },
                {"S", "W" },
                {"W", "N" },
            };

            _turnLeftDictionary =
                _turnRightDictionary
                .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        public Position Move(Position position, string instruction)
        {
            switch (instruction)
            {
                case "M":
                    return new Position
                    {
                        Coordinates = position.Coordinates + _movementDictionary[position.Orientation],
                        Orientation = position.Orientation
                    };
                case "R":
                    return new Position
                    {
                        Coordinates = position.Coordinates,
                        Orientation = _turnRightDictionary[position.Orientation]
                    };
                case "L":
                    return new Position
                    {
                        Coordinates = position.Coordinates,
                        Orientation = _turnLeftDictionary[position.Orientation]
                    };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
