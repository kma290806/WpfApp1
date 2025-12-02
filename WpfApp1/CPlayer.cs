using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class CPlayer
    {
        bool canClick;// клик сейчас
        double timeBeforeClick;//время между кликами
        CCountdownTimer countdownTimer;

        public CPlayer(double timeBeforeClick)
        {
            this.timeBeforeClick = timeBeforeClick;
            this.canClick = true;
            this.countdownTimer = new CCountdownTimer();
        }
        // клик мышкой
        public void mouseClick(Point mousePosition)
        {
            if (canClick)
            {
                canClick = false;
                countdownTimer = new CCountdownTimer();
            }
        }
        //перезарядка
        public void countdownEnded()
        {
            canClick = true;
        }
        
        public void update(double delta)
        {
            if (!canClick)
            {
                countdownTimer.update(delta);
                if (countdownTimer.getTime() >= timeBeforeClick)
                {
                    countdownEnded();
                }
            }
        }
        //увеличение скорости кликов
        public void increaseSpeed(double speedModifier)
        {
            timeBeforeClick *= speedModifier;
        }
        // можно кликать
        public bool getCanClick()
        {
            return canClick;
        }
    }
}
