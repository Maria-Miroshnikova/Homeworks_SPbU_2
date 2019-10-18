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
        private class GameCharacter
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
        private class GameMap
        {
            public GameCharacter Character { get; }
            public char[,] Map { get; }

            public GameMap(string fileName)
            {
                var listMap = FileExtraFunctions.ReadMapFromFile(fileName);

                this.Map = new char[listMap.Count, listMap[0].Length];

                for (int i = 0; i < listMap.Count; ++i)
                {
                    for (int j = 0; j < listMap[0].Length; ++j)
                    {
                        this.Map[i, j] = listMap[i][j];
                    }
                }

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
            public void MoveCharacter(int dY, int dX)
            {
                (int y, int x) newPosition = (Character.Position.y + dY, Character.Position.x + dX);
                if (IsStepCorrect(newPosition.y, newPosition.x))
                {
                    Map[newPosition.y, newPosition.x] = '@';
                    Map[Character.Position.y, Character.Position.x] = ' ';
                    Character.Position = newPosition;
                }
            }

            /// <summary>
            /// Prints the game map on the console;
            /// </summary>
            public void Draw()
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
                if ((oldPosition.x == newPosition.x) && (oldPosition.y == newPosition.y))
                {
                    return;
                }
                Console.SetCursorPosition(oldPosition.x, oldPosition.y);
                Console.Write(Map[oldPosition.y, oldPosition.x]);
                Console.SetCursorPosition(newPosition.x, newPosition.y);
                Console.Write(Map[newPosition.y, newPosition.x]);
            }
        }

        /// <summary>
        /// Inner class, which contains all events in game;
        /// </summary>
        private class GameEventHandler
        {
            public delegate void GameMovingEvent();

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
                    var action = Console.ReadKey();
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

        private GameMap map;
        private GameEventHandler eventObserver;

        private void Move(int y, int x)
        {
            (int y, int x) oldPosition = map.Character.Position;
            map.MoveCharacter(y, x);
            (int y, int x) newPosition = map.Character.Position;
            map.DrawStep(oldPosition, newPosition);
        }

        /// <summary>
        /// Moves game character left;
        /// </summary>
        public void OnLeft() => Move(0, -1);

        /// <summary>
        /// Moves game characher right;
        /// </summary>
        public void OnRight() => Move(0, 1);

        /// <summary>
        /// Moves game character up;
        /// </summary>
        public void OnUp() => Move(-1, 0);

        /// <summary>
        /// Moves game character down;
        /// </summary>
        public void OnDown() => Move(1, 0);

        /// <summary>
        /// Stars the game (creates map with character on it and runs the observing of pressing keys);
        /// </summary>
        public void Start(string fileName)
        {
            map = new GameMap(fileName);
            eventObserver = new GameEventHandler(OnLeft, OnRight, OnUp, OnDown);
            map.Draw();
            eventObserver.Run();
        }
    }
}
