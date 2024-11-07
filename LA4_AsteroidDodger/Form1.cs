using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LA4_AsteroidDodger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic_context;
            Pen outline;
            SolidBrush fill_color;

            Point[] points = new Point[5];
            points[0] = new Point(150, 120);
            points[1] = new Point(120, 150);
            points[2] = new Point(150, 180);
            points[3] = new Point(150, 180);
            points[4] = new Point(150, 180);


            Point[] pointCurve = new Point[5];
            pointCurve[0] = new Point(250, 220);
            pointCurve[1] = new Point(220, 280);
            pointCurve[2] = new Point(290, 280);
            pointCurve[3] = new Point(300, 341);
            pointCurve[4] = new Point(314, 280);

            graphic_context = this.CreateGraphics();

            outline = new Pen(Color.DarkBlue, 2);

            fill_color = new SolidBrush(Color.Red);

            graphic_context.DrawPolygon(outline, points);
            graphic_context.DrawCurve(outline, pointCurve);
            graphic_context.DrawEllipse(outline, 300, 10, 50, 80);

            Font font = new Font("Verdana", 20);
            Point location = new Point(400, 200);
            StringFormat draw_format = new StringFormat();
            draw_format.FormatFlags = StringFormatFlags.DirectionVertical;

            graphic_context.DrawString("Hello There", font, fill_color, location, draw_format);

            PictureBox pic = new PictureBox();
            pic.Size = new Size(200, 500);
            pic.Location = new Point(550, 100);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            pic.Image = Image.FromFile("Paste target link here");
            this.Controls.Add(pic);
        }
    }
}
