using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Red);
            Brush myBrush = new SolidBrush(Color.Blue);

            g.DrawLine(myPen, 2, 2, 400, 450);
            g.DrawRectangle(myPen, 100, 100, 200, 150);
            g.DrawEllipse(myPen, 300, 200, 50, 50);

            g.FillRectangle(myBrush, 400, 400, 200, 150);
            g.DrawRectangle(myPen, 400, 400, 200, 150);
        }
    }
}
