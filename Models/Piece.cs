using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace api
{
    public class Piece
    {
        public Colour Colour { get; set; }

        public PieceType PieceType { get; set; }

        public Piece(Colour Colour, PieceType PieceType)
        {
            this.Colour = Colour;
            this.PieceType = PieceType;
        }

        public Piece()
        {

        }
    }
}
