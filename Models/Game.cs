using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{

    public class Game
    {
        public bool IsCheck = false;

        public Colour Turn = Colour.White;

        public Piece[][] ChessBoard = new Piece[8][];

        public void Init()
        {
            for (int i=0; i<8; i++)
            {
                ChessBoard[i] = new Piece[8];
            }

            for (int i = 0; i < 8; i++)
            {
                ChessBoard[6][i] = new Piece(Colour.White, PieceType.Pawn);
            }

            for (int i = 0; i < 8; i++)
            {
                ChessBoard[1][i] = new Piece(Colour.Black, PieceType.Pawn);
            }

            ChessBoard[7][7] = new Piece(Colour.White, PieceType.Rook);
            ChessBoard[7][0] = new Piece(Colour.White, PieceType.Rook);

            ChessBoard[0][7] = new Piece(Colour.Black, PieceType.Rook);
            ChessBoard[0][0] = new Piece(Colour.Black, PieceType.Rook);

            ChessBoard[7][1] = new Piece(Colour.White, PieceType.Knight);
            ChessBoard[7][6] = new Piece(Colour.White, PieceType.Knight);

            ChessBoard[0][1] = new Piece(Colour.Black, PieceType.Knight);
            ChessBoard[0][6] = new Piece(Colour.Black, PieceType.Knight);

            ChessBoard[7][2] = new Piece(Colour.White, PieceType.Bishop);
            ChessBoard[7][5] = new Piece(Colour.White, PieceType.Bishop);

            ChessBoard[0][2] = new Piece(Colour.Black, PieceType.Bishop);
            ChessBoard[0][5] = new Piece(Colour.Black, PieceType.Bishop);

            ChessBoard[7][3] = new Piece(Colour.White, PieceType.King);
            ChessBoard[7][4] = new Piece(Colour.White, PieceType.Queen);

            ChessBoard[0][3] = new Piece(Colour.Black, PieceType.King);
            ChessBoard[0][4] = new Piece(Colour.Black, PieceType.Queen);
        }
        
        public void Move(int x1, int y1, int x2, int y2)
        {
            ChessBoard[x2][y2] = ChessBoard[x1][y1];
            ChessBoard[x1][y1] = null;
        }
        
    }

    public enum Colour
    {
        White = 0,
        Black = 1
    }

    public enum PieceType
    {
        Pawn = 1,
        Rook = 2,
        Knight = 3,
        Bishop = 4,
        Queen = 5,
        King = 6
    }
}
