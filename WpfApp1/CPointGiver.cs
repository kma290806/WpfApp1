using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public class CPointGiver : CCollectable
    {
        //данный атрибут можно убрать из CObject тк только данный
        //класс будет отвечать за добавление очков
        double pointsValue;
        //конструктор класса реализует конструктор родителя
        public CPointGiver(Point position, double size, double lifetime) : base(position,
       size, lifetime)
        {
            sprite.Fill = Brushes.BlueViolet;
            pointsValue = ((1 / this.size.Width) / lifetime) * 1000;
        }
        
        public override bool onClick(CPlayer player, CController controller, Point mousePosition)
        {
            if (isMouseOnObject(mousePosition) == false)
                return false;//курсор не попал
            controller.pointsIncrease(pointsValue);//очки
            return true;
        }

    }
}
