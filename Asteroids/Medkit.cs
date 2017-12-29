using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Asteroids
{
        class Medkit
        {
                public int x;
                public int y;
                public int height;
                public int width;

                Image medkit = Image.FromFile("medkit.png");

                public Medkit(int x, int y, int height, int width)
                {
                        this.x = x;
                        this.y = y;
                        this.height = height;
                        this.width = width;
                }

                public void Draw()
                {
                        Game.buffer.Graphics.DrawImage(medkit, x, y, height, width);
                }

                public void Update()
                {
                        x = x - 3; 
                }

                public void Reborn()
                {
                        x = 800;
                        y = 200;
                }

        }
}
