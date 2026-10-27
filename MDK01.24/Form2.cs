using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDK01._24
{
    public partial class Form2 : Form
    {
        int sunY = 75; // Позиция Колобка
        int sunDirection = 1; // Скорость и направление Колобка
        int cloudOffset = 0; // Смещение облаков
        int cloudDirection = 1;
        Timer animationTimer;
        public Form2()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            animationTimer = new Timer();
            animationTimer.Interval = 16;
            animationTimer.Tick += (s, e) =>
            { 
                sunY += sunDirection;
                if (sunY > 75)
                {
                    sunY = 75;
                    sunDirection *= -1;
                }
                else if (sunY < 50)
                {
                    sunY = 50;
                    sunDirection *= -1;
                }
                cloudOffset += cloudDirection * 2;
                if (cloudOffset + 430 > this.ClientSize.Width || cloudOffset < -10)
                {
                    cloudDirection *= -1; // Меняем направление
                }

                this.Invalidate();
            };
        }     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Небо и Земля
            g.Clear(Color.LightSkyBlue);
            g.FillEllipse(Brushes.ForestGreen, -200, 335, 900, 400); // Холм снизу

            // 2. Колобок 
            Rectangle sun = new Rectangle(75, sunY, 100, 100);
            g.FillEllipse(Brushes.Yellow, sun);
            g.DrawEllipse(Pens.Black, sun);
            // Лицо колобка
            g.FillEllipse(Brushes.LightBlue, 95, sunY + 25, 12, 18); // Левый глаз
            g.FillEllipse(Brushes.LightBlue, 140, sunY + 25, 12, 18); // Правый глаз
            g.FillEllipse(Brushes.Black, 95, sunY + 25, 8, 8); // Левый зрачок
            g.FillEllipse(Brushes.Black, 140, sunY + 25, 8, 8); // Правый зрачок
            g.FillEllipse(Brushes.Red, 85, sunY + 55, 15, 10); // Щека
            g.FillEllipse(Brushes.Red, 150, sunY + 55, 15, 10); // Щека
            g.DrawArc(Pens.Red, 110, sunY + 55, 30, 20, 0, 180); // Улыбка

            //  Лиса
            // Туловище 
            Point[] body = { new Point(150, 340), new Point(250, 340), new Point(200, 180) };
            g.FillPolygon(Brushes.Orange, body);
            g.DrawPolygon(Pens.Black, body);

            // Голова 
            Point[] head = { new Point(150, 180), new Point(250, 230), new Point(250, 130) };
            g.FillPolygon(Brushes.Orange, head);
            g.DrawPolygon(Pens.Black, head);

            // Уши 
            Point[] ear1 = { new Point(290, 140), new Point(250, 130), new Point(250, 160) };
            g.FillPolygon(Brushes.Orange, ear1);
            g.DrawPolygon(Pens.Black, ear1);
            Point[] ear2 = { new Point(290, 215), new Point(250, 200), new Point(250, 230) };
            g.FillPolygon(Brushes.Orange, ear2);
            g.DrawPolygon(Pens.Black, ear2);

            // Глаза 
            g.FillEllipse(Brushes.DeepSkyBlue, 200, 155, 20, 12);
            g.DrawEllipse(Pens.Black, 200, 155, 20, 12);
            g.FillEllipse(Brushes.DeepSkyBlue, 200, 185, 20, 12);
            g.DrawEllipse(Pens.Black, 200, 185, 20, 12);

            // Зрачки 
            g.FillEllipse(Brushes.Black, 200, 155, 10, 10);
            g.FillEllipse(Brushes.Black, 200, 185, 10, 10);

            // Нос
            g.FillEllipse(Brushes.Black, 140, 170, 15, 15);

            // Хвост
            SolidBrush tailBrush = new SolidBrush(Color.Orange);
            Pen outlinePen = new Pen(Color.Black, 1);

            // Начало треугол
            Point[] triangle = {
              new Point(250, 340),
              new Point(250, 305),
              new Point(265, 305)
            };
            g.FillPolygon(tailBrush, triangle);
            g.DrawPolygon(outlinePen, triangle);

            // Первая тропец
            Point[] trap1 = {
               new Point(260, 305), new Point(270, 305),
               new Point(280, 280), new Point(259, 280)
            };
            g.FillPolygon(tailBrush, trap1);
            g.DrawPolygon(outlinePen, trap1);

            // Вторая тропец
            Point[] trap2 = {
               new Point(269, 280), new Point(290, 280),
               new Point(300, 250), new Point(265, 250) 
            };
            g.FillPolygon(tailBrush, trap2);
            g.DrawPolygon(outlinePen, trap2);

            // 4. Облака
            DrawCloud(g, 10 + cloudOffset, 200);
            DrawCloud(g, 300 + cloudOffset, 60);
        }
        private void DrawCloud(Graphics g, int x, int y)
        {
            g.FillEllipse(Brushes.White, x, y, 60, 40);
            g.FillEllipse(Brushes.White, x + 25, y - 15, 70, 50);
            g.FillEllipse(Brushes.White, x + 60, y, 60, 40);
            // Контуры облака
            g.DrawArc(Pens.Black, x, y, 60, 40, 100, 200);
            g.DrawArc(Pens.Black, x + 25, y - 15, 70, 50, 180, 180);
            g.DrawArc(Pens.Black, x + 60, y, 60, 40, -30, 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

}
