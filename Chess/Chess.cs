using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Chess.dto;


namespace Chess
{
    public partial class Chess : Form
    {
        ChessDto dto = new ChessDto();

        public Chess()
        {
            InitializeComponent();
            InitializeBoard();
        }
    



        private const int CellSize = 50;
        private const int BoardSize = 8;

        private string[,] board = new string[BoardSize, BoardSize];

        private void InitializeBoard()
        {
            BoardSquare[,] board = new BoardSquare[BoardSize, BoardSize];

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    char column = (char)('A' + j);  // Converts 0-7 to A-H
                    int row = BoardSize - i;        // Converts 0-7 to 8-1
                    string coordinate = $"{column}{row}";

                    // Create the square and assign the coordinate
                    board[i, j] = new BoardSquare
                    {
                        Coordinate = coordinate,
                        PieceImage = null // Set this to null initially, or assign a default piece image
                    };

                }
            }
        }
        

        protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                DrawBoard(e.Graphics);
            }

            private void DrawBoard(Graphics g)
            {
                
                for (int row = 0; row < BoardSize; row++)
                {
                    for (int col = 0; col < BoardSize; col++)
                    {
                        // Alternando as cores das casas
                        Brush brush = (row + col) % 2 == 0 ? Brushes.LemonChiffon : Brushes.OliveDrab;
                        g.FillRectangle(brush, col * CellSize, row * CellSize, CellSize, CellSize);

                        // Desenhando o contorno das casas
                        g.DrawRectangle(Pens.Black, col * CellSize, row * CellSize, CellSize, CellSize);

                        // Desenhando as peças
                        //if (!string.IsNullOrEmpty(board[row, col]))
                        //{
                        //    string piece = board[row, col];
                        //    Font font = new Font("Arial", 24);
                        //    Brush textBrush = (row + col) % 2 == 0 ? Brushes.Black : Brushes.White;
                        //    g.DrawString(piece, font, textBrush, col * CellSize + CellSize / 4, row * CellSize + CellSize / 4);
                        //}


                    }
                }
            }
        }
    }










