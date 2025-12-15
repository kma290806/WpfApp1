using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace WpfApp1
{
   
    public delegate void SceneEvent(object sender, CControllerEventArgs e);
    public class CController
    {
            //ссылка на обработчик события добавления объекта в сцену
            public event SceneEvent addObject;
            //ссылка на обработчики событий удаления объекта из сцены
            public event SceneEvent removeObject;
        //создание нового объекта
        private void spawnObject()
        {
            Point position = new Point(rng.NextDouble() * (sceneSize.Width - maxSpriteSize),
           rng.NextDouble() * (sceneSize.Height - maxSpriteSize));
            double size = (rng.NextDouble() * (maxSpriteSize - minSpriteSize)) +
           minSpriteSize;
            double lifetime = (rng.NextDouble() * (maxLifetime - minLifetime)) + minLifetime;
            CObject newObject = new CObject(position, size, lifetime);
            objects.Add(newObject);
            //вызов события добавления обьекта
            addObject?.Invoke(this, new CControllerEventArgs(newObject.getSprite()));
        }
        //удаление объекта из списка и сцены
        private void destroyObject(CObject o)
        {
            CControllerEventArgs e = new CControllerEventArgs(o.getSprite());

        }


    
}
//        private List<CCollectable> objects;
//        private double spawnRate;
//        private double time;
//        private Random rng;
//        private double maxLifetime;
//        private double minLifetime;
//        private double maxSpriteSize;
//        private double minSpriteSize;
//        private double sceneWidth;
//        private double sceneHeight;
//        private double points;
//        private CCollectable newObject;

//        public CController(double spawnRate, double startTime, double sceneWidth, double sceneHeight)
//        {
//            rng = new Random();
//            objects = new List<CCollectable>();
//            this.spawnRate = spawnRate;
//            this.time = startTime;
//            this.sceneWidth = sceneWidth;
//            this.sceneHeight = sceneHeight;
//            points = 0;

//            minLifetime = 1;
//            maxLifetime = 5;
//            minSpriteSize = 10;
//            maxSpriteSize = 20;
//        }
//        public double getPoints()
//        {
//            return points;
//        }
//        public void spawnObject()
//        {
//            double size = 30;                 
//            double maxX = sceneWidth - size;
//            double maxY = sceneHeight - size;    
//            Point position = new Point(
//                rng.Next((int)size, (int)maxX-1) + rng.NextDouble(),
//                 rng.Next((int)size, (int)maxY - 1) + rng.NextDouble()
//            );
//            double lifetime = 1.0;

//            int bonus = rng.Next(4);
//            if (bonus == 0)
//            {
//                newObject = new CPointGiver(position, size, lifetime);//фиолетовый
//            }
//            else if (bonus == 1)
//            {
//                newObject = new CClickSpeedUp(position, size, lifetime, 0.1);//зеленый
//            }
//            else if (bonus == 2)
//            {
//                newObject = new CLifetimeChanger(position, size, lifetime, 15);//желтый
//            }
//            else 
//            {
//                newObject = new CSpawnRateChanger (position, size, lifetime, 15);//оранжевый
//            }
//            objects.Add(newObject);
//        }
//        public void pointsIncrease(double value)
//        {
//            points += value;
//        }
//        public void destroyObject(CCollectable obj)
//        {
//            objects.Remove(obj);
//        }
//        public void update(double delta)
//        {
//            time += delta;
//            if (time >= spawnRate)
//            {
//                spawnObject();
//                time = 0;
//            }
//        }
//        public string mouseClick(Point mousePosition, CPlayer player)
//        {
//            for (int i = objects.Count - 1; i >= 0; i--)
//            {
//                if (objects[i].isMouseOnObject(mousePosition))
//                {
//                    string bonusType = objects[i].GetType().Name;
//                    string bonusName = "";
//                    string bonusColor = "";
//                    switch (bonusType)
//                    {
//                        case "CPointGiver":
//                            bonusName = "Очки";
//                            bonusColor = "фиолетовый";
//                            break;
//                        case "CClickSpeedUp":
//                            bonusName = "Ускорение кликов";
//                            bonusColor = "зеленый";
//                            break;
//                        case "CLifetimeChanger":
//                            bonusName = "Увеличение времени жизни";
//                            bonusColor = "желтый";
//                            break;
//                        case "CSpawnRateChanger":
//                            bonusName = "Ускорение появления объектов";
//                            bonusColor = "оранжевый";
//                            break;
//                    }

                    
//                    if (objects[i].onClick(player, this, mousePosition) == true)
//                    {
//                        destroyObject(objects[i]);
//                        return $"Кликнут {bonusColor} объект: {bonusName}";
//                    }
//                    break;
//                }
//            }
//            return null;
//        }
//        public List<CCollectable> getObjects()
//        {
//            return objects;
//        }
//    }
//}



