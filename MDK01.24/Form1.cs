using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDK01._24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 1. Создаем объект Graphics
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                // 3. Задаем вершины треугольника
                Point[] trianglePoints = {
                new Point(420, 298),  // Верхняя точка
                new Point(350, 422),  // Нижняя левая
                new Point(490, 422)  };

                g.DrawPolygon(pen, trianglePoints);

                using (SolidBrush brush = new SolidBrush(Color.DarkOrange))
                {
                    g.FillPolygon(brush, trianglePoints);
                }
            }
            using (Pen golovap = new Pen(Color.Black, 2))
            {
                Point[] golova =
                {
                    new Point (320, 250),
                    new Point (450, 310),
                    new Point (450, 200)
                }
            ;
                g.DrawPolygon(golovap, golova);
                using (SolidBrush brush = new SolidBrush(Color.DarkOrange))
                {
                    g.FillPolygon(brush, golova);
                }
            }
            using (Pen yhiVp = new Pen(Color.Black, 2))
            {
                Point[] yhiV =
                {
                    new Point (480, 220),
                    new Point (450, 200),
                    new Point (450, 230)
                };
                g.DrawPolygon(yhiVp, yhiV);
                using (SolidBrush brush = new SolidBrush(Color.DarkOrange))
                {
                    g.FillPolygon(brush, yhiV);
                }
            }
            using (Pen yhiNp = new Pen(Color.Black, 2))
            {
                Point[] yhiN =
                {
                    new Point (480, 300),
                    new Point (450, 280),
                    new Point (450, 310)
                };
                g.DrawPolygon(yhiNp, yhiN);
                using (SolidBrush brush = new SolidBrush(Color.DarkOrange))
                {
                    g.FillPolygon(brush, yhiN);
                }
            }
            using (Pen XvostP = new Pen(Color.Black, 2))
            {
                Point[] Xvost =
                {
                    new Point(500,300),
                    new Point(460, 350),
                    new Point(485, 360),
                    new Point(490, 422),
                    new Point(500, 402),
                    new Point(495, 396),
                    new Point(480, 380)
                };
                g.DrawPolygon(XvostP, Xvost);
                using (SolidBrush brush = new SolidBrush(Color.DarkOrange))
                {
                    g.FillPolygon(brush, Xvost);
                }
            }
            int x = 50, y = 50;     // Позиция
            int width = 200;        // Длина фигуры
            int height = 60;        // Толщина (высота) в центре

            using (GraphicsPath path = new GraphicsPath())
            {
                // Верхняя дуга
                path.AddArc(x, y, width, height * 2, 225, 90);
                // Нижняя дуга (рисуется в обратном направлении, чтобы соединиться)
                path.AddArc(x, y - height, width, height * 2, 45, 90);

                path.CloseFigure(); // Замыкаем контур, чтобы концы стали острыми

                // Рисуем контур
                g.DrawPath(Pens.Black, path);








            }
        }
    }
}
