using System;
using System.Collections.Generic;
using System.Text;

namespace _2048game
{

    class Board
    {
        // auto property, creates anonymous private field
        public Tile[,] Data { get; protected set; }

        private static Random random = new Random();

        // constructor
        public Board()
        {
            Data = new Tile[4, 4];
            RandomTiles();
        }


        private static Tile[][] GetArrayOfArrays(Tile[,] originalArray)
        {
            Tile[][] newArray = new Tile[originalArray.GetLength(0)][];

            for (int i = 0; i < originalArray.GetLength(0); i++)
            {
                newArray[i] = new Tile[originalArray.GetLength(1)];
                for (int j = 0; j < originalArray.GetLength(1); j++)
                {
                    newArray[i][j] = originalArray[i, j];
                }
            }

            return newArray;
        }

        // static method to clone and rotate a 2d clockwise
        protected static Tile[,] RotateClockwise(Tile[,] originalArray)
        {
            Tile[,] cloned = new Tile[4, 4];

            Tile[][] arrayOfArrays = GetArrayOfArrays(originalArray);

            int rows = originalArray.GetLength(0);
            int cols = originalArray.GetLength(1);

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Tile[] row = arrayOfArrays[rowIndex];
                Array.Reverse(row);

                for (int colIndex = 0; colIndex < cols; colIndex++)
                    cloned[cols - colIndex - 1, rows - rowIndex - 1] = row[colIndex];

            }

            return cloned;
        }

        private int CountFreeSpaces()
        {
            int count = 0;

            foreach (Tile tile in Data)
            {
                if (tile == null)
                    count++;
            }

            return count;
        }

        // create random tile with values 2 or 4
        private void RandomTile()
        {
            if (CountFreeSpaces() == 0)
                return;

            int randomRow, randomCol;
            int randomValue;

            randomRow = random.Next(0, 4);
            randomCol = random.Next(0, 4);

            while (Data[randomRow, randomCol] != null)
            {
                randomRow = random.Next(0, 4);
                randomCol = random.Next(0, 4);
            }

            // 0 -> tile value: 2
            // 1 -> tile value: 4
            randomValue = random.Next(0, 2);

            Data[randomRow, randomCol] = new Tile(randomValue == 0 ? 2 : 4);
        }
        // create two random tiles with values 2 or 4
        public void RandomTiles()
        {
            RandomTile();
            RandomTile();
        }

        // merge two tiles
        private Tile Merge(Tile tile1, Tile tile2)
        {
            // check if both tiles exist, otherwise throw expection
            if (tile1 == null || tile2 == null)
                throw new ArgumentNullException();

            int val = tile1.Value + tile2.Value;

            return val <= Tile.MAX_VALUE && tile1.Value == tile2.Value ? new Tile(val) : null;
        }
        
        // change to private
        public int MergeRight()
        {
            // move all tiles to the right
            MoveRight();
            int points = 0;

            Tile mergeResult;
            // get the rows
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                // get the columns
                for (int col = Data.GetLength(1) - 1; col > 0 ; col--)
                {
                    // init the mergeResult
                    mergeResult = null;

                    // check if current tile and tile to the left of it exist
                    if (Data[row, col] == null || Data[row, col - 1] == null)
                        continue;

                    // try merge
                    mergeResult = Merge(Data[row, col], Data[row, col - 1]);
                    
                    // if mergeResult is null it means the tiles aren't the same, so it should continue
                    if (mergeResult == null)
                        continue;

                    points += mergeResult.Value;

                    // otherwise apply merge
                    Data[row, col - 1] = null;
                    Data[row, col] = mergeResult;
                }
            }
            // move all to the right
            MoveRight();

            return points;
        }

        public void MoveRight()
        {
            int firstEmptyIndex;
            // get the rows
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                firstEmptyIndex = -1;

                // get the columns
                for (int col = Data.GetLength(1) - 1; col > 0; col--)
                {
                    if (Data[row, col] == null && firstEmptyIndex < col)
                        firstEmptyIndex = col;

                    if (firstEmptyIndex != -1 && Data[row, col - 1] != null)
                    {
                        Data[row, firstEmptyIndex] = Data[row, col - 1];
                        Data[row, col - 1] = null;
                        firstEmptyIndex = -1;
                    }
                }
            }
        }

        public bool IsLose()
        {
            Tile[,] cachedData = (Tile[,]) Data.Clone();
            int points = 0;

            var values = Enum.GetValues(typeof(Direction));

            foreach (Direction dir in values)
            {
                points += Move(dir);
                Data = (Tile[,]) cachedData.Clone();
            }

            Data = cachedData;

           
            return points == 0 && CountFreeSpaces() == 0; 
        }

        // move to direction, returns points
        public int Move(Direction direction)
        {
            int points = 0;
            switch (direction)
            {
                case Direction.Right:
                    points += MergeRight();
                    break;

                case Direction.Up:
                    Data = RotateClockwise(Data);
                    points += MergeRight();
                    Data = RotateClockwise(Data);
                    Data = RotateClockwise(Data);
                    Data = RotateClockwise(Data);
                    break;

                case Direction.Left:
                    Data = RotateClockwise(Data);
                    Data = RotateClockwise(Data);
                    points += MergeRight();
                    Data = RotateClockwise(Data);
                    Data = RotateClockwise(Data);
                    break;

                case Direction.Down:
                    Data = RotateClockwise(Data);
                    Data = RotateClockwise(Data);
                    Data = RotateClockwise(Data);
                    points += MergeRight();
                    Data = RotateClockwise(Data);
                    break;
            }

            RandomTile();

            return points;
        }

    }
}
