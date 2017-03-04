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
        public Scene nextScene;
        public int screenJ;
        public int screenI;
        public GameScene(int nextJ = 0, int nextI = 0, Player player = null) : base()
        {
            int i;
            screenJ = nextJ;
            screenI = nextI;
            if (player == null)
            {
                Global.player = new Player(500, 500); 
            }
            else
            {
                Global.player = player;
            }
            if (Global.camShaker == null)
            {
                Global.camShaker = new CameraShaker();
            }

            Tilemap = new Tilemap ("Assets/sokoban_tilesheet.png", 5955, 3483, Global.GRID_HEIGHT, Global.GRID_WIDTH);
            grid = new GridCollider(5955, 3483, Global.GRID_WIDTH, Global.GRID_HEIGHT);
            Tilemap.SetRect(0, 0, Global.GRID_WIDTH, Global.GRID_HEIGHT, 85);
            Tilemap.SetRect(1, 0, Global.GRID_WIDTH, Global.GRID_HEIGHT, 102);
            Tilemap.SetRect(4, 4, 3, 2, 101);
            Tilemap.SetRect(9, 12, 1, 2, 101);
            grid.SetRect(4, 4, 3, 2, true);
            for (i = 1; i<= 48; i++)
            {
                grid.SetTile(0, i, true);
            }
        }
        public override void Begin()
        {
            Entity gridEntity = new Entity(0, 0, null, grid);
            Add(gridEntity);
            AddGraphic(Tilemap);
            if (Global.player != null)
            {
                Add(Global.player);
                Global.paused = false;
            }
            Add(Global.camShaker);

            Add(new Enemy(1600, 750));

        }
        public override void Update()
        {
            if (Global.paused)
            {
                return;
            }
            const float HALF_TILE = Global.GRID_WIDTH / 2;
            if (Global.player.X - CameraX < HALF_TILE)
            {
                if (screenJ > 0)
                {
                    if (Global.player.X > 50)
                    {
                        screenJ--;
                        this.Scroll(-1, 0);
                    }
                }
            }
            if (Global.player.Y - CameraY < HALF_TILE)
            {
                if (screenI > 0)
                {
                    if (Global.player.Y > 32)
                    {
                        screenI--;
                        this.Scroll(0, -1);
                    }
                }
            }
            if (Global.player.X - CameraX - 1986 > -HALF_TILE)
            {
                if (screenJ < 2)
                {
                    screenJ++;
                    this.Scroll(1, 0);
                }
            }
            if (Global.player.Y - CameraY - 1162 > -HALF_TILE)
            {
                if (screenI < 1)
                {
                    screenI++;
                    this.Scroll(0, 1);
                }
            }
        }
        public void Scroll(int dx, int dy)
        {
            Global.paused = true;
            nextScene = new GameScene(screenJ, screenI, Global.player);
            nextScene.UpdateLists();
            float pushPlayerX = dx * 30;
            float pushPlayerY = dy * 30;
            Tweener.Tween(Global.player, new
            {
                X = Global.player.X + pushPlayerX,
                Y = Global.player.Y + pushPlayerY
            }, 30f, 0);

            Tweener.Tween(this, new
            {
                CameraX = CameraX + 1920 * dx,
                CameraY = CameraY + 1080 * dy
            }, 30f, 0).OnComplete(ScrollDone);
        }
        public void ScrollDone()
        {
            RemoveAll();
            UpdateLists();
            nextScene.CameraX = CameraX;
            nextScene.CameraY = CameraY;
            Global.Joc.SwitchScene(nextScene);
        }
    }
}