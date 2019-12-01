using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class NQueenProblem
    {
        public static void Main()
        {
            Console.WriteLine("N Queen Problem");

            //var res = SolveNQueen(4);
            int N = 4;
            NQueenUtilAllSol(N, 0, new Position[N]);

            Console.ReadLine();
        }

        static Position[] SolveNQueen(int n)
        {
            Position[] positions = new Position[n];
            if (NQueenUtil(n, 0, positions))
            {
                return positions;
            }
            else return new Position[n];
        }

        static void PrintSolution(Position[] res)
        {
            foreach (var position in res)
            {
                //item.Print();
                for (int i = 0; i < res.Length; i++)
                {
                    if (position.Col == i)
                    {
                        Console.Write("Q");
                    }
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool NQueenUtil(int n, int row, Position[] positions)
        {
            if (n == row)
            {
                PrintSolution(positions);
                
                return true;
            }

            for (int col = 0; col < n; col++)
            {
                bool foundPosition = true;

                for (int q = 0; q < row; q++)
                {
                    if (positions[q].Col == col || positions[q].Col - positions[q].Row == col - row || positions[q].Col + positions[q].Row == col + row)
                    {
                        foundPosition = false;
                        break;
                    }
                }

                if (foundPosition)
                {
                    positions[row] = new Position(row, col);
                    if (NQueenUtil(n, row + 1, positions))
                    {
                        return true;
                    }
                    //row = row - 1;
                    positions[row] = new Position(0, 0);
                }
            }

            return false;
        }

        static void NQueenUtilAllSol(int n, int row, Position[] positions)
        {
            if (n == row)
            {
                PrintSolution(positions);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                bool foundPosition = true;

                for (int q = 0; q < row; q++)
                {
                    if (positions[q].Col == col || positions[q].Col - positions[q].Row == col - row || positions[q].Col + positions[q].Row == col + row)
                    {
                        foundPosition = false;
                        break;
                    }
                }

                if (foundPosition)
                {
                    positions[row] = new Position(row, col);
                    NQueenUtil(n, row + 1, positions);
                                        //row = row - 1;
                    positions[row] = new Position(0, 0);
                }
            }

        }
    }

    class Position
    {
        public int Row;
        public int Col;
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public void Print()
        {
            Console.WriteLine("({0}, {1})", Row, Col);
        }
    }
}
