using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class Piece
    {
        public Colour Colour { get; set; }
        public PieceType PieceType { get; set; }
        public string ImageFile { get; set; }

        public Piece(Colour Colour, PieceType PieceType, string ImageFile = "")
        {
            this.Colour = Colour;
            this.PieceType = PieceType;
            this.ImageFile = ImageFile;
        }

        public Piece()
        {

        }
    }
}
