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
        public Tilemap Tilemap = null;
        public Tilemap Coins = null;
        public GridCollider grid = null;

        public GameScene()
        {
           
            Global.player = new Player(500, 500);
            int i;
            Add(Global.player);
            Add(Global.camShaker);
            Add(new Enemy(1600, 750));
            Add(new Enemy(600, 350));
            Tilemap = new Tilemap ("Assets/sokoban_tilesheet.png", Game.Instance.Width, Game.Instance.Height, Global.GRID_HEIGHT, Global.GRID_WIDTH);
            Coins = new Tilemap("Assets/sokoban_tilesheet.png", Game.Instance.Width, Game.Instance.Height, Global.GRID_HEIGHT, Global.GRID_WIDTH);
            grid = new GridCollider(Game.Instance.Width, Game.Instance.Height, Global.GRID_WIDTH, Global.GRID_HEIGHT);
            Entity gridEntity = new Entity(0, 0, null, grid);
            AddGraphics(Tilemap, Coins);
            Tilemap.SetRect(0, 0, Global.GRID_WIDTH, Global.GRID_HEIGHT, 85);
            Tilemap.SetRect(1, 0, Global.GRID_WIDTH, Global.GRID_HEIGHT, 102);
            Tilemap.SetRect(4, 4, 3, 2, 101);
            Coins.SetTile(6, 6, 75);
            grid.SetRect(4, 4, 3, 2, true);
            for (i = 1; i<= 16; i++)
            {
                grid.SetTile(0, i, true);
            }
        }

    }
}