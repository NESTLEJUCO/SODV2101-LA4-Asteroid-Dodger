//Learning Activity 4: Asteroid Dodger
//SODV2101 Rapid Application Development 24SEPMNFS1
//Submitted By: Nestle Juco
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp12;

namespace LA4_Asteroid_Dodger
{
    public partial class Form1 : Form
    {
        Ship Player = new Ship(new Point(550, 350));
        int collisions;
        int score;

        Point? mouseClickPosition = null;
        bool drawLine = false;

        Rectangle colligionRectangle = new Rectangle(-50, -50, 50, 50);
        Timer lineTimer;

        List<Asteroid> AsteroidField;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Size = new Size(1200, 800);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.BackColor = Color.Black;

            this.Paint += new PaintEventHandler(this.PaintObjects);

            collisions = 0;
            score = 0;
            lineTimer = new Timer();
            lineTimer.Interval = 1000;
            lineTimer.Tick += LineTimer_Tick;

            GamePlayLoop.Interval = 24;
            GamePlayLoop.Start();

            int countAsteroids = 0;
            int totalAsteroids = 20;

            AsteroidField = new List<Asteroid>();
            Random random = new Random();

            int[] movement = { -7, -5, -3, -1, 0, 3, 5, 7 };
            int[] movement2 = { -7, -5, -3, -1, 1, 3, 5, 7 };

            while (countAsteroids < totalAsteroids)
            {
                int x = random.Next(100, 1100);
                int y = random.Next(100, 800);
                int raduis = random.Next(20, 70);

                Asteroid asteroid = new Asteroid(new Point(x, y), raduis);
                asteroid.MoveX = movement[random.Next(0, movement.Length - 1)];
                if (asteroid.MoveX == 0) asteroid.MoveY = movement2[random.Next(0, movement2.Length - 1)];
                else asteroid.MoveY = movement[random.Next(0, movement.Length - 1)];
                AsteroidField.Add(asteroid);
                countAsteroids++;
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        protected void PaintObjects(Object sender, PaintEventArgs e)
        {
            Rectangle BoundingBox = new Rectangle(100, 100, 1000, 600);
            e.Graphics.DrawRectangle(Pens.White, BoundingBox);

            Region clippingRegion = new Region(BoundingBox);
            e.Graphics.Clip = clippingRegion;
            Player.Draw(e);

            int assetIndex = AsteroidField.Count - 1;

            while (assetIndex >= 0)
            {
                if (AsteroidField[assetIndex].Collision(Player))
                {
                    AsteroidField.RemoveAt(assetIndex);
                    collisions++; // Count collision 
                    score--; // Reduce score for a collision
                }
                else
                {
                    AsteroidField[assetIndex].Draw(e);
                }
                assetIndex--;

                if (drawLine && mouseClickPosition.HasValue)
                {
                    e.Graphics.DrawEllipse(Pens.Red, colligionRectangle);
                    e.Graphics.DrawLine(Pens.Green, new Point(Player.Center.X - 76, Player.Center.Y - 75), mouseClickPosition.Value);
                }
            }

            e.Graphics.ResetClip();
            e.Graphics.DrawString("Score: " + score.ToString(), new Font("Verdana", 30, FontStyle.Regular), Brushes.Gold, 100, 20);
            e.Graphics.DrawString("Collisions: " + collisions.ToString(), new Font("Verdana", 30, FontStyle.Regular), Brushes.Red, 800, 20);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left) Player.MoveX = -5;
            if (e.KeyCode == Keys.Right) Player.MoveX = +5;
            if (e.KeyCode == Keys.Down) Player.MoveY = +5;
            if (e.KeyCode == Keys.Up) Player.MoveY = -5;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.MoveX = 0;
            Player.MoveY = 0;
        }

        private void GamePlayLoop_Tick(object sender, EventArgs e)
        {
            Player.Move(100, 1100, 100, 800);
            foreach (Asset asteroid in AsteroidField)
            {
                asteroid.Move(0, this.Size.Width, 0, this.Size.Height);
            }

            if (drawLine)
            {
                for (int i = AsteroidField.Count - 1; i >= 0; i--)
                {
                    if (AsteroidField[i].Rectangle.IntersectsWith(colligionRectangle))
                    {
                        AsteroidField.RemoveAt(i);
                        score += 10;
                    }
                }
            }
            this.Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClickPosition = e.Location;
            drawLine = true;
            colligionRectangle = new Rectangle(e.X - 25, e.Y - 25, 50, 50);

            for (int i = AsteroidField.Count - 1; i >= 0; i--)
            {
                if (AsteroidField[i].Rectangle.Contains(e.Location))
                {
                    AsteroidField.RemoveAt(i);
                    score += 10; // Increase score when an asteroid is clicked
                }
            }

            this.Refresh();
            lineTimer.Start();
        }

        private void LineTimer_Tick(object sender, EventArgs e)
        {
            drawLine = false;
            lineTimer.Stop();
            this.Refresh();
        }
    }
}
