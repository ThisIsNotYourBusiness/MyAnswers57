using System;
using System.Collections.Generic;
using System.Text;

namespace _2048game
{
    class Game
    {
        public Board Board { get; private set; }
        public GameStatus Status { get; private set; }
        public int Points { get; protected set; }

        public Game()
        {
            Board = new Board();
            Status = GameStatus.Idle;
            Points = 0;
        }

        public void Move(Direction direction)
        {
            // is game lost
            if (Status == GameStatus.Lose)
                return;

            // move, add points
            Points += Board.Move(direction);

            foreach (Tile item in Board.Data)
                if (item != null && item.Value >= Tile.MAX_VALUE)
                {
                    Status = GameStatus.Win;
                }
            
            if (Board.IsLose())
                Status = GameStatus.Lose;
        }
    }
}
