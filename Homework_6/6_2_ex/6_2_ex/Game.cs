using System;

namespace _6_2_ex
{
    /// <summary>
    /// This class presents the game: labytinth with character, operated by keys left, right, up and down;
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
            public (int x, int y) Position { get; set; }

            public GameCharacter((int x, int y) startPosition)
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
            public (int x, int y) FindCharacter()
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

            private bool IsCoordinatesCorrect(int x, int y) => (x < Map.GetLength(0)) && (y < Map.GetLength(1)) && (x * y >= 0);

            private bool IsStepCorrect(int x, int y) => IsCoordinatesCorrect(x, y) && (Map[x, y] == ' ');

            /// <summary>
            /// Replaces game character`s position on the map with given;
            /// </summary>
            public void MoveCharacter(int dX, int dY)
            {
                (int x, int y) newPosition = (Character.Position.x + dX, Character.Position.y + dY);
                if (IsCoordinatesCorrect(newPosition.x, newPosition.y) && IsStepCorrect(newPosition.x, newPosition.y))
                {
                    Map[newPosition.x, newPosition.y] = '@';
                    Map[Character.Position.x, Character.Position.y] = ' ';
                    Character.Position = newPosition;
                }
            }

            /// <summary>
            /// Prints the game map on the console;
            /// </summary>
            public void Draw()
            {
                Console.SetCursorPosition(0, 3);

                for (var i = 0; i < Map.GetLength(0); ++i)
                {
                    for (var j = 0; j < Map.GetLength(1); ++j)
                    {
                        Console.Write(Map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Inner class, which contains all events in game;
        /// </summary>
        private class GameEventHandler
        {
            public delegate void GameEvent();

            public event GameEvent LeftHandler;
            public event GameEvent RightHandler;
            public event GameEvent UpHandler;
            public event GameEvent DownHandler;
            public event GameEvent DrawHandler;

            public GameEventHandler(GameEvent left, GameEvent right, GameEvent up, GameEvent down, GameEvent draw)
            {
                LeftHandler += left;
                RightHandler += right;
                UpHandler += up;
                DownHandler += down;

                DrawHandler += draw;
                LeftHandler += draw;
                RightHandler += draw;
                UpHandler += draw;
                DownHandler += draw;
            }

            /// <summary>
            /// Starts the observing of events (pressing on keys);
            /// </summary>
            public void Run()
            {
                DrawHandler();

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

        /// <summary>
        /// Moves game character left;
        /// </summary>
        public void OnLeft()
        {
            map.MoveCharacter(0, -1);
        }

        /// <summary>
        /// Moves game characher right;
        /// </summary>
        public void OnRight()
        {
            map.MoveCharacter(0, 1);
        }

        /// <summary>
        /// Moves game character up;
        /// </summary>
        public void OnUp()
        {
            map.MoveCharacter(-1, 0);
        }

        /// <summary>
        /// Moves game character down;
        /// </summary>
        public void OnDown()
        {
            map.MoveCharacter(1, 0);
        }

        /// <summary>
        /// Stars the game (creates map with character on it and runs the observing of pressing keys);
        /// </summary>
        public void Start(string fileName)
        {
            map = new GameMap(fileName);
            eventObserver = new GameEventHandler(OnLeft, OnRight, OnUp, OnDown, map.Draw);
            eventObserver.Run();
        }
    }
}
