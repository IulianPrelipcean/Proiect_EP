using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCheckers
{
    [TestClass]
    public class TestareUnitati
    {

        // se testeaza daca functia recursiva de adancime nu se blocheza in recursivitate
        [TestMethod]
        public static void TestFunctieEvaluare()
        {
            // se initializeaza o valiabila cu valoare null
            double? evaluateResult = null;

            // se creaza un board( ce contine defapt piesele in pozitiile initiale)
            Board board = new Board();

            // se apeleaza functia de evaluare cu parametrii necesari
            evaluateResult = MinimaxAlphaBeta.Evaluate(board, 3, double.NegativeInfinity, double.PositiveInfinity);

            Assert.AreNotEqual(null, evaluateResult);
        }


        // se testeaza situatia in care ultima piesa a unui jucator este mancata si jocul trebuie sa se termine
        [TestMethod]
        public static void TestFinalJoc()
        {
            bool finished;
            PlayerType winner;

            // se creaza un board( ce contine defapt piesele in pozitiile initiale)
            Board board = new Board();

            // se elimina toate piesele de tip Computer
            board.Pieces.RemoveAll(p => p.Player == PlayerType.Computer);

            // apel de functie
            board.CheckFinish(out finished, out winner);

            Assert.AreEqual(true, finished);
        }


        // se testeaza o mutare ce iese in afara frontierelor
        [TestMethod]
        public static void TestFrontiereMutareInvalida()
        {
            // se creaza un board( ce contine defapt piesele in pozitiile initiale)
            Board board = new Board();

            // se alege o piesa 
            Piece piece = board.Pieces.Find(p => p.Id == 13 && p.Player == PlayerType.Human);

            // se creaza o mutare invalida
            Move move = new Move(13, -1, 3);

            // apel de functie
            bool moveValidity = piece.IsValidMove(board, move);

            Assert.AreEqual(false, moveValidity);

        }

        // se testeaza corectitudinea unei mutari valide
        [TestMethod]
        public static void TestMutareValida()
        {
            // se creaza un board( ce contine defapt piesele in pozitiile initiale)
            Board board = new Board();

            // se alege o piesa
            Piece piece = board.Pieces.Find(p => p.Id == 16 && p.Player == PlayerType.Human);

            // se creaza o mutare invalida
            Move move = new Move(16, 3, 3);

            // apel de functie
            bool moveValidity = piece.IsValidMove(board, move);

            Assert.AreEqual(true, moveValidity);

        }


        // se testeaza corectitudinea unei mutari invalide in interiorul tablei de joc
        [TestMethod]
        public static void TestMutareInvalida()
        {
            // se creaza un board( ce contine defapt piesele in pozitiile initiale)
            Board board = new Board();

            // se alege o piesa
            Piece piece = board.Pieces.Find(p => p.Id == 2 && p.Player == PlayerType.Computer);

            // se creaza o mutare invalida
            Move move = new Move(2, 1, 4);

            // apel de functie
            bool moveValidity = piece.IsValidMove(board, move);

            Assert.AreEqual(false, moveValidity);
        }


    }
}
