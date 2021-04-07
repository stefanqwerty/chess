// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.


function Test() {
    const uri = 'returnjson'

    fetch(uri)
        .then(response => response.json())
        .then(data => {
            console.log(data)
            DrawBoard(data)
        })
}

function DrawBoard(chessPiecesJson) {

    var i, j;XMLDocument

    var colours = ["white", "black"];
    var pieces = ["", "pawn", "rook", "knight", "bishop", "queen", "king"];

    for (i = 0; i < 8; i++) {
        for (j = 0; j < 8; j++) {
            let boardPos = chessPiecesJson[i][j];

            if (boardPos) {
                var id = 'Piece' + i + j;
                var img = document.createElement("img", id);
                img.id = id;
                var filename = "/images/" + colours[boardPos.Colour] + "_" + pieces[boardPos.PieceType] + ".png";
                if (colours[boardPos.Colour] == "black") {
                    var filename = "/images/" + colours[boardPos.Colour] + "_" + pieces[boardPos.PieceType] + "_1.png";

                }
                img.src = filename;
                img.className = "chess-pieces";

                document.getElementById('body').appendChild(img);

                MovePiecesToUnnecessaryPositions(j, i, id)
            }
        }
    }
}

function GetNumberFromServer() {
    const uri = 'Game/Number'
    fetch(`${uri}?num=${35}`, {
        method: 'GET'
    })
        .then(response =>
            alert(response))
        .then(data =>
            alert(data))

        .catch(error => console.error('error:', error));
}

function GetChessBoardFromServer() {
    const uri = '/Game/GetChessMatrix'

    fetch(uri)
        .then(response =>
            response.json)
        .then(data =>
            console.log(data))
        .then((res) =>
            console.dir(res))
        .then(console.log(response.json))
        .catch(error => console.error('error:', error));


}

function GetNameForImage(chessPiece) {

}

function ArrangePieces() {
    var board = document.getElementById('ChessBoard');
    var Pos = board.offsetLeft;
    var topPos = board.offsetTop;
    var boardSize = board.offsetHeight;
    var pieceSize = boardSize / 8;
    var piece;
    console.log(Pos);
    console.log(topPos);
    for (i = 0; i < 8; i++) {
        for (j = 0; j < 8; j++) {
            piece = document.getElementById('piece' + i + j);
            if (piece !== null) {

                document.getElementById('piece' + i + j).style.left = Pos + j * pieceSize + 'px';
                document.getElementById('piece' + i + j).style.top = topPos + i * pieceSize + 'px';
                console.log('piece' + i + j);
            }
        }
    }
}

var MousePosition = null;

var initialiindex = null;
var initialjindex = null;

var finaliindex = null;
var finaljindex = null;

function MoveIfNecessary(e, chessPieceJson) {
    var MeaningfulVariableName = e;

    if (finaliindex !== null) {
        chessPieceJson[finaljindex][finaliindex] = chessPieceJson[initialjindex][initialiindex];
        chessPieceJson[initialjindex][initialiindex] = null;
        DrawBoard(chessPieceJson);
    }
}

function GetMouseCoords(event) {
    var xpos = event.clientX;
    var ypos = event.clientY;
    var board = document.getElementById('ChessBoard');
    var leftPos = board.offsetLeft;
    var topPos = board.offsetTop;
    var boardSize = board.offsetHeight;

    if (leftPos <= xpos && topPos <= ypos && (leftPos + boardSize) >= xpos && (topPos + boardSize) >= ypos) {
        MousePosition = "" + xpos + " " + ypos;
    }
    else {
        MousePosition = null;
    }

    console.log(MousePosition);
}

function TransformPosition(PointerPosition) {

    var spacePos = PointerPosition.search(" ");
    var pointerXpos = PointerPosition.substring(0, spacePos);
    var pointerYpos = PointerPosition.substring(spacePos + 1, PointerPosition.length);

    var board = document.getElementById('ChessBoard');
    var boardLeftPos = board.offsetLeft;
    var boardTopPos = board.offsetTop;
    var boardSize = board.offsetHeight;
    var squareSize = boardSize / 8;

    var i;
    var j;

    for (i = 0; i < 8; i++) {
        for (j = 0; j < 8; j++) {
            if ((i * squareSize) + boardLeftPos < pointerXpos
                && ((i + 1) * squareSize + 1) + boardLeftPos > pointerXpos
                && (j * squareSize) + boardTopPos < pointerYpos
                && ((j + 1) * squareSize) + boardTopPos > pointerYpos) {
                if (initialiindex === null) {
                    initialiindex = i;
                    initialjindex = j;
                }
                else {
                    finaliindex = i;
                    finaljindex = j;
                }

            }
        }
    }


}

function MovePiecesToUnnecessaryPositions(i, j, id) {
    var board = document.getElementById('ChessBoard');
    var Pos = board.offsetLeft;
    var topPos = board.offsetTop;
    var boardSize = board.offsetHeight;
    var pieceSize = boardSize / 8;
    var piece;

    document.getElementById(id).style.left = Pos + i * pieceSize + 'px';
    document.getElementById(id).style.top = topPos + j * pieceSize + 'px';
}
