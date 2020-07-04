using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class Sudoku
    {
        public void Test()
        {
            int[][] board = new int[9][]
            {
                new int[] {5,3,0,0,7,0,0,0,0},
                new int[] {6,0,0,1,9,5,0,0,0},
                new int[] {0,9,8,0,0,0,0,6,0},
                new int[] {8,0,0,0,6,0,0,0,3},
                new int[] {4,0,0,8,0,3,0,0,1},
                new int[] {7,0,0,0,2,0,0,0,6},
                new int[] {0,6,0,0,0,0,2,8,0},
                new int[] {0,0,0,4,1,9,0,0,5},
                new int[] {0,0,0,0,8,0,0,7,9}
            };

            int[][] solution = new int[9][]
            {
                new int[] {5,3,4,6,7,8,9,1,2},
                new int[] {6,7,2,1,9,5,3,4,8},
                new int[] {1,9,8,3,4,2,5,6,7},
                new int[] {8,5,9,7,6,1,4,2,3},
                new int[] {4,2,6,8,5,3,7,9,1},
                new int[] {7,1,3,9,2,4,8,5,6},
                new int[] {9,6,1,5,3,7,2,8,4},
                new int[] {2,8,7,4,1,9,6,3,5},
                new int[] {3,4,5,2,8,6,1,7,9}
            };
            Sudoku sudoku = new Sudoku();
            sudoku.SolveSudoku(board);
            Console.ReadLine();
        }

        internal enum Result
        {
            Solved,
            Incomplete,
            RequireGuessing,
            NoSolution
        }

        HashSet<int> _uniqueValues = new HashSet<int>();

        public void SolveSudoku(int[][] board)
        {
            //_board = board;

            SolveBoard(board);
            Print(board);
        }

        private Result SolveBoard(int[][] board)
        {
            Result boardState;
            do
            {
                boardState = MakeTurn(board);
            } while (boardState == Result.Incomplete);

            if(boardState == Result.Solved || boardState == Result.NoSolution)
            {
                return boardState;
            }

            IEnumerable<int[][]> candidateBoards = FindCandidateBoards(board);
            foreach (int[][] candidateBoard in candidateBoards)
            {
                Console.WriteLine("Before:");
                Print(candidateBoard);
                Result candidateBoardState = SolveBoard(candidateBoard);
                if (candidateBoardState == Result.Solved)
                {
                    CopyBoard(board, candidateBoard);
                    return Result.Solved;
                }

                Console.WriteLine("After:");
                Print(candidateBoard);
                //if (candidateBoardState == Result.NoSolution)
                //{
                //    return Result.NoSolution;
                //}
            }

            return Result.NoSolution;
        }

        private void CopyBoard(int[][] board, int[][] candidateBoard)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i][j] = candidateBoard[i][j];
                }
            }
        }

        private IEnumerable<int[][]> FindCandidateBoards(int[][] currentBoard)
        {
            IList<int[][]> boards = new List<int[][]>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (currentBoard[i][j] != 0) continue;

                    IList<int> candidates = FindCandidates(currentBoard, i, j);
                    if (candidates.Count > 1)
                    {
                        foreach (int candidate in candidates)
                        {
                            int[][] newBoard = CloneBoard(currentBoard);
                            newBoard[i][j] = candidate;
                            boards.Add(newBoard);

                            Console.WriteLine($"Candidate value [{i}][{j}] = {candidate}");
                            //Print(newBoard);
                        }
                        return boards;
                    }
                }
            }

            return boards;
        }

        private static int[][] CloneBoard(int[][] currentBoard)
        {
            var newBoard = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                newBoard[i] = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    newBoard[i][j] = currentBoard[i][j];
                }
            }

            return newBoard;
        }

        private Result MakeTurn(int[][] board)
        {
            bool containsDots = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != 0) continue;

                    var candidates = FindCandidates(board, i, j);
                    if (!candidates.Any())
                    {
                        //Console.WriteLine("board[" + i + "][" + j + "] = " + board[i][j]);
                        //Print(board);
                        return Result.NoSolution;
                    }

                    if (candidates.Count == 1)
                    {
                        board[i][j] = candidates[0];
                        //Console.WriteLine("board[" + i + "][" + j + "] = " + board[i][j]);
                        return Result.Incomplete;
                    }
                    containsDots = true;
                }
            }

            return containsDots ? Result.RequireGuessing : Result.Solved;
        }

        private IList<int> FindCandidates(int[][] board, int x, int y)
        {
            var candidates = new List<int>();
            for (int n = 1; n <= 9; n++)
            {
                if (IsValidCandidateNumber(board, n, x, y))
                {
                    candidates.Add(n);
                }
            }

            return candidates;
        }

        private bool IsValidCandidateNumber(int[][] board, int n, int x, int y)
        {
            board[x][y] = n;
            bool isValid = IsValid(board, x, y);

            board[x][y] = 0;
            return isValid;
        }

        private bool IsValid(int[][] board, int x, int y)
        {
            //validate row
            _uniqueValues.Clear();
            for (int j = 0; j < 9; j++)
            {
                if (board[x][j] == 0) continue;
                if (!_uniqueValues.Add(board[x][j]))
                {
                    return false;
                }
            }

            //validate column
            _uniqueValues.Clear();
            for (int i = 0; i < 9; i++)
            {
                if (board[i][y] == 0) continue;
                if (!_uniqueValues.Add(board[i][y]))
                {
                    return false;
                }
            }

            //validate sub-box
            _uniqueValues.Clear();
            int startI = (x / 3) * 3;
            int endI = startI + 3;
            int startJ = (y / 3) * 3;
            int endJ = startJ + 3;
            for (int i = startI; i < endI; i++)
            {
                for (int j = startJ; j < endJ; j++)
                {
                    if (board[i][j] == 0) continue;
                    if (!_uniqueValues.Add(board[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Print(int[][] board)
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++) 
                {
                    Console.Write("  " + board[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
