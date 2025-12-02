using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace WpfApp1
{
    public class CObject
    {
        private Point position;
        private Size size;
        private double lifetime;
        private double pointsValue;
        private Ellipse sprite;
        public CObject(Point position, double size, double lifetime) //конструктор
        {
            this.position = position;
            this.size = new Size(size, size);
            this.lifetime = lifetime;
            //создание фигуры
            sprite = new Ellipse();
            //цвет фигуры
            sprite.Fill = Brushes.BlueViolet;
            sprite.StrokeThickness = 2;
            sprite.Stroke = Brushes.Black;
            //центрирование фигуры
            sprite.HorizontalAlignment = HorizontalAlignment.Center;
            sprite.VerticalAlignment = VerticalAlignment.Center;
            //размеры фигуры
            sprite.Width = this.size.Width;
            sprite.Height = this.size.Height;
            sprite.RenderTransform = new TranslateTransform(position.X, position.Y);
            pointsValue = ((1 / this.size.Width) / lifetime) * 1000; //очковая стоимость обьекта
        }
        public bool isMouseOnObject(Point mousePosition)
        {
            return mousePosition.X >= position.X &&
                   mousePosition.X <= position.X + size.Width &&
                   mousePosition.Y >= position.Y &&
                   mousePosition.Y <= position.Y + size.Height;
        }
        public Ellipse getSprite()
        {
            return sprite;
        }

        public double getPointsValue()
        {
            return pointsValue;
        }

        public bool updateLifetime(double delta)
        {
            lifetime -= delta;
            return lifetime <= 0;
        }
    }
}
