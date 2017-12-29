using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Asteroids
{
        class Planet
        {
                protected int x;
                protected int y;
                protected int width;
                protected int height;
                protected int change_direction_x = 3;
                protected int change_direction_y = 3;

                public Planet(int x, int y, int width, int height)
                {
                        this.x = x;
                        this.y = y;
                        this.width = width;
                        this.height = height;
                }

                static Image planet = Image.FromFile("planet.png");

                public void Draw()
                {
                        Game.buffer.Graphics.DrawImage(planet,x,y,width,height);
                }

                 public void Update()
                {
                        x = x + change_direction_x;
                        y = y + change_direction_y;
                        if (x > 700) change_direction_x = -change_direction_x;
                        if (y > 500) change_direction_y = -change_direction_y;
                        if (x < 0) change_direction_x = -change_direction_x;
                        if (y < 0) change_direction_y = -change_direction_y;
                }

        }
}
