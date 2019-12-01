using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class ChessGame
    {
    }

    public abstract class Piece
    {
        public bool IsKilled { get; set; }
        public bool IsWhite { get; private set; }

        public Piece(bool isWhite)
        {
            this.IsWhite = isWhite;
        }

        public abstract bool CanMove(Board board, Box start, Box end);
    }

    public class King : Piece
    {
        public bool CastlingDone { get; private set; }
        public King(bool isWhite)
            : base(isWhite)
        {

        }

        public void DoCastling()
        {
            //move pieces
            this.CastlingDone = true;
        }
        public override bool CanMove(Board board, Box start, Box end)
        {
            if (end.Piece.IsWhite == this.IsWhite)
            {
                return false;
            }
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            if (x + y == 1)
            {
                // check if this move will not result in the king 
                // being attacked if so return true 
                return true;
            }

            return this.IsValidCastling(board, start, end);
        }

        private bool IsValidCastling(Board board,
                                     Box start, Box end)
        {

            if (this.CastlingDone)
            {
                return false;
            }
            return true;
            // Logic for returning true or false 
        }
    }

    public class Knight : Piece
    {
        public Knight(bool isWhite)
            : base(isWhite)
        {

        }
        public override bool CanMove(Board board, Box start, Box end)
        {
            if (end.Piece.IsWhite == this.IsWhite)
            {
                return false;
            }

            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            return x * y == 2;
        }
    }

    class Rook : Piece
    {
        public Rook(bool isWhite)
            : base(isWhite)
        {

        }
        public override bool CanMove(Board board, Box start, Box end)
        {
            throw new NotImplementedException();
        }
    }
    class Bishop : Piece
    {
        public Bishop(bool isWhite)
            : base(isWhite)
        {

        }
        public override bool CanMove(Board board, Box start, Box end)
        {
            throw new NotImplementedException();
        }
    }

    class Queen : Piece
    {
        public Queen(bool isWhite)
            : base(isWhite)
        {

        }
        public override bool CanMove(Board board, Box start, Box end)
        {
            throw new NotImplementedException();
        }
    }

    class Pawn : Piece
    {
        public Pawn(bool isWhite)
            : base(isWhite)
        {

        }
        public override bool CanMove(Board board, Box start, Box end)
        {
            throw new NotImplementedException();
        }
    }

    public class Board
    {
        Box[,] board;
        public Board()
        {
            board = new Box[8, 8];
        }

        public Box GetBox(int x, int y)
        {
            //validate x and y range

            return board[x, y];
        }

        public void Initialize()
        {
            // initialize white pieces 
            board[0, 0] = new Box(0, 0, new Rook(true));
            board[0, 7] = new Box(0, 7, new Rook(true));

            board[0, 1] = new Box(0, 1, new Knight(true));
            board[0, 6] = new Box(0, 6, new Knight(true));

            board[0, 2] = new Box(0, 2, new Bishop(true));
            board[0, 5] = new Box(0, 5, new Bishop(true));

            board[0, 3] = new Box(0, 3, new Queen(true));
            board[0, 4] = new Box(0, 4, new King(true));

            //... 
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Box(1, i, new Pawn(true));
            }

            //... 

            // initialize black pieces 
            board[7, 0] = new Box(7, 0, new Rook(false));
            board[7, 7] = new Box(7, 7, new Rook(false));

            board[7, 1] = new Box(7, 1, new Knight(false));
            board[7, 6] = new Box(7, 6, new Knight(false));

            board[7, 2] = new Box(7, 2, new Bishop(false));
            board[7, 5] = new Box(7, 5, new Bishop(false));

            board[7, 3] = new Box(7, 3, new Queen(false));
            board[7, 4] = new Box(7, 4, new King(false));

            //... 
            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new Box(6, i, new Pawn(false));
            }
            //... 

            // initialize remaining board without any piece 
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = new Box(i, j, null);
                }
            }
        }
    }

    public class Box
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Piece Piece { get; set; }

        public Box(int x, int y, Piece piece)
        {
            this.X = x;
            this.Y = y;
            this.Piece = piece;
        }
    }

    public class Person
    {
        public int UserId { get; set; }
    }

    public class Player
    {
        public Person player { get; private set; }
        public bool IsWhiteSide { get; private set; }
        public bool IsComputer { get; set; }

        public Player(Person person, bool isWhiteSide, bool isComputer)
        {
            this.player = person;
            this.IsWhiteSide = IsWhiteSide;
            this.IsComputer = IsComputer;
        }
    }

    public class Move
    {
        public Player Player { get; set; }
        public Box Start { get; set; }
        public Box End { get; set; }

        public Piece PieceMoved { get; set; }
        public Piece PieceKilled { get; set; }
        private bool isCastlingMove;

        public Move(Player player, Box start, Box end)
        {
            this.Player = player;
            this.Start = start;
            this.End = end;
            this.PieceMoved = this.Start.Piece;
        }
    }

    public enum GameStatus
    {
        ACTIVE,
        BLACK_WIN,
        WHITE_WIN,
        FORFEIT,
        STALEMATE,
        RESIGNATION
    }

    public class Game
    {
        private Player[] players;
        private Board board;
        private Player currentTurn;
        
        private List<Move> moves;

        public GameStatus GameStatus { get; private set; }

        public Game(Player p1, Player p2)
        {
            this.players[0] = p1;
            this.players[1] = p2;

            board.Initialize();

            if (p1.IsWhiteSide)
            {
                this.currentTurn = p1;
            }
            else
            {
                this.currentTurn = p2;
            }

            moves = new List<Move>();
        }

        public bool PlayerMove(Player player, int startX, int startY, int endX, int endY)
        {
            Box start = board.GetBox(startX, startY);
            Box end = board.GetBox(endX, endY);
            Move move = new Move(player, start, end);
            return this.MakeMove(move, player);
        }

        public bool MakeMove(Move move, Player player)
        {
            Piece sourcePiece = move.Start.Piece;
            if (sourcePiece == null)
            {
                return false;
            }

            // valid player 
            if (player != currentTurn)
            {
                return false;
            }

            if (sourcePiece.IsWhite != player.IsWhiteSide)
            {
                return false;
            }

            // valid move? 
            if (!sourcePiece.CanMove(board, move.Start, move.End))
            {
                return false;
            }

            // kill? 
            Piece destPiece = move.Start.Piece;
            if (destPiece != null)
            {
                destPiece.IsKilled = true;
                move.PieceKilled = destPiece;
            }

            // castling? 
            if (sourcePiece != null && sourcePiece is King && !((King)sourcePiece).CastlingDone) {
                //move.se(true);
                //add logic
            }

            // store the move 
            moves.Add(move);

            // move piece from the stat box to end box 
            move.End.Piece = move.Start.Piece;
            move.Start.Piece = null;

            if (destPiece != null && destPiece is King) {
                if (player.IsWhiteSide)
                {
                    this.GameStatus = GameStatus.WHITE_WIN;
                }
                else
                {
                    this.GameStatus = GameStatus.BLACK_WIN;
                }
            }

            // set the current turn to the other player 
            if (this.currentTurn == this.players[0])
            {
                this.currentTurn = this.players[1];
            }
            else
            {
                this.currentTurn = this.players[0];
            }

            return true;
        }
    }
}
