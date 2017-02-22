using Otter;
using Quest2D.Entities;
using Quest2D.Util;
using Quest2D;
using System;
using System.Text;

namespace Quest2D
{
    public class GameScene : Scene
    {
        public GameScene()
        {
           
            Global.player = new Player(75, 75);

            Add(Global.player);
            Add(Global.camShaker);
            Add(new Enemy(1600, 750));
            Add(new Enemy(600, 350));
        }
    }
}