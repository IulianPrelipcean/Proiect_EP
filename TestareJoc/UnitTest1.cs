using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCheckers;

namespace TestareJoc
{
    [TestClass]
    public class UnitTest1
    {
        // se testeaza daca functia recursiva de adancime nu se blocheza in recursivitate
        [TestMethod]
        public void TestFunctieEvaluare()
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
        public void TestFinalJoc()
        {
            bool finished;
            PlayerType winner;

            // se creaza o tabla de joc( ce contine defapt piesele in pozitiile initiale)
            Board board = new Board();

            // se elimina toate piesele de tip Computer
            board.Pieces.RemoveAll(p => p.Player == PlayerType.Computer);

            // apel de functie
            board.CheckFinish(out finished, out winner);

            Assert.AreEqual(true, finished);
        }


        // se testeaza o mutare ce iese in afara frontierelor
        [TestMethod]
        public void TestFrontiereMutareInvalida()
        {
            // se creaza o tabla de joc (ce contine defapt piesele in pozitiile initiale)
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
        public void TestMutareValida()
        {
            // se creaza o tabla de joc( ce contine defapt piesele in pozitiile initiale)
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
        public void TestMutareInvalida()
        {
            // se creaza o tabla de joc(ce contine de fapt piesele in pozitiile initiale)
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
