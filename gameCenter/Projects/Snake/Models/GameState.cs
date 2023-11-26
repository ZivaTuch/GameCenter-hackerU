using System;
using System.Collections.Generic;

namespace Snake
{
    public class GameState
    {
        public int Row { get; }
        public int Column { get; }
        public GridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }
        private readonly LinkedList<Direction> dirChanges = new LinkedList<Direction>();

        private readonly LinkedList<Position> snakePosition = new LinkedList<Position>();

        private readonly Random random = new Random();

        public GameState(int row, int col)
        {
            Row = row;
            Column= col;
            Grid = new GridValue[Row, Column];
            Dir = Direction.Right;

            AddSnake();
            AddFood();
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Colm] = GridValue.Food;
        }

        private void AddSnake()
        {
            int r = Row / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePosition.AddFirst(new Position(r, c));
            }
        }

        private IEnumerable<Position> EmptyPositions ()
        {
            for (int r = 0; r < Row; r++)
            {
                for (int c = 0; c< Column; c++)
                {
                    if (Grid[r, c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
                
            }
        }

        public Position HeadPosition()
        {
            return snakePosition.First.Value;
        }

        public Position TailPosition() { 
            return snakePosition.Last.Value;
        }


        public IEnumerable<Position> SnakePositions()
        {
            return snakePosition;
        }

        public void AddHead(Position pos)
        {
            snakePosition.AddFirst(pos);
            Grid[pos.Row, pos.Colm] = GridValue.Snake;
        }

        public void RemoveTail()
        {
            Position tail = snakePosition.Last.Value;
            Grid[tail.Row, tail.Colm] = GridValue.Empty;
            snakePosition.RemoveLast();
        }

        public void ChangeDirection(Direction dir)
        {
            if (CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);
            }
        }

        private bool CanChangeDirection(Direction newDir)
        {
            if (dirChanges.Count == 2)
            {
                return false;
            }

            Direction lastDir = GetLastDirection();
            return lastDir != newDir && newDir != lastDir.Opposite();
        }

        private Direction GetLastDirection()
        {
            if (dirChanges.Count == 0)
            {
                return Dir;
            }
            return dirChanges.Last.Value;
        }

        public bool OutsideGrid(Position pos)
        {
            return pos.Row < 0 || pos.Row >= Row || pos.Colm < 0|| pos.Colm >= Column;
        }

        public GridValue WillHit(Position newHeadPos)
        {
            if (OutsideGrid(newHeadPos))
            {
                return GridValue.Outside;
            }
            if (newHeadPos == TailPosition())
            {
                return GridValue.Empty;
            }

            return Grid[newHeadPos.Row, newHeadPos.Colm];   
        }

        public void Move()
        {
            if (dirChanges.Count > 0) 
            {
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();
            }

            Position newHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newHeadPos);

            if ( hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;
            }
             else if (hit ==  GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (hit == GridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
                AddFood();
            }
        }
    }
}
