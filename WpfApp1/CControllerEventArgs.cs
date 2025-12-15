using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WpfApp1
{
    public class CControllerEventArgs : EventArgs
    {
        //ссылка на визуальное представление собираемого объекта
        public Ellipse sprite;
        public CControllerEventArgs(Ellipse sprite)
        {
            this.sprite = sprite;
        }
    }
}
