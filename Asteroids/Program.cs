﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
       

        static class Program
        {
                
                static void Main()
                {
                        Form form = new Form();
                        form.Width = 800;
                        form.Height = 600;
                        
                        Game.Init(form); 
                        form.Show();
                        Game.Draw();
                        Application.Run(form);
                        
                }
        }
}
