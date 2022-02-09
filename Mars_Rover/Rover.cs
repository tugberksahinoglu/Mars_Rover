using System;
using System.ComponentModel;

namespace Mars_Rover {
    internal class Rover {
        private int positionX { get; set; }

        private int positionY { get; set; }

        private Direction direction { get; set; }

        public Rover(int positionX, int positionY, Direction direction) {
            this.positionX = positionX;
            this.positionY = positionY;
            this.direction = direction;
        }

        private void Move(string[] fields) {
            switch (direction) {
                case Direction.N:
                    if (positionY + 1 > Convert.ToInt32(fields[0])) {
                        throw new Exception("Out of bounds");
                    }
                    positionY++;
                    break;
                case Direction.E:
                    if (positionX + 1 > Convert.ToInt32(fields[1])) {
                        throw new Exception("Out of bounds");
                    }
                    positionX++;
                    break;
                case Direction.S:
                    if (positionY - 1 < 0) {
                        throw new Exception("Out of bounds");
                    }
                    positionY--;
                    break;
                case Direction.W:
                    if (positionX - 1 < 0) {
                        throw new Exception("Out of bounds");
                    }
                    positionX--;
                    break;
            }
        }

        private void Turn(char side) {
            if (side.Equals('R')) {
                switch (direction) {
                    case Direction.N:
                        direction = Direction.E;
                        break;
                    case Direction.E:
                        direction = Direction.S;
                        break;
                    case Direction.S:
                        direction = Direction.W;
                        break;
                    case Direction.W:
                        direction = Direction.N;
                        break;
                }
            }
            else if (side.Equals('L')) {
                switch (direction) {
                    case Direction.N:
                        direction = Direction.W;
                        break;
                    case Direction.E:
                        direction = Direction.N;
                        break;
                    case Direction.S:
                        direction = Direction.E;
                        break;
                    case Direction.W:
                        direction = Direction.S;
                        break;
                }
            }
        }

        public void MoveInstructions(string instructions, string[] fields) {
            foreach (var instruction in instructions) {
                switch (instruction) {
                    case 'M':
                        Move(fields);
                        break;
                    case 'L':
                    case 'R':
                        Turn(instruction);
                        break;
                }
            }
        }

        public string GetFullPosition() {
            return $"{positionX} {positionY} {direction}";
        }
    }

    public enum Direction {
        [Description("North")]
        N,
        [Description("East")]
        E,
        [Description("South")]
        S,
        [Description("West")]
        W
    }
}
