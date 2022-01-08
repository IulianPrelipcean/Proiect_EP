﻿/**************************************************************************
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

namespace SimpleCheckers
{
    public enum PlayerType { None, Computer, Human };
    // Piesa normala se misca pe diagolele fata/stanga fata/dreapta
    // Piesa de tip king se misca pe toate cele 4 diagonale
    public enum PieceType { Normal, King};

    /// <summary>
    /// Reprezinta o piesa de joc
    /// </summary>
    public partial class Piece
    {
        public int Id { get; set; } // identificatorul piesei
        public int X { get; set; } // pozitia X pe tabla de joc
        public int Y { get; set; } // pozitia Y pe tabla de joc
        public PlayerType Player { get; set; } // carui tip de jucator apartine piesa (om sau calculator)
        public PieceType PT { get; set; }

        public Piece(int x, int y, int id, PlayerType player)
        {
            X = x;
            Y = y;
            Id = id;
            Player = player;
            PT = PieceType.Normal;
        }

        // public List<Move> ValidMoves(Board currentBoard) - completati aceasta metoda in fisierul Rezolvare.cs

        // public bool IsValidMove(Board currentBoard, Move move) - - completati aceasta metoda in fisierul Rezolvare.cs

        
    }
}