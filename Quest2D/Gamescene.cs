using Otter;
using Quest2D.Entities;
using Quest2D.Util;
using Quest2D;
using System;
using System.Text;
using System.IO;

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
            screenJ = nextJ;
            screenI = nextI;


            String input =  File.ReadAllText("Assets/Nivel.oel");
            int i = 0, j = 0;
            int[,] result = new int[100, 100];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }


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

            Tilemap = new Tilemap ("Assets/sokoban_tilesheet.png", 5760, 2160, Global.GRID_HEIGHT, Global.GRID_WIDTH);
            grid = new GridCollider(5760, 2160, Global.GRID_WIDTH, Global.GRID_HEIGHT);
            Tilemap.SetRect(0, 0, 1, 34, 85);//zidul la stanga
            Tilemap.SetRect(1, 0, 90, 1, 85); //zidul sus
            Tilemap.SetRect(1, 33, 90, 1, 85);//zidul jos
            Tilemap.SetRect(89, 1, 1, 33, 85); //zidul dreapta
            Tilemap.SetRect(1, 1, 88, 32, 89); //fundal
            /*Tilemap.SetRect(4, 4, 3, 2, 101);*///zid random
            /*Tilemap.SetRect(9, 12, 1, 2, 101);*///zid random
            Tilemap.SetRect(30, 1, 30, 16, 90);
            grid.SetRect(1, 33, 94, 1, true);
            grid.SetRect(89, 1, 1, 33, true);
            grid.SetRect(1, 0, 90, 1, true);
            Tilemap.SetRect(29, 9, 1, 2, 88);
            Tilemap.SetRect(59, 14, 1, 2, 88);
            Tilemap.SetRect(60, 17, 30, 17, 90);
            for (i = 0; i<= 48; i++)
            {
                grid.SetTile(0, i, true);
            }

            for(i=1; i<=34; i++)
            {
                for(j=1; j<=89; j++)
                {
                    if (result[i, j] == 1)
                    {
                        grid.SetTile(j, i, true);
                    }
                }
            }
            for (i = 1; i <= 17; i++)
            {
                for (j = 1; j <= 29; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 103);
                    }
                }
            }
            for (i = 1; i <=17 ; i++)
            {
                for (j = 30; j <= 59; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 102);
                    }
                }
            }
            for (i = 1; i <= 17; i++)
            {
                for (j = 60; j <= 89; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 103);
                    }
                }
            }
            for (i = 17; i <= 34; i++)
            {
                for (j = 60; j <= 89; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 102);
                    }
                }
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