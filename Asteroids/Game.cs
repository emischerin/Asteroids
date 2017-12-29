using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
        public delegate void Med();

        class Game
        {

                public static event Med EnergyUp;
                


                static protected BaseObject[] objs = new BaseObject[30];
                static protected Planet[] planet = new Planet[5];
                static protected Asteroid[] asteroids = new Asteroid[5];
                static protected Space_station station = new Space_station(0,3,75,75);
                static protected Bullet bullet = new Bullet(new Point(0,200),new Point (5,0),new Size(4,1));
                static public PlayerShip player = new PlayerShip(1, 200, 70, 70);
                static protected Medkit med_kit = new Medkit(800, 250, 70, 70);
                
                
                
                

                
                

                
                

                static protected int width;
                static protected int height;

                static BufferedGraphicsContext context;
                static public BufferedGraphics buffer;

                

                static public int Width
                {
                        get
                        {
                                return width;
                        }
                        set
                        {
                                if (value > 1000 || value < 0)
                                {
                                        throw new ArgumentOutOfRangeException("Invalid width");
                                }
                                else width = value;
                        }
                }
                static public int Height
                {
                        get
                        {
                                return height;
                        }
                        set
                        {
                                if (value > 1000 || value < 0)
                                {
                                        throw new ArgumentOutOfRangeException("Invalid Height");
                                }

                                else height = value;
                        }
                }

                static Game()
                {

                }

                 static public void Init(Form form)

                {
                        Load();
                        Timer timer = new Timer();
                        timer.Interval = 100;
                        timer.Start();
                        timer.Tick += Timer_Tick; 
                        Graphics g;
                        context = BufferedGraphicsManager.Current;
                        g = form.CreateGraphics();
                        //Обработка нажатия клавиш для движения корабля
                        form.KeyDown += Form_KeyDown;
                        form.Update();
                        Width = form.Width;
                        Height = form.Height;
                        buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
                        Med kit;
                        kit = player.Heal;
                        kit += med_kit.Reborn;
                        kit += player.CurrentEnergy;
                        EnergyUp += kit;
                        
                        
                }

                static protected void Timer_Tick(object sender, EventArgs e)
                {
                        Draw();
                        Update();
                }

                static public void Draw ()
                {
                        
                        buffer.Graphics.Clear(Color.Black);
                        foreach (BaseObject obj in objs)
                        {
                                obj.Draw();

                        }

                        station.Draw();
                        foreach (Asteroid ast in asteroids)
                        {
                                ast.Draw();
                        }
                        foreach (Planet pl in planet)
                        {
                                pl.Draw();
                        }
                        med_kit.Draw();
                        player.Draw();
                        bullet.Draw();
                        buffer.Graphics.DrawString("Energy of ship is:" + player.energy, SystemFonts.DefaultFont, Brushes.White, 8, 8);
                        buffer.Graphics.DrawString("Ship X and Y are:" + player.x + "-" + player.y, SystemFonts.DefaultFont, Brushes.White, 8, 25);
                        buffer.Graphics.DrawString("Medkit X and Y are:" + med_kit.x + "-" + med_kit.y, SystemFonts.DefaultFont, Brushes.White, 8, 40);

                        if (med_kit.x <= player.x + 30 && med_kit.x > player.x && med_kit.y <= player.y + 30 && med_kit.y >= player.y - 30)
                        {
                                EnergyUp();
                        }
                                                
                        buffer.Render();
                        
                }

                static public void Update()
                {
                        foreach (BaseObject obj in objs)
                        {
                                obj.Update();
                        }

                        station.Update();
                        foreach (Planet pl in planet)
                        {
                                pl.Update();
                        }

                        bullet.Update();
                        med_kit.Update();
                        foreach (Asteroid ast in asteroids)
                        {
                                ast.Update();
                        }
                }

                static public void Load()
                {
                        Random random = new Random();
                                                
                        for (int i = 0; i <15;i++)
                        {
                                objs[i] = new Star(new Point(600, i * 20), new Point(11 - i, 11 - i), new Size(15, 15));

                        }

                        for (int i = 15; i < objs.Length;i++)
                        {
                                objs[i] = new BaseObject(new Point(600, i * 20), new Point(11 - i, 11 - i), new Size(15, 15));
                        }

                       for (int i = 0; i < planet.Length;i++)
                        {
                                planet[i] = new Planet(random.Next(0,200), random.Next(0,500), 50, 50);
                        }

                        for (int i = 0; i < asteroids.Length;i++)
                        {
                                asteroids[i] = new Asteroid(new Point(1000, random.Next(0, Game.Height)), new Point(-random.Next(5,50) / 5, random.Next(5,50)), new Size(random.Next(5, 50), random.Next(5, 50))); 
                        }
                        
                      
                }

                static private void Form_KeyDown(Object sender, KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(player.x + 15, player.y + 4), new Point(4, 0), new Size(4, 1));
                        if (e.KeyCode == Keys.Up) player.Up();
                        if (e.KeyCode == Keys.Down) player.Down();
                        if (e.KeyCode == Keys.Right) player.Right();
                        if (e.KeyCode == Keys.Left) player.Left();
                }
        }
}
