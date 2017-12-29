using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
        class Space_station 
        {
                // Переменные задают размер и координаты картинки
                protected int x;
                protected int y;
                protected int width;
                protected int height;
                // Переменная служит для изменения направления движения станции.
                // Так же данная переменная задаёт скорость перемещения станции в горизонтальной плоскости.
                protected int change_direction = 3;


                
                
                
                static Image space_station = Image.FromFile("space-station.png");

                public Space_station(int x, int y, int width, int height)
                {
                        try
                        {
                                this.x = x;
                                this.y = y;
                                this.width = width;
                                this.height = height;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                                GameException.GameObjectException();
                        }
                }
                
                public void Draw()
                {
                        Game.buffer.Graphics.DrawImage(space_station, x, y, width, height);
                }
                 
                public void Update()
                {
                        
                        x = x + change_direction;
                        if (x > 200) change_direction = -change_direction;
                        if (x < 1) change_direction = -change_direction;
                        

                }

                
        }
}
