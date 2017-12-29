using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
        class GameException: Exception
        {
                static public void GameObjectException()
                {
                        MessageBox.Show("Invalid object parameters");
                }
        }
}
