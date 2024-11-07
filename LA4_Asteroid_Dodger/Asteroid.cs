using LA4_Asteroid_Dodger;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    internal class Asteroid : Asset
    {
        Pen pen = new Pen(Color.Brown, 2);
        int Radius;

        public Asteroid(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public override void Draw(PaintEventArgs e)
        {
            Rectangle = new Rectangle(Center.X, Center.Y, Radius, Radius);
            e.Graphics.DrawEllipse(pen, Rectangle);
        }

        public bool Collision(Asset Player)
        {
            return Rectangle.IntersectsWith(Player.Rectangle);
        }
    }
}
