using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
        class PlayerShip
        {
                public int x;
                public int y;
                public int width;
                public int height;
                public int energy = 50;

                static Image playership = Image.FromFile("PlayerShip.png");

                public PlayerShip(int x, int y, int width, int height)
                {
                        this.x = x;
                        this.y = y;
                        this.width = width;
                        this.height = height;

                }

                public void Draw()
                {
                        Game.buffer.Graphics.DrawImage(playership, x, y, width, height);
                }

                public void Up()
                {
                        if (y >= Game.Height) y +=0;
                        --y;

                }

                public void Down()
                {
                        if (y <= 0) y -= 0;
                        y = y + 3;
                }
                public void Right()
                {
                        if (x > Game.Width) x -= 0;
                        x = x + 3;
                }
                public void Left()
                {
                        if (x <= Game.Width) x -= 0;
                        x = x - 3;
                }

                public void Heal()
                {
                        energy += 25;
                }

                public void CurrentEnergy()
                {
                        Console.WriteLine("Energy of ship is:{0}", energy);
                }
        }
}
