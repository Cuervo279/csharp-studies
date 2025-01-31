using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.dto
{
    public class ChessDto
    {
        public class Cell
        {

            public string Position { get; set; }
            public Image PieceImage { get; set; }
        }
    }

    public class BoardSquare
    {
        public string Coordinate { get; set; }
        public Image PieceImage { get; set; }
    }
}
