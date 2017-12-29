﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
        class Asteroid:BaseObject
        {
                public int Power { get; set; }
                public Asteroid(Point pos,Point dir, Size size):base(pos,dir,size)
                {
                        Power = 1;
                }

                public override void Draw()
                {
                        Game.buffer.Graphics.FillEllipse(Brushes.White, pos.X, pos.Y, size.Width, size.Height);

                }


        }
}
