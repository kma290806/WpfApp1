using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CCountdownTimer //таймер накопления
    {
        double targetTime;// текущее накопленное время в секундах
        public double getTime()
        {
            return targetTime;

        }
        public void update(double delta)
        {
            targetTime += delta;
        }
    }
}
