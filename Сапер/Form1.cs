using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сапер
{
    public partial class Form1 : Form
    {
        Button[][] board;
        byte x, y, b;
        byte n = 30;
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Form1()
        {
            InitializeComponent();
            легкоToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newgame();
        }

        private void newgame()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    board[i][j].Enabled = true;
                    board[i][j].BackColor = Color.DimGray;
                    board[i][j].Tag = 0;
                    board[i][j].RightToLeft = 0;
                    board[i][j].Text = "";
                }
            }
            ranndom();
            for (byte q = 0; q < x; q++)
            {
                for (byte w = 0; w < y; w++)
                {
                    byte[] b = new byte[2];
                    b[0] = q;
                    b[1] = w;
                    Thread t = new Thread(check);
                    t.Start(b);
                    //check(q, w);
                }
            }
            timer1.Enabled = true;
            label2.Text = "0";
            label1.Text = Convert.ToString(b);
        }

        private void clear()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    board[i][j].Dispose();
                }
            }
        }



        private void ranndom()
        {
            Random r = new Random();
            for (int i = 0; i < b; i++)
            {
                int q;
                int w;
                while(board[q=r.Next(x)][w = r.Next(y)].RightToLeft == RightToLeft.Yes){}
                board[q][w].RightToLeft = RightToLeft.Yes;
                //board[q][w].BackColor = Color.Red;
            }
        }

        private void легкоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
            x = 9;
            y = 9;
            b = 10;
            setboard(y, x);
            newgame();
        }

        private void нормальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
            x = 16;
            y = 16;
            b = 40;
            setboard(y, x);
            newgame();
        }

        private void сложноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
            x = 16;
            y = 30;
            b = 99;
            setboard(y, x);
            newgame();
        }

        private void своёToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setboard(byte x,byte y)
        {
            board = new Button[y][];
            for(int i=0;i< y; i++)
            {
                board[i] = new Button[x];
                for(int j=0;j< x; j++)
                {
                    board[i][j] = new Button();
                    board[i][j].Parent = this;
                    board[i][j].Name = String.Format("{0} ", x * i + j);
                    board[i][j].FlatStyle = FlatStyle.Flat;
                    board[i][j].Text = "";
                    board[i][j].Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    board[i][j].Left = j * n;
                    board[i][j].Width = n;
                    board[i][j].Top = label1.Bottom + i * n;
                    board[i][j].Height = n;
                    board[i][j].Tag = 0;
                    board[i][j].RightToLeft = RightToLeft.No;
                    board[i][j].MouseDown += Form1_MouseClick;
                    board[i][j].Enabled = true;
                    board[i][j].BackColor = Color.DimGray;
                    board[i][j].TabStop = false;
                }
            }
            this.Width = x * n+16;
            this.Height = y * n+40+board[0][0].Top;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
        }
        
        private void check(object b)
        {
            byte[] b1 = (byte[])b;
            byte x = b1[0];
            byte y = b1[1];
            try
            {
                if (board[x - 1][y - 1].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x - 1][y].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x - 1][y + 1].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x][y - 1].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x][y + 1].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x + 1][y - 1].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x + 1][y].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (board[x + 1][y + 1].RightToLeft == RightToLeft.Yes)
                {
                    board[x][y].Tag = (int)board[x][y].Tag + 1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void click(object sender)
        {
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
            Form1_MouseClick(sender, e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (((Button)sender).Enabled)
            {
                int w = Convert.ToInt32(((Button)sender).Name) % y;
                int q = Convert.ToInt32(((Button)sender).Name) / y;
                switch (e.Button)
                {
                    case (MouseButtons.Left):
                        {
                            if (((Button)sender).BackColor != Color.Green)
                            {
                                if (((Button)sender).RightToLeft == RightToLeft.No)
                                {
                                    ((Button)sender).Enabled = false;
                                    ((Button)sender).BackColor = Color.White;
                                    if ((int)((Button)sender).Tag == 0)
                                    {
                                        try
                                        {
                                            Form1_MouseClick(board[q - 1][w - 1], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q - 1][w], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q - 1][w + 1], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q][w - 1], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q][w + 1], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q + 1][w - 1], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q + 1][w], e);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            Form1_MouseClick(board[q + 1][w + 1], e);
                                        }
                                        catch (Exception)
                                        {
                                        }

                                    }
                                    else
                                    {
                                        board[q][w].Text = board[q][w].Tag.ToString();
                                    }

                                }
                                else
                                {
                                    timer1.Enabled = false;
                                    board[q][w].BackColor = Color.Red;
                                    for (int i = 0; i < x; i++)
                                    {
                                        for (int j = 0; j < y; j++)
                                        {
                                            board[i][j].Enabled = false;
                                        }
                                    }
                                }
                                
                            }break;
                        }
                    case (MouseButtons.Right):
                        {

                            if (board[q][w].BackColor == Color.Green)
                            {
                                board[q][w].BackColor = Color.DimGray;
                                label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            }
                            else
                            {
                                if (Convert.ToInt32(label1.Text) > 0)
                                {
                                    board[q][w].BackColor = Color.Green;
                                    label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                                }
                            }
                            break;
                        }
                }
            }
        }
    }
}
