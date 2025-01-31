using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optionally, initialize the chessboard here if needed
        }

            // Definindo o tamanho das células
        private const int CellSize = 60;
        private const int BoardSize = 8;

            // Array que representa o tabuleiro de xadrez
            private string[,] board = new string[BoardSize, BoardSize];

            private void InitializeBoard()
            {
                // Inicializando as peças nas posições iniciais
                for (int row = 0; row < BoardSize; row++)
                {
                    for (int col = 0; col < BoardSize; col++)
                    {
                        if (row == 1)
                            board[row, col] = "P"; // Peão branco
                        else if (row == 6)
                            board[row, col] = "p"; // Peão preto
                        else
                            board[row, col] = ""; // Células vazias
                    }
                }

                // Colocando as peças principais (torres, cavalos, etc)
                board[0, 0] = board[0, 7] = "T"; // Torres brancas
                board[0, 1] = board[0, 6] = "C"; // Cavalos brancos
                board[0, 2] = board[0, 5] = "B"; // Bispos brancos
                board[0, 3] = "Q"; // Rainha branca
                board[0, 4] = "K"; // Rei branco

                board[7, 0] = board[7, 7] = "t"; // Torres pretas
                board[7, 1] = board[7, 6] = "c"; // Cavalos pretos
                board[7, 2] = board[7, 5] = "b"; // Bispos pretos
                board[7, 3] = "q"; // Rainha preta
                board[7, 4] = "k"; // Rei preto
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
                        // Alternando as cores das casas (preto e branco)
                        Brush brush = (row + col) % 2 == 0 ? Brushes.White : Brushes.Black;
                        g.FillRectangle(brush, col * CellSize, row * CellSize, CellSize, CellSize);

                        // Desenhando o contorno das casas
                        g.DrawRectangle(Pens.Black, col * CellSize, row * CellSize, CellSize, CellSize);

                        // Desenhando as peças
                        if (!string.IsNullOrEmpty(board[row, col]))
                        {
                            string piece = board[row, col];
                            Font font = new Font("Arial", 24);
                            Brush textBrush = (row + col) % 2 == 0 ? Brushes.Black : Brushes.White;
                            g.DrawString(piece, font, textBrush, col * CellSize + CellSize / 4, row * CellSize + CellSize / 4);
                        }
                    }
                }
            }
        }
    }


