/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2016-2020, Florin Leon                               *
 *  E-mail:      florin.leon@academic.tuiasi.ro                           *
 *  Website:     http://florinleon.byethost24.com/lab_ia.html             *
 *  Description: Game playing. Minimax algorithm                          *
 *               (Artificial Intelligence lab 7)                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;
using System.Linq;

namespace SimpleCheckers
{
    /// <summary>
    /// Reprezinta o configuratie a jocului (o tabla de joc) la un moment dat
    /// </summary>
    public partial class Board
    {
        public int Size { get; set; } // dimensiunea tablei de joc
        public int NoPices { get; set; } // numarul de piese
        public List<Piece> Pieces { get; set; } // lista de piese, atat ale omului cat si ale calculatorului

        public Board()
        {
            Size = 8;
            NoPices = 12;
            Pieces = new List<Piece>(NoPices * 2);
            int pieceId = 0;

            // Adaug piesele pe tabla
            //Piese Inamice
            for (int i = 0; i < Size; i++)
                if (i % 2 == 0)
                {
                    Piece p = new Piece(i, Size - 2, pieceId, PlayerType.Computer);
                    p.PT = PieceType.King;
                    Pieces.Add(p);
                    pieceId += 1;
                }
                else
                {
                    Pieces.Add(new Piece(i, Size - 1, pieceId, PlayerType.Computer));
                    pieceId += 1;
                    Pieces.Add(new Piece(i, Size - 3, pieceId, PlayerType.Computer));
                    pieceId += 1;
                }
            //Piese aliate
            for (int i = 0; i < Size; i++)
                if (i % 2 == 0)
                {
                    Pieces.Add(new Piece(i, 0, pieceId, PlayerType.Human));
                    pieceId += 1;
                    Pieces.Add(new Piece(i, 2, pieceId, PlayerType.Human));
                    pieceId += 1;
                }
                else
                {
                    Piece p = new Piece(i, 1, pieceId, PlayerType.Human);
                    p.PT = PieceType.King;
                    Pieces.Add(p);
                    pieceId+=1;
                }
        }

        public Board(Board b)
        {
            Size = b.Size;
            NoPices = b.NoPices;
            Pieces = new List<Piece>(NoPices * 2);

            foreach (Piece p in b.Pieces)
            {
                Piece piece = new Piece(p.X, p.Y, p.Id, p.Player);
                piece.PT = p.PT;
                Pieces.Add(piece);
            }
        }

        // public double EvaluationFunction() - completati aceasta metoda in fisierul Rezolvare.cs

        /// <summary>
        /// Creeaza o noua configuratie aplicand mutarea primita ca parametru in configuratia curenta
        /// </summary>
        public Board MakeMove(Move move)
        {
            Board nextBoard = new Board(this); // copy
            
            foreach(Piece piece in nextBoard.Pieces)
            {
                if (piece.Id == move.PieceId)
                {
                    // Schimb coordonatele
                    piece.X = move.NewX;
                    piece.Y = move.NewY;

                    // Verific daca piesa a ajuns pe ultima linie in urma acestei mutari
                    // daca a ajuns atunci aceasta va deveni dama
                    if (piece.Player == PlayerType.Computer && piece.Y == 0)
                        piece.PT = PieceType.King;
                    if (piece.Player == PlayerType.Human && piece.Y == Size - 1)
                        piece.PT = PieceType.King;
                }
            }

            return nextBoard;
        }

        /// <summary>
        /// Verifica daca configuratia curenta este castigatoare
        /// </summary>
        /// <param name="finished">Este true daca cineva a castigat si false altfel</param>
        /// <param name="winner">Cine a castigat: omul sau calculatorul</param>
        public void CheckFinish(out bool finished, out PlayerType winner)
        {
          
            /*
            if (Pieces.Where(p => p.Player == PlayerType.Human && p.Y == Size - 1).Count() == Size)
            {
                finished = true;
                winner = PlayerType.Human;
                return;
            }

            if (Pieces.Where(p => p.Player == PlayerType.Computer && p.Y == 0).Count() == Size)
            {
                finished = true;
                winner = PlayerType.Computer;
                return;
            }

            finished = false;
            winner = PlayerType.None;
            */

            // Cine ramane primul fara piese pierde
            if(Pieces.Where(p=> p.Player == PlayerType.Human).Count() == 0)
            {
                finished = true;
                winner = PlayerType.Computer;
                return;
            }
            if (Pieces.Where(p => p.Player == PlayerType.Computer).Count() == 0)
            {
                finished = true;
                winner = PlayerType.Human;
                return;
            }
            finished = false;
            winner = PlayerType.None;
        }

        public List<Piece> GetNeighbours(Piece piece)
        {
            return Pieces.FindAll(p => p.X == piece.X + 1 && p.Y == piece.Y + 1 ||
                             p.X == piece.X + 1 && p.Y == piece.Y - 1||
                              p.X == piece.X - 1 && p.Y == piece.Y + 1||
                               p.X == piece.X - 1 && p.Y == piece.Y - 1);
        }

        public List<Piece> GetAllAttackers(Piece piece)
        {
            List<Piece> attackers = new List<Piece>();
            List<Piece> neighbours = GetNeighbours(piece);

            foreach(Piece p in neighbours)
            {
                // Piesa nu e aliata
                if (p.Player != piece.Player)
                {
                    if(p.PT==PieceType.Normal)
                    {
                        // Verific daca este loc sa stationeze pentru piesa care incearca sa o manance pe aceasta 
                        if (p.Player==PlayerType.Computer && p.Y>piece.Y 
                            && neighbours.Where(neighbour=> 2*piece.X-p.X==neighbour.X && 2*piece.Y-p.Y==neighbour.Y).Count()==0
                            )
                        {
                            attackers.Add(p);
                        }else if(p.Player==PlayerType.Human && p.Y < piece.Y
                            && neighbours.Where(neighbour => 2 * piece.X - p.X == neighbour.X && 2 * piece.Y - p.Y == neighbour.Y).Count() == 0
                            )
                        {
                            attackers.Add(p);
                        }
                    }
                    else//  Damele se pot misca in toate directiile
                    {
                        if(neighbours.Where(neighbour => 2 * piece.X - p.X == neighbour.X && 2 * piece.Y - p.Y == neighbour.Y).Count() == 0)
                        {
                            attackers.Add(p);
                        }
                    }
                }
            }
            return attackers;
        }

        public List<Piece> GetAllAttacked(Piece piece)
        {
            List<Piece> attacked = new List<Piece>();
            List<Piece> neighbours = GetNeighbours(piece);

            foreach(Piece p in neighbours)
            {
                if(p.Player != piece.Player)
                {
                    // Daca piesa piece se afla printre piese ce ataca p 
                    // atunci p este trecuta in colectia attacked
                    List<Piece> attackers = GetAllAttackers(p);
                    if(attackers.Where(attacker=> attacker.Id == piece.Id).Count() == 1)
                    {
                        attacked.Add(p);
                    }
                }
            }

            return attacked;
        }
    }
}