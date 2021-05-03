// Name: Chanel Brown
// CSC339 - Spring 2021
// Assignment 4

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Connect4
{

    public partial class Form1 : Form
    {
        private Board board;
        public Form1()
        {
            InitializeComponent();

            //adds the event handler for when the screen is painted
            this.Paint += new PaintEventHandler(pic_board_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gets called when the main form is loaded
            board = new Board();

        }

        private void pic_board_Paint(object sender, PaintEventArgs e)
        {
           
            //gets called whenever the screen is painted
            board.DrawBoard(e.Graphics);
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {

            board.PrintBoard(e.Graphics);
        }


        private void btn_col1_Click(object sender, EventArgs e)
        {
            board.col1();
            this.Invalidate();

        }

        private void quitGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            board.ResetBoard();
            this.Invalidate();
            Application.Exit();
        }

        private void btn_col2_Click(object sender, EventArgs e)
        {
            board.col2();
            this.Invalidate();
        }

        private void btn_col3_Click(object sender, EventArgs e)
        {
            board.col3();
            this.Invalidate();
        }

        private void btn_col4_Click(object sender, EventArgs e)
        {
            board.col4();
        }

        private void btn_col5_Click(object sender, EventArgs e)
        {
            board.col5();
            this.Invalidate();
        }

        private void btn_col6_Click(object sender, EventArgs e)
        {
            board.col6();
            this.Invalidate();
        }

        private void btn_col7_Click(object sender, EventArgs e)
        {
            board.col7();
            this.Invalidate();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board.ResetBoard();
            this.Invalidate();
        }

    }

}
