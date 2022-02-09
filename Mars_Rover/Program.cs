using System;

namespace Mars_Rover {
    class Program {
        static void Main(string[] args) {
            string[] fields = SetField();
            string[] firstRoverLocation = SetRoverLocation(fields);
            string firstRoverMoves = SetRoverMoves();
            string[] secondRoverLocation = SetRoverLocation(fields);
            string secondRoverMoves = SetRoverMoves();

            var firstRover = new Rover(Convert.ToInt32(firstRoverLocation[0]), Convert.ToInt32(firstRoverLocation[1]), (Direction)Enum.Parse(typeof(Direction), firstRoverLocation[2]));
            var secondRover = new Rover(Convert.ToInt32(secondRoverLocation[0]), Convert.ToInt32(secondRoverLocation[1]), (Direction)Enum.Parse(typeof(Direction), secondRoverLocation[2]));

            firstRover.MoveInstructions(firstRoverMoves, fields);
            Console.WriteLine(firstRover.GetFullPosition());

            secondRover.MoveInstructions(secondRoverMoves, fields);
            Console.WriteLine(secondRover.GetFullPosition());
        }

        private static string SetRoverMoves() {
            string roverMoves;
            bool isValidMove;
            do {
                Console.WriteLine("Write rover moves like LMLMLMLMM");
                roverMoves = Console.ReadLine();
                isValidMove = IsValidMove(roverMoves);
                if (!isValidMove) {
                    Console.WriteLine("Choose valid moves L(Left), R(Right), M(Move)");
                }
            } while (!isValidMove);
            return roverMoves;
        }

        private static string[] SetRoverLocation(string[] field) {
            string[] roverLocation;
            bool isValidPosition;
            do {
                Console.WriteLine("Write rover location like 1 2 N");
                roverLocation = Console.ReadLine().Split(' ');
                isValidPosition = IsValidPosition(field, roverLocation);
                if (!isValidPosition) {
                    Console.WriteLine("Choose the location from within the field");
                }
            } while (!isValidPosition);
            return roverLocation;
        }

        private static string[] SetField() {
            string[] field;
            bool isValidField;
            do {
                Console.WriteLine("Write field like 5 5");
                field = Console.ReadLine().Split(' ');
                isValidField = IsValidField(field);
                if (!isValidField) {
                    Console.WriteLine("Choose valid field");
                }
            } while (!isValidField);
            return field;
        }

        private static bool IsValidPosition(string[] field, string[] roverLocation) {
            if (roverLocation.Length != 3) {
                return false;
            }

            if (!int.TryParse(roverLocation[0], out int positionX) || !int.TryParse(roverLocation[1], out int positionY)) {
                return false;
            }

            if (roverLocation[2] != "N" && roverLocation[2] != "E" && roverLocation[2] != "S" && roverLocation[2] != "W") {
                return false;
            }

            if (positionX < 0 || positionX > Convert.ToInt32(field[0])) {
                return false;
            }
            if (positionY < 0 || positionY > Convert.ToInt32(field[1])) {
                return false;
            }

            return true;
        }

        private static bool IsValidMove(string moves) {
            foreach (var move in moves) {
                if (!(move.Equals('L') || move.Equals('R') || move.Equals('M'))) {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidField(string[] field) {
            if (field.Length != 2) {
                return false;
            }

            if (!int.TryParse(field[0], out int firstField) || !int.TryParse(field[1], out int secondField)) {
                return false;
            }

            if (firstField <= 0 || secondField <= 0) {
                return false;
            }

            return true;
        }
    }
}
