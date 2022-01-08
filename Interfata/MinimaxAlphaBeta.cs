using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCheckers
{
    /// <summary>
    /// Implementeaza algoritmul minimax cu aplha beta prunning
    /// </summary>
    class MinimaxAlphaBeta
    {
        private static Random _rand = new Random();

        public static int _depth = 4;

        public static int _evaluateFunctionType = 1;

        public static (Board, Move) FindNextBoard(Board currentBoard)
        {
            //Board bestVariant = new Board(currentBoard);
            List<Board> bestVariants = new List<Board>();
            List<Move> bestMoves = new List<Move>();
            double max = 0;
            bool first = true;
            foreach (Piece piece in currentBoard.Pieces)
            {
                // Selectez piesele ce apartin calculatorului
                if (piece.Player == PlayerType.Computer)
                {
                    List<Move> moves = piece.ValidMoves(currentBoard);
                    foreach (Move move in moves)
                    {
                        Board boardVariant = currentBoard.MakeMove(move);
                        double alpha = double.NegativeInfinity;
                        double beta = double.PositiveInfinity;
                        double score = Evaluate(boardVariant, 1, alpha, beta);
                        if (first)
                        {
                            max = score;
                            first = false;
                            //bestMove = new Board(boardVariance);
                            bestVariants.Add(boardVariant);
                            bestMoves.Add(move);
                        }
                        else if (max < score)
                        {
                            max = score;
                            //bestMove = new Board(boardVariance);
                            bestVariants = new List<Board>();
                            bestVariants.Add(boardVariant);
                            bestMoves = new List<Move>();
                            bestMoves.Add(move);
                        }
                        else if (max == score)
                        {
                            bestVariants.Add(boardVariant);
                            bestMoves.Add(move);
                        }
                    }
                }
            }
            int chosen = _rand.Next(bestVariants.Count);
            

            return (bestVariants[chosen], bestMoves[chosen]);
        }
        public static double Evaluate(Board currentBoard, int depth, double alpha, double beta)
        {
            // trebuie sa clonez currentBoard
            // daca adancimea are valoare para e calculatorul(maximizez)
            // altfel e jucatorul daci minimizez
            if (depth >= _depth)
            {
                if(_evaluateFunctionType == 1)
                {
                    return currentBoard.EvaluationFunction();
                }
                else
                {
                    if(_evaluateFunctionType == 2)
                    {
                        return currentBoard.EvaluationFunction2();
                    }
                }
                
            }
            //Maximizare
            if (depth % 2 == 0)
            {
                double max = double.NegativeInfinity;
                
                foreach (Piece piece in currentBoard.Pieces)
                {
                    if (piece.Player == PlayerType.Computer)
                    {
                        List<Move> moves = piece.ValidMoves(currentBoard);
                        foreach (Move move in moves)
                        {
                            Board boardVariant = currentBoard.MakeMove(move);
                            double score = Evaluate(boardVariant, depth + 1, alpha, beta);
                            
                            max = Math.Max(max, score);
                            alpha = Math.Max(alpha, score);
                            if (beta <= alpha) break;
                        }
                    }
                }
                return max;
            }
            else
            {
                //Minimizez
                double min = double.PositiveInfinity;
                
                foreach (Piece piece in currentBoard.Pieces)
                {
                    if (piece.Player == PlayerType.Human)
                    {
                        List<Move> moves = piece.ValidMoves(currentBoard);
                        foreach (Move move in moves)
                        {
                            Board boardVariant = currentBoard.MakeMove(move);
                            double score = Evaluate(boardVariant, depth + 1, alpha, beta);
                           
                            min = Math.Min(min, score);
                            beta = Math.Min(beta, score);
                            if (beta <= alpha) break;
                        }
                    }
                }
                return min;
            }
        }
    }
}
