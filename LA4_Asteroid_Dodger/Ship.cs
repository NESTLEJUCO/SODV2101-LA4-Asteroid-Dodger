using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LA4_Asteroid_Dodger
{
    internal class Ship : Asset
    {
        public Ship(Point center)
        {
            Center = center;
        }

        public override void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 2);
            Pen pen2 = new Pen(Color.White, 10);
            Graphics g = e.Graphics;

            e.Graphics.DrawEllipse(pen, Center.X - 180, Center.Y - 180, 360, 360);
            e.Graphics.DrawArc(pen, Center.X - 150, Center.Y - 180, 300, 360, 90, 360);
            e.Graphics.DrawArc(pen, Center.X - 120, Center.Y - 180, 240, 360, 90, 360);
            e.Graphics.DrawArc(pen, Center.X - 90, Center.Y - 180, 180, 360, 90, 360);
            e.Graphics.DrawArc(pen, Center.X - 60, Center.Y - 180, 120, 360, 90, 360);
            e.Graphics.DrawArc(pen, Center.X - 30, Center.Y - 180, 60, 360, 90, 360);
            e.Graphics.DrawLine(pen, Center.X - 175, Center.Y - 45, Center.X + 175, Center.Y - 45);
            e.Graphics.DrawLine(pen, Center.X - 155, Center.Y - 90, Center.X + 155, Center.Y - 90);
            e.Graphics.DrawLine(pen, Center.X - 120, Center.Y - 135, Center.X + 120, Center.Y - 135);
            e.Graphics.DrawLine(pen, Center.X - 175, Center.Y + 45, Center.X + 175, Center.Y + 45);
            e.Graphics.DrawLine(pen, Center.X - 155, Center.Y + 90, Center.X + 155, Center.Y + 90);
            e.Graphics.DrawLine(pen, Center.X - 120, Center.Y + 135, Center.X + 120, Center.Y + 135);
            e.Graphics.DrawLine(pen2, Center.X - 180, Center.Y, Center.X + 180, Center.Y);
            e.Graphics.FillRectangle(Brushes.Black, Center.X, Center.Y + 5, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 150, Center.Y + 5, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 66, Center.Y + 5, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 123, Center.Y + 5, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 30, Center.Y + 5 - 49, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 30, Center.Y + 46, 40, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 100, Center.Y + 46, 40, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 155, Center.Y + 46, 35, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 120, Center.Y + 46, 35, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 80, Center.Y + 91, 20, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 80, Center.Y + 91, 30, 20);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 35, Center.Y + 91, 20, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 78, Center.Y + 91, 40, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 120, Center.Y + 5 - 49, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 122, Center.Y + 5 - 49, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 62, Center.Y + 5 - 49, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 30, Center.Y + 5 - 49, 40, 39);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 30, Center.Y - 89, 40, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 100, Center.Y - 89, 40, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 155, Center.Y - 89, 35, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 120, Center.Y - 89, 35, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 80, Center.Y - 119, 20, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 80, Center.Y - 119, 30, 20);
            e.Graphics.FillRectangle(Brushes.Black, Center.X + 35, Center.Y - 119, 20, 43);
            e.Graphics.FillRectangle(Brushes.Black, Center.X - 78, Center.Y - 119, 40, 43);
            e.Graphics.FillEllipse(Brushes.Black, Center.X - 120, Center.Y - 120, 90, 90);
            e.Graphics.DrawEllipse(pen, Center.X - 120, Center.Y - 120, 90, 90);
            e.Graphics.FillEllipse(Brushes.Gray, Center.X - 90, Center.Y - 90, 30, 30);
            e.Graphics.DrawLine(pen, Center.X - 107, Center.Y - 107, Center.X - 43, Center.Y - 43);
            e.Graphics.DrawLine(pen, Center.X - 107, Center.Y - 43, Center.X - 43, Center.Y - 107);
            e.Graphics.DrawLine(pen, Center.X - 120, Center.Y - 75, Center.X - 30, Center.Y - 75);
            e.Graphics.DrawLine(pen, Center.X - 75, Center.Y - 120, Center.X - 75, Center.Y - 30);

            Rectangle = new Rectangle(Center.X - 180, Center.Y - 180, 360, 360);
        }
    }
}
