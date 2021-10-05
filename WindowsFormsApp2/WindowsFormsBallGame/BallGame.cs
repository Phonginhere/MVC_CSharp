using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBallGame
{
    public partial class BallGame : Form
    {
        Rectangle racket;//our racket sprite
        Rectangle ball;//our ball sprite
        Rectangle ball2;//our ball sprite
        int dx, dy;
        int hitCount;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//for smoother graphics/shapes
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), racket);
            e.Graphics.DrawString("score: " + hitCount, DefaultFont, new SolidBrush(Color.Black), new Point(1, 1));

            DrawBall(e);//draws the ball
        }
        private void DrawBall(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Red), ball);
            e.Graphics.FillEllipse(new SolidBrush(Color.Red), ball2);
        }

        private void MoveBall()//this method handles ball movement within the screen
        {
            if (ball.X + dx < 0)
            {
                dx += 10;
            }
            if (ball.X + dx >= pictureBox1.Width)
            {
                dx -= 10;
            }
            if (ball.Y + dy < 0)
            {
                dy += 5;
                if (dy == 0) { dy += 5; }
            }
            if (ball.Y + dy >= pictureBox1.Height)//game over handling if the ball goes past the racket & collides with the bottom of the screen
            {
                dx = 0;//set the speeds to zero
                dy = 0;

                var gameOver = MessageBox.Show("GAME OVER", "Message", MessageBoxButtons.OK);//show a message displaying game over
                if (gameOver == System.Windows.Forms.DialogResult.OK)
                {
                    Close();//close the program
                }
            }
            if (ball.IntersectsWith(racket))//COLLISION DETECTED!
            {
                dy -= 10;
                hitCount += 1;//increment after every hit
            }
            ball.X = ball.X + dx;//update the ball x position
            ball.Y = ball.Y + dy;//update the ball y position


           
        }
        private void MoveBall2()
        {
            if (ball2.X + dx < 0)
            {
                dx += 25;
            }
            if (ball2.X + dx >= pictureBox1.Width)
            {
                dx -= 15;
            }
            if (ball2.Y + dy < 0)
            {
                dy += 55;
                if (dy == 0) { dy += 55; }
            }
            if (ball2.Y + dy >= pictureBox1.Height)//game over handling if the ball goes past the racket & collides with the bottom of the screen
            {
                dx = 0;//set the speeds to zero
                dy = 0;

                var gameOver = MessageBox.Show("GAME OVER", "Message", MessageBoxButtons.OK);//show a message displaying game over
                if (gameOver == System.Windows.Forms.DialogResult.OK)
                {
                    Close();//close the program
                }
            }
            if (ball2.IntersectsWith(racket))//COLLISION DETECTED!
            {
                dy -= 55;
                hitCount += 1;//increment after every hit
            }
            ball2.X = ball2.X + dx;//update the ball x position
            ball2.Y = ball2.Y + dy;//update the ball y position
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            racket.X = e.X;
            if (racket.Right > pictureBox1.Right) { racket.X = pictureBox1.Right - racket.Width; }
            Refresh();//refresh the control to display the new position of the racket
        }

        public BallGame()
        {
            InitializeComponent();
            racket = new Rectangle(120, 270, 150, 10);//sprite initialization
            ball = new Rectangle(140, 50, 20, 20);
            ball2 = new Rectangle(240, 10, 20, 20);
            dx = 5;//initial speeds
            dy = 5;
            hitCount = 0;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5;
            MoveBall();//call move ball to update location
           // MoveBall2();
            Refresh();//refresh the environment
        }
    }
}
