using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace api
{
    public class GameController : Controller
    {
        string fn = @"C:\Users\stefa\source\repos\api\bd.txt";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Online()
        {
            return View();
        }
        
        //[HttpGet("{num}")]
        public string Number(int num)
        {
            if (num != 0)
            {
                num = 2 + num;
                SetNumber(num);
            }

            return GetNumber();
        }

        /*public ActionResult<ChessMatrix> GetChessMatrix()
        {
            var cm = CreateChessMatrix();
            return cm;
        }
        */
        private string GetNumber()
        {
            var number = 0;
            if (System.IO.File.Exists(fn))
            {
                var text = System.IO.File.ReadAllText(fn);
                int.TryParse(text, out number);
            }
            return number.ToString();
        }

        private void SetNumber(int number)
        {
            System.IO.File.WriteAllText(fn, number.ToString());
        }

        /*private ChessMatrix CreateChessMatrix()
        {
            ChessMatrix cm = new ChessMatrix();

            var Pawn = 1;
            var Rook = 2;
            var Knight = 3;
            var BlackBishop = 4;
            var WhiteBishop = 5;
            var Queen = 6;
            var King = 7;

            var PiecesImgages = new string[15];

            PiecesImgages[1] = "white_pawn.png";
            PiecesImgages[2] = "white_rook.png";
            PiecesImgages[3] = "white_knight.png";
            PiecesImgages[4] = "white_bishop.png";
            PiecesImgages[5] = "white_bishop.png";
            PiecesImgages[6] = "white_queen.png";
            PiecesImgages[7] = "white_king.png";

            PiecesImgages[8] = "black_pawn.png";
            PiecesImgages[9] = "black_rook.png";
            PiecesImgages[10] = "black_knight.png";
            PiecesImgages[11] = "black_bishop.png";
            PiecesImgages[12] = "black_bishop.png";
            PiecesImgages[13] = "black_queen.png";
            PiecesImgages[14] = "black_king.png";

            for (var i = 0; i < 8; i++)
            {
                cm.ChessBoard[1, i] = 7 + Pawn;
            }

            for (var i = 0; i < 8; i++)
            {
                cm.ChessBoard[6, i] = Pawn;
            }

            cm.ChessBoard[0, 0] = 7 + Rook;
            cm.ChessBoard[0, 7] = 7 + Rook;

            cm.ChessBoard[0, 1] = 7 + Knight;
            cm.ChessBoard[0, 6] = 7 + Knight;

            cm.ChessBoard[0, 2] = 7 + BlackBishop;
            cm.ChessBoard[0, 5] = 7 + WhiteBishop;

            cm.ChessBoard[0, 3] = 7 + Queen;
            cm.ChessBoard[0, 4] = 7 + King;

            cm.ChessBoard[7, 0] = Rook;
            cm.ChessBoard[7, 7] = Rook;

            cm.ChessBoard[7, 1] = Knight;
            cm.ChessBoard[7, 6] = Knight;

            cm.ChessBoard[7, 2] = BlackBishop;
            cm.ChessBoard[7, 5] = WhiteBishop;

            cm.ChessBoard[7, 3] = Queen;
            cm.ChessBoard[7, 4] = King;

            return cm;

        }*/

        public string returnjson()
        {
            Piece p = new Piece(Colour: Colour.Black, PieceType: PieceType.King);
            var js = JsonSerializer.Serialize(p);

            Game game = new Game();
            game.Init();
            string json = JsonSerializer.Serialize(game.ChessBoard);

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Debug.Write(game.ChessBoard);
            //    }
            //    Debug.Write(System.Environment.NewLine);
            //}

            return json;
        }
    }
}