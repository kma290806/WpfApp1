using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public abstract class CCollectable
    {
        Point position; //позиция собираемого объекта в сцене
        protected Size size; //размер собираемого объекта
        double lifetime; //время жизни собираемого объекта
        protected Ellipse sprite; //визуальное отображение собираемого объекта
        public CCollectable(Point position, double size, double lifetime) 
        {
            this.position = position;
            this.size = new Size(size, size);
            this.lifetime = lifetime;
            sprite = new Ellipse();
            sprite.Fill = Brushes.BlueViolet;
            sprite.StrokeThickness = 2;
            sprite.Stroke = Brushes.Black;
            sprite.HorizontalAlignment = HorizontalAlignment.Center;
            sprite.VerticalAlignment = VerticalAlignment.Center;
            sprite.Width = this.size.Width;
            sprite.Height = this.size.Height;
            sprite.RenderTransform = new TranslateTransform(position.X, position.Y);
           
        }
        public abstract bool onClick(CPlayer player, CController controller, Point mousePosition);
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
    }


}
