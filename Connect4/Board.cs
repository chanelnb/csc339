using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{

    
    enum Player
    {
        EMPTY, RED, YELLOW
    }
    class Board
    {
        int currentTurn = 1;
        Player player = Player.RED;
        bool win = false;
        private const int rows = 6;
        private const int cols = 7;
        private Player[,] board = new Player[rows, cols];

        public Board()
        {
            //constructor
            ResetBoard();
        }

        public void ResetBoard()
        {
            //reset the game board to empty
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = Player.EMPTY;
                }
            }

        }

        public void DrawBoard(Graphics g)
        {
            int start = 50; //board top left corner offset
            
            g.FillRectangle(Brushes.Navy, start, start, 700, 600);

            //draw the board columns
            for (int i = 100; i <= 600; i = i + 100)
                g.DrawLine(Pens.White, start + i, start, start + i, start + 600);

            //draw the board rows
            for (int i = 100; i <= 500; i = i + 100)
                g.DrawLine(Pens.White, start, start + i, start + 700, start + i);


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == Player.RED)
                    {
                        g.FillEllipse(Brushes.Red, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                    }
                    else if (board[i, j] == Player.YELLOW)
                    {
                        g.FillEllipse(Brushes.Yellow, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.White, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                    }
                }
            }
        }



        bool checkWin()
        {
            bool returnStatement = false;
            win = false;
            for (int i = 5; i >= 0; --i)
            {
                for (int j = 6; j >= 0; --j)
                {
                    if (player == Player.RED)
                    {
                        
                            if (board[i, j] == Player.RED && board[i - 1, j + 1] == Player.RED &&
                                board[i - 2, j + 2] == Player.RED && board[i - 3, j + 3] == Player.RED)
                            {
                                win = true;
                                goto labelwin;
                            }
                        
                        if (board[i, j] == Player.RED && board[i - 1, j] == Player.RED &&
                            board[i - 2, j] == Player.RED && board[i - 3, j] == Player.RED)
                        {
                            win = true;
                            goto labelwin;
                        }

                        if (board[i, j] == Player.RED && board[i, j + 1] == Player.RED &&
                            board[i, j + 2] == Player.RED && board[i, j + 3] == Player.RED)
                        {
                            win = true;
                            goto labelwin;
                        }
                    }
                    else
                    {
                        if (board[i, j] == Player.YELLOW && board[i - 1, j + 1] == Player.YELLOW &&
                           board[i - 2, j + 2] == Player.YELLOW && board[i - 3, j + 3] == Player.YELLOW)
                        {
                            win = true;
                            goto labelwin;
                        }

                        if (board[i, j] == Player.YELLOW && board[i - 1, j] == Player.YELLOW &&
                            board[i - 2, j] == Player.YELLOW && board[i - 3, j] == Player.YELLOW)
                        {
                            win = true;
                            goto labelwin;
                        }

                        if (board[i, j] == Player.YELLOW && board[i, j + 1] == Player.YELLOW &&
                            board[i, j + 2] == Player.YELLOW && board[i, j + 3] == Player.YELLOW)
                        {
                            win = true;
                            goto labelwin;
                        }
                    }
                }
            }

        labelwin:
            if (win)
                returnStatement = true;
            return returnStatement;
        }

        Player nextTurn()
        {

            bool check = checkWin();
            if (currentTurn % 2 == 0)
            {
                player = Player.YELLOW;
                currentTurn++;
            }
            else
            {
                player = Player.RED;
                currentTurn++;
            }
            if (check)
            {
                win = true;
            }
            return player;

        }

        public void col1()
        {

            nextTurn();
            int tracker = 5;
        label1:
            if (board[tracker, 0] == Player.EMPTY)
            {
                if (player == Player.RED)
                {
                    board[tracker, 0] = Player.RED;
                }
                else
                {
                    board[tracker, 0] = Player.YELLOW;
                }
            }
            else if (board[tracker, 0] == Player.RED || board[tracker, 0] == Player.YELLOW)
            {
                tracker--;
                goto label1;
            }
            checkWin();
            winner();

        }

        public void col2()
        {
            do
            {
                nextTurn();
                int tracker = 5;
            label1:
                if (board[tracker, 1] == Player.EMPTY)
                {
                    if (player == Player.RED)
                    {
                        board[tracker, 1] = Player.RED;
                    }
                    else
                    {
                        board[tracker, 1] = Player.YELLOW;
                    }
                }
                else if (board[tracker, 1] == Player.RED || board[tracker, 1] == Player.YELLOW)
                {
                    tracker--;
                    goto label1;
                }
                checkWin();
            } while (win == true);

        }

        public void col3()
        {
            nextTurn();
            int tracker = 5;
        label1:
            if (board[tracker, 2] == Player.EMPTY)
            {
                if (player == Player.RED)
                {
                    board[tracker, 2] = Player.RED;
                }
                else
                {
                    board[tracker, 2] = Player.YELLOW;
                }
            }
            else if (board[tracker, 2] == Player.RED || board[tracker, 2] == Player.YELLOW)
            {
                tracker--;
                goto label1;
            }
            checkWin();
            winner();

        }

        public void col4()
        {
            nextTurn();
            int tracker = 5;
        label1:
            if (board[tracker, 3] == Player.EMPTY)
            {
                if (player == Player.RED)
                {
                    board[tracker, 3] = Player.RED;
                }
                else
                {
                    board[tracker, 3] = Player.YELLOW;
                }
            }
            else if (board[tracker, 3] == Player.RED || board[tracker, 3] == Player.YELLOW)
            {
                tracker--;
                goto label1;
            }
            checkWin();
            winner();
        }

        public void col5()
        {
            nextTurn();
            int tracker = 5;
        label1:
            if (board[tracker, 4] == Player.EMPTY)
            {
                if (player == Player.RED)
                {
                    board[tracker, 4] = Player.RED;
                }
                else
                {
                    board[tracker, 4] = Player.YELLOW;
                }
            }
            else if (board[tracker, 4] == Player.RED || board[tracker, 4] == Player.YELLOW)
            {
                tracker--;
                goto label1;
            }
            checkWin();
            winner();

        }

        public void col6()
        {

            nextTurn();
            int tracker = 5;
        label1:
            if (board[tracker, 5] == Player.EMPTY)
            {
                if (player == Player.RED)
                {
                    board[tracker, 5] = Player.RED;
                }
                else
                {
                    board[tracker, 5] = Player.YELLOW;
                }
            }
            else if (board[tracker, 5] == Player.RED || board[tracker, 5] == Player.YELLOW)
            {
                tracker--;
                goto label1;
            }
            checkWin();
            winner();

        }

        public void col7()
        {
            nextTurn();
            int tracker = 5;
        label1:
            if (board[tracker, 6] == Player.EMPTY)
            {
                if (player == Player.RED)
                {
                    board[tracker, 6] = Player.RED;
                }
                else
                {
                    board[tracker, 6] = Player.YELLOW;
                }
            }
            else if (board[tracker, 6] == Player.RED || board[tracker, 6] == Player.YELLOW)
            {
                tracker--;
                goto label1;
            }
            checkWin();
            winner();

        }

        public void PrintBoard(Graphics g)
        {
            int start = 50;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == Player.RED)
                    {
                        g.FillEllipse(Brushes.Red, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                    }
                    else if (board[i, j] == Player.YELLOW)
                    {
                        g.FillEllipse(Brushes.Yellow, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.White, (start + 5) + (j * 100), (start + 5) + (i * 100), 90, 90);
                    }
                }
            }
        }

        public void winner()
        {
            string winnerName;
            if (win == true)
            {
                if (player == Player.RED)
                {
                    winnerName = "Red";
                }
                else
                {
                    winnerName = "Yellow";
                }

                MessageBox.Show($"{winnerName} wins!", "Winner");
            }
        }

    }    
}
