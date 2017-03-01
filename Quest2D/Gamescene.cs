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
        public GridCollider grid = null;

        public GameScene()
        {
           
            Global.player = new Player(500, 500);

            Add(Global.player);
            Add(Global.camShaker);
            Add(new Enemy(1600, 750));
            Add(new Enemy(600, 350));
            Tilemap = new Tilemap ("Assets/Tiles.png", Game.Instance.Width, Game.Instance.Height, Global.GRID_HEIGHT, Global.GRID_WIDTH);
            grid = new GridCollider(Game.Instance.Width, Game.Instance.Height, Global.GRID_WIDTH, Global.GRID_HEIGHT);
            Entity gridEntity = new Entity(0, 0, null, grid);
            AddGraphic(Tilemap);
            Tilemap.SetTile(0, 0, 0);
            grid.SetTile(0, 0, true);
            Tilemap.SetTile(1, 0, 0);
            grid.SetTile(1, 0, true);
            Tilemap.SetTile(2, 0, 0);
            grid.SetTile(2, 0, true);

            // Place some more tiles.
            Tilemap.SetTile(0, 4, 1);
            grid.SetTile(0, 4, true);
            Tilemap.SetTile(1, 4, 1);
            grid.SetTile(1, 4, true);
            Tilemap.SetTile(2, 4, 1);
            grid.SetTile(2, 4, true);
            Tilemap.SetTile(30, 30, 3);
            grid.SetTile(30, 30, true);
            // Even more tiles.
            Tilemap.SetTile(0, 8, 2);
            grid.SetTile(0, 8, true);
            Tilemap.SetTile(1, 8, 2);
            grid.SetTile(1, 8, true);
            grid.SetTile(2, 8, true);
            Tilemap.SetTile(2, 8, 2);
            grid.SetTile(0, 12, true);
            Tilemap.SetTile(0, 12, 3);
            grid.SetTile(1, 12, true);
            Tilemap.SetTile(1, 12, 3);
            grid.SetTile(2, 12, true);
            Tilemap.SetTile(2, 12, 3);
            Tilemap.SetTile(30, 31, 1);
            grid.SetTile(30, 31, true);


        }

    }
}