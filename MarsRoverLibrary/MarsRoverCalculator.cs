using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MarsRoverLibrary
{
    public static class MarsRoverCalculator
    {
        public static string Calculate(string input)
        {
            var parameters = getParameters(input);
            var movementService = new MovementService();
            var restrictionService = new RestrictionsService(new Point(0, 0), parameters.UpperRightCoordinates);
            IMarsRoverService marsRoverService = new MarsRoverService(movementService, restrictionService);
            var outputList = new List<string>();
            foreach (var item in parameters.RoverParameterList)
            {
                var output = marsRoverService.DoInstructionsForRover(item);
            }

            var retVal = string.Join(Environment.NewLine, outputList);
            return retVal;
        }

        private static InputParameters getParameters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Input is empty.");
            }

            var inputArray = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (inputArray .Length == 1)
            {
                throw new Exception("There is no rover parameters.");
            }

            if (inputArray.Length % 2 == 0)
            {
                throw new Exception("Incorrect number of parameters.");
            }


            Point upperRightCoordinates;

            var upperRightCoordinateArray = inputArray[0];

            try
            {
                var upperRightCoordinates_x_y = upperRightCoordinateArray.Split(' ');
                if (upperRightCoordinates_x_y.Length != 2)
                {
                    throw new Exception();
                }

                var x = Convert.ToInt32(upperRightCoordinates_x_y[0]);
                var y = Convert.ToInt32(upperRightCoordinates_x_y[1]);
                upperRightCoordinates = new Point(x, y);
            }
            catch (Exception)
            {
                throw new Exception("Incorrect syntax for Upper-right coordinates.");
            }

            var roverCount = (inputArray.Length - 1) / 2;
            var acceptableOrientations = new string[] { "N", "E", "S", "W" };
            var acceptableInstructions = new string[] { "R", "L", "M" };

            var roverParameterList = new List<RoverParameter>();

            for (int roverNo = 1; roverNo <= roverCount; roverNo++)
            {
                var index = 2 * roverNo - 1;

                try
                {
                    var firstLineParameter = inputArray[index];
                    var secondLineParameter = inputArray[index + 1];
                    var firstLineArray = firstLineParameter.Split(' ');
                    if (firstLineArray.Length != 3)
                    {
                        throw new Exception();
                    }

                    var x = Convert.ToInt32(firstLineArray[0]);
                    var y = Convert.ToInt32(firstLineArray[1]);
                    var orientation = firstLineArray[2].ToUpperInvariant();
                    if (!acceptableOrientations.Contains(orientation))
                    {
                        throw new Exception();
                    }

                    var secondLineArray = secondLineParameter.Replace(" ", "").ToUpperInvariant().Split(new string[] { "" }, StringSplitOptions.RemoveEmptyEntries);
                    if (secondLineArray.Any(i=> !acceptableInstructions.Contains(i)))
                    {
                        throw new Exception();
                    }

                    RoverParameter roverParameter = new RoverParameter
                    {
                        StartPosition = new Position
                        {
                            Coordinates = new Point(x, y),
                            Orientation = orientation
                        },
                        Instructions = secondLineArray.ToList()
                    };

                    roverParameterList.Add(roverParameter);
                }
                catch (Exception)
                {
                    var errorMessage = $"Syntax error in rover parameters: RoverNo={roverNo}";
                    throw new Exception(errorMessage);
                }
            }

            return new InputParameters
            {
                UpperRightCoordinates = upperRightCoordinates,
                RoverParameterList = roverParameterList
            };
        }
    }
}
