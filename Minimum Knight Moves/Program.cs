using System;
using System.Collections.Generic;

namespace Minimum_Knight_Moves
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();

      int moves = p.MinimumKnightMoves(5, 5);
      Console.WriteLine(moves);
    }

    int MinimumKnightMoves(int x, int y)
    {
      x = Math.Abs(x);
      y = Math.Abs(y);

      int[] xMoves = new int[] { 1, 1, 2, 2, -1, -1, -2, -2 };
      int[] yMoves = new int[] { 2, -2, 1, -1, 2, -2, -1, 1 };
      int moves = 0;
      HashSet<(int, int)> visited = new HashSet<(int, int)>();
      Queue<(int, int)> q = new Queue<(int, int)>();
      q.Enqueue((0, 0));

      while (q.Count > 0)
      {
        int count = q.Count;
        while (count-- > 0)
        {
          var (xx, yy) = q.Dequeue();
          if (xx == x && yy == y) return moves;
          for (int j = 0; j < xMoves.Length; j++)
          {
            int newX = xx + xMoves[j];
            int newY = yy + yMoves[j];
            (int, int) xy = (newX, newY);
            // we are only checking for first half of the chess board where x and y cordinates are all positive
            if (!visited.Contains(xy) && newX >= 0 && newY >= 0)
            {
              q.Enqueue(xy);
              visited.Add(xy);
            }
          }
        }
        moves++;
      }

      return -1;
    }
  }
}
