﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Asteroids
{
        class BaseObject: ICollision
        {
                protected Point pos;
                protected Point dir;
                protected Size size;

                public  Rectangle Rect
                {
                        get
                        {
                                return new Rectangle(pos, size);
                        }

                }

                public BaseObject(Point pos, Point dir, Size size)
                {
                        this.pos = pos;
                        this.dir = dir;
                        this.size = size;

                }

                virtual public void Draw()
                {
                        Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);

                }

                virtual public void Update()
                {
                        pos.X = pos.X + dir.X;
                        pos.Y = pos.Y + dir.Y;
                        if (pos.X < 0) dir.X = -dir.X;
                        if (pos.X > Game.Width) dir.X = -dir.X;
                        if (pos.Y < 0) dir.Y = -dir.Y;
                        if (pos.Y > Game.Height) dir.Y = -dir.Y;
                }

                public bool Collision(ICollision o)
                {
                        if (o.Rect.IntersectsWith(this.Rect)) return true;
                        else return false;
                }

                

        }
}
