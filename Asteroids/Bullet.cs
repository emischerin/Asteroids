﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
        class Bullet: BaseObject
        {
                public Bullet(Point pos, Point dir, Size size):base(pos,dir,size)
                {

                }

                public override void Draw()
                {
                        Game.buffer.Graphics.DrawRectangle(Pens.OrangeRed, pos.X, pos.Y, size.Width, size.Height);
                }

                public override void Update()
                {
                        pos.X = pos.X + 3;
                }
        }
}
