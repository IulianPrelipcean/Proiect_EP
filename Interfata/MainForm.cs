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

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleCheckers
{
    public partial class MainForm : Form
    {
        private int pictureWidth = 800;
        private int pictureHeigth = 800;
        private int distanceBetweenPices = 94;//was 125
        private int pieceDiameter = 50;
        private int xOffset = 46;
        private int yOffset = 0;

        private List<Move> humanValidMoves=new List<Move>();
        //Define brush color for king pieces
        SolidBrush opacRed = new SolidBrush(Color.FromArgb(240, 255, 0, 128));
        SolidBrush opacGreen = new SolidBrush(Color.FromArgb(240, 0, 255, 0));
        SolidBrush selectedColor = new SolidBrush(Color.FromArgb(240, 255, 255, 255));
        /*
         Important data
         */
        private Board _board;
        private int _selected; // id-ul piesei selectate
        private PlayerType _currentPlayer; // om sau calculator
        private Bitmap _boardImage;
        private int _difficultyDepth = 4;
        /*
            Utils
         */
        private Stopwatch watch = new Stopwatch(); 

        public MainForm()
        {
            InitializeComponent();
            



            try
            {
                Image temporaryImage = Image.FromFile("board_8x8.png");

                //_boardImage = (Bitmap)Image.FromFile("board_8x8.png");
                _boardImage = new Bitmap(temporaryImage, new Size(pictureWidth, pictureHeigth));
               
            }
            catch
            {
                MessageBox.Show("Nu se poate incarca board.png");
                Environment.Exit(1);
            }

            _board = new Board();
            _currentPlayer = PlayerType.None;
            _selected = -1; // nicio piesa selectata

            this.ClientSize = new System.Drawing.Size(pictureWidth+400, pictureHeigth+100);
            this.pictureBoxBoard.Size = new System.Drawing.Size(pictureWidth, pictureHeigth);
            

            pictureBoxBoard.Refresh();
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            Bitmap board = new Bitmap(_boardImage);
            e.Graphics.DrawImage(board, 0, 0);

            if (_board == null)
                return;

            int dy = pictureHeigth - distanceBetweenPices + yOffset;
            SolidBrush transparentRed = new SolidBrush(Color.FromArgb(192, 255, 0, 0));
            SolidBrush transparentGreen = new SolidBrush(Color.FromArgb(192, 0, 128, 0));
            SolidBrush transparentYellow = new SolidBrush(Color.FromArgb(192, 255, 255, 0));

            foreach (Piece p in _board.Pieces)
            {
                SolidBrush brush = p.PT==PieceType.Normal? transparentRed: opacRed;
                if (p.Player == PlayerType.Human)
                {
                    if (p.Id == _selected)
                        brush = p.PT == PieceType.Normal ? transparentYellow : selectedColor;
                    else
                        brush = p.PT == PieceType.Normal ? transparentGreen : opacGreen; 
                }

                e.Graphics.FillEllipse(brush,
                    xOffset + p.X * distanceBetweenPices, dy - p.Y * distanceBetweenPices,
                    pieceDiameter, pieceDiameter);
            }
        }

        private void pictureBoxBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentPlayer != PlayerType.Human)
                return;
            // Localizez unde am dat click
            int mouseX = e.X / distanceBetweenPices;
            int mouseY = _board.Size-1 - e.Y / distanceBetweenPices;


            // Daca nu am selectat nici o piesa,
            // atunci aia de pe care ridic mouse-ul e cea selectata
            if (_selected == -1)
            {
                foreach (Piece p in _board.Pieces.Where(a => a.Player == PlayerType.Human))
                {
                    if (p.X == mouseX && p.Y == mouseY)
                    {
                        _selected = p.Id;
                        humanValidMoves = p.ValidMoves(_board);
                        pictureBoxBoard.Refresh();
                        break;
                    }
                }
            }
            else// Daca dau inca o data click pe aia selectata, o deselectez
            {
                //!!!!!! CEL MAI POSIBIL VA GENERA ERORI
                //Piece selectedPiece = _board.Pieces[_selected];
                Piece selectedPiece = _board.Pieces[0];

                foreach (Piece piece in _board.Pieces)
                {
                    if (piece.Id == _selected) selectedPiece = piece;
                }


                if (selectedPiece.X == mouseX && selectedPiece.Y == mouseY)
                {
                    _selected = -1;
                    pictureBoxBoard.Refresh();
                }
                else// Am dat click altundeva, inseamna ca mut piesa acolo
                {
                    Move m = new Move(_selected, mouseX, mouseY);

                    // Verific daca mutarea este valida
                    //if (selectedPiece.IsValidMove(_board, m))
                    if(humanValidMoves.Contains(m))
                    {
                        _selected = -1;
                        Move actualMove = humanValidMoves[humanValidMoves.IndexOf(m)];
                        if (humanValidMoves[humanValidMoves.IndexOf(m)].Type == MoveType.Attack)
                        {
                            int number=_board.Pieces.RemoveAll(p => p.Id == actualMove.AttackedId);
                        }
                        Board b = _board.MakeMove(m);
                        AnimateTransition(_board, b);
                        _board = b;
                        
                        pictureBoxBoard.Refresh();
                        _currentPlayer = PlayerType.Computer;

                        CheckFinish();

                        if (_currentPlayer == PlayerType.Computer) // jocul nu s-a terminat
                            ComputerMove();
                    }
                }
            }
        }

        private void ComputerMove()
        {
            Board nextBoard;
            Move nextMove;

            SetParameters();
            
            watch.Start();
            (nextBoard, nextMove) = MinimaxAlphaBeta.FindNextBoard(_board);
            watch.Stop();
            richTextBox1.Text += $"Adancime <{MinimaxAlphaBeta._depth}> timp cautare: {watch.ElapsedMilliseconds} ms\r\n";
            watch.Reset();
            nextBoard.Pieces.RemoveAll(p => p.Id == nextMove.AttackedId);
            _board.Pieces.RemoveAll(p => p.Id == nextMove.AttackedId);
            AnimateTransition(_board, nextBoard);
            _board = nextBoard;
            pictureBoxBoard.Refresh();

            _currentPlayer = PlayerType.Human;

            CheckFinish();
        }

        private void SetParameters()
        {
            MinimaxAlphaBeta._depth = Int32.Parse(depthSearch.Text);
            if (evaluateFunctionType.Text == "functie rapida")
            {
                MinimaxAlphaBeta._evaluateFunctionType = 1;
            }
            else
            {
                if (evaluateFunctionType.Text == "functie complexa")
                {
                    MinimaxAlphaBeta._evaluateFunctionType = 2;
                }
                else
                {
                    MinimaxAlphaBeta._evaluateFunctionType = 1;
                }
            }

            if (Int32.Parse(depthSearch.Text) <= 1)
            {
                levelDifficulty.Text = "Ușor";
            }
            else
            {
                if (Int32.Parse(depthSearch.Text) > 1 && Int32.Parse(depthSearch.Text) <= 4)
                {
                    levelDifficulty.Text = "Mediu";
                }
                else
                {
                    levelDifficulty.Text = "Greu";

                }

            }
        }

        private void CheckFinish()
        {
            bool end; PlayerType winner;
            _board.CheckFinish(out end, out winner);

            if (end)
            {
                if (winner == PlayerType.Computer)
                {
                    MessageBox.Show("Calculatorul a castigat!");
                    _currentPlayer = PlayerType.None;
                }
                else if (winner == PlayerType.Human)
                {
                    MessageBox.Show("Ai castigat!");
                    _currentPlayer = PlayerType.None;
                }
            }
        }

        private void AnimateTransition(Board b1, Board b2)
        {
            Bitmap board = new Bitmap(_boardImage);
            int dy = pictureHeigth - distanceBetweenPices + yOffset;
            SolidBrush transparentRed = new SolidBrush(Color.FromArgb(192, 255, 0, 0));
            SolidBrush transparentGreen = new SolidBrush(Color.FromArgb(192, 0, 128, 0));
            

            Bitmap final = new Bitmap(pictureWidth, pictureHeigth);
            Graphics g = Graphics.FromImage(final);

            int noSteps = 10;

            for (int j = 1; j < noSteps; j++)
            {
                g.DrawImage(board, 0, 0);

                for (int i = 0; i < b1.Pieces.Count; i++)
                {
                    double avx = (j * b2.Pieces[i].X + (noSteps - j) * b1.Pieces[i].X) / (double)noSteps;
                    double avy = (j * b2.Pieces[i].Y + (noSteps - j) * b1.Pieces[i].Y) / (double)noSteps;

                    SolidBrush brush = b1.Pieces[i].PT==PieceType.Normal? transparentRed: opacRed;
                    if (b1.Pieces[i].Player == PlayerType.Human)
                        brush = b1.Pieces[i].PT==PieceType.Normal? transparentGreen: opacGreen;

                    g.FillEllipse(brush,
                        (int)(xOffset + avx * distanceBetweenPices), (int)(dy - avy * distanceBetweenPices),
                        pieceDiameter, pieceDiameter);
                }

                Graphics pbg = pictureBoxBoard.CreateGraphics();
                pbg.DrawImage(final, 0, 0);
            }
        }

        private void jocNouToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _board = new Board();
            richTextBox1.Clear();
            _currentPlayer = PlayerType.Computer;
            levelDifficulty.Text = "Easy";
            depthSearch.Text = "1";
            evaluateFunctionType.Text = "functie rapida";
            ComputerMove();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string reguli =
                " - Piese jucătorului sunt cele verzi\r\n" +
                " \r\n" +
                " - Scopul jocului este de a elimina toate piesele adversarului, acest lucru realizându-se printr-un salt peste piesa inamică\r\n" +
                " \r\n" +
                " - Piesele marcate cu culori diferite față de restul, pentru fiecare jucător, se pot deplasa în toate cele patru direcții, comparativ cu restul care se deplaseaza doar către zona opusă\r\n" +
                " \r\n" +
                " - Orice piesă care ajunge în zona opusă devine o piesă specială și astfel se poate deplasa pe orice direcție \r\n";

            MessageBox.Show(reguli, "Reguli");
        }

        private void iesireToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}