using System;

namespace _6_2_ex
{
    /// <summary>
    /// This class presents the game: labyrinth with character, operated by keys left, right, up and down;
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Inner class, which peresents game character;
        /// </summary>
        public class GameCharacter
        {
            /// <summary>
            /// The position of character on the game map;
            /// </summary>
            public (int y, int x) Position { get; set; }

            public GameCharacter((int y, int x) startPosition)
            {
                this.Position = startPosition;
            }
        }

        /// <summary>
        /// Inner class, which presents game map;
        /// </summary>
        public class GameMap
        {
            public GameCharacter Character { get; }
            public char[,] Map { get; }

            private MoveCursor moveCursor;

            public GameMap(string fileName, MoveCursor moveCursor)
            {
                this.moveCursor = moveCursor;

                var listMap = FileExtraFunctions.ReadMapFromFile(fileName);

                this.Map = FileExtraFunctions.MakeArrayFromList(listMap);

                this.Character = new GameCharacter(FindCharacter());
            }

            /// <summary>
            /// Finds character '@' on the map and throws exception if there is no '@';
            /// </summary>
            private (int y, int x) FindCharacter()
            {
                for (int i = 0; i < Map.GetLength(0); ++i)
                {
                    for (int j = 0; j < Map.GetLength(1); ++j)
                    {
                        if (Map[i, j] == '@')
                        {
                            return (i, j);
                        }
                    }
                }
                throw new NoCharacterException();
            }

            private bool IsCoordinatesCorrect(int y, int x) => (y < Map.GetLength(0)) && (x < Map.GetLength(1)) && (x * y >= 0);

            private bool IsStepCorrect(int y, int x) => IsCoordinatesCorrect(y, x) && (Map[y, x] == ' ');

            /// <summary>
            /// Replaces game character`s position on the map with given;
            /// </summary>
            public bool MoveCharacter(int dY, int dX)
            {
                (int y, int x) newPosition = (Character.Position.y + dY, Character.Position.x + dX);
                if (IsStepCorrect(newPosition.y, newPosition.x))
                {
                    Map[newPosition.y, newPosition.x] = '@';
                    Map[Character.Position.y, Character.Position.x] = ' ';
                    Character.Position = newPosition;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Prints the game map on the console;
            /// </summary>
            public void DrawMap()
            {
                Console.SetCursorPosition(0, 0);

                for (var i = 0; i < Map.GetLength(0); ++i)
                {
                    for (var j = 0; j < Map.GetLength(1); ++j)
                    {
                        Console.Write(Map[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// Prints the step of game character on the console;
            /// </summary>
            public void DrawStep((int y, int x) oldPosition, (int y, int x) newPosition)
            {
                if (moveCursor == null)
                {
                    return;
                }

                moveCursor(oldPosition.x, oldPosition.y);
                Console.Write(Map[oldPosition.y, oldPosition.x]);
                moveCursor(newPosition.x, newPosition.y);
                Console.Write(Map[newPosition.y, newPosition.x]);
                }
        }

        /// <summary>
        /// Inner class, which contains all events in game;
        /// </summary>
        private class GameEventHandler
        {
            public delegate bool GameMovingEvent();

            public event GameMovingEvent LeftHandler;
            public event GameMovingEvent RightHandler;
            public event GameMovingEvent UpHandler;
            public event GameMovingEvent DownHandler;

            public GameEventHandler(GameMovingEvent left, GameMovingEvent right, GameMovingEvent up, GameMovingEvent down)
            {
                LeftHandler += left;
                RightHandler += right;
                UpHandler += up;
                DownHandler += down;
            }

            /// <summary>
            /// Starts the observing of events (pressing on keys);
            /// </summary>
            public void Run()
            {
                while (true)
                {
                    var action = Console.ReadKey(true);
                    switch (action.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            LeftHandler();
                            break;
                        case ConsoleKey.RightArrow:
                            RightHandler();
                            break;
                        case ConsoleKey.UpArrow:
                            UpHandler();
                            break;
                        case ConsoleKey.DownArrow:
                            DownHandler();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        public delegate void MoveCursor(int x, int y);

        public GameMap Map { get; }
        private GameEventHandler eventObserver;

        public Game(string fileName, MoveCursor moveCursor)
        {
            Map = new GameMap(fileName, moveCursor);
        }

        private bool Move(int y, int x)
        {
            (int y, int x) oldPosition = Map.Character.Position;

            if (!Map.MoveCharacter(y, x))
            {
                return false;
            }

            (int y, int x) newPosition = Map.Character.Position;
            Map.DrawStep(oldPosition, newPosition);

            return true;
        }

        /// <summary>
        /// Moves game character left;
        /// </summary>
        public bool OnLeft() => Move(0, -1);

        /// <summary>
        /// Moves game characher right;
        /// </summary>
        public bool OnRight() => Move(0, 1);

        /// <summary>
        /// Moves game character up;
        /// </summary>
        public bool OnUp() => Move(-1, 0);

        /// <summary>
        /// Moves game character down;
        /// </summary>
        public bool OnDown() => Move(1, 0);

        /// <summary>
        /// Stars the game (draw the map and runs the observing of pressing keys);
        /// </summary>
        public void Start()
        {
            eventObserver = new GameEventHandler(OnLeft, OnRight, OnUp, OnDown);
            Map.DrawMap();
            eventObserver.Run();
        }
    }
}
