using Otter;
using Quest2D.Entities;
using Quest2D.Util;
using System;
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
        public Text scorText = new Text("Score: " + Convert.ToString(Global.scor), "VCR.ttf", 40);

        public Image vignette = new Image("Assets/vignette.png");
        public Image heart1 = new Image("Assets/heart.png");
        public Image heart2 = new Image("Assets/heart.png");
        public Image heart3 = new Image("Assets/heart.png");
        public Image heart4 = new Image("Assets/heart.png");

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
            Tilemap.SetRect(90, 1, 1, 34, 85); //zidul dreapta
            Tilemap.SetRect(1, 1, 88, 34, 89); //fundal

            Tilemap.SetRect(30, 1, 30, 16, 90);
            grid.SetRect(1, 33, 94, 1, true);
            grid.SetRect(89, 1, 1, 33, true);
            grid.SetRect(1, 0, 90, 1, true);
            Tilemap.SetRect(29, 9, 1, 2, 88);
            Tilemap.SetRect(59, 14, 1, 2, 88);
            Tilemap.SetRect(60, 17, 30, 17, 90);
            Tilemap.SetRect(76, 16, 2, 1, 88);
            for (i = 0; i<= 48; i++)
            {
                grid.SetTile(0, i, true);
            }

            for(i=1; i<=34; i++)
            {
                for(j=1; j<=88; j++)
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
            for (i = 17; i <= 32; i++)
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
                for (j = 60; j <= 88; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 103);
                    }
                }
            }
            for (i = 17; i <= 33; i++)
            {
                for (j = 60; j <= 88; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 102);
                    }
                }
            }
            for (i = 17; i <= 32; i++)
            {
                for (j = 30; j <= 59; j++)
                {
                    if (result[i, j] == 1)
                    {
                        Tilemap.SetTile(j, i, 103);
                    }
                }
            }
            Tilemap.SetRect(89, 17, 1, 17, 85);
            Tilemap.SetRect(0, 34, 90, 1, 85);
            Tilemap.SetRect(60, 29, 1, 3, 88);
            Tilemap.SetRect(60, 18, 1, 3, 88);
            Tilemap.SetRect(30, 26, 1, 3, 88);

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
            AddGraphicGUI(vignette);

            Add(new Enemy(1600, 750));//prima camera
            Add(new Enemy(576, 370));//prima camera
            Add(new Enemy(576, 708));//prima camera
            Add(new Enemy(2372, 576));//a doua camera
            Add(new Enemy(3264, 96));//a doua camera
            Add(new Enemy(3456, 64));//a doua camera
            Add(new Enemy(2496, 960));//a doua camera
            Add(new Enemy(4864, 96));//a treia camera
            Add(new Enemy(4544, 970));//a treia camera
            Add(new Enemy(5524, 940));//a treia camera
            Add(new Enemy(4532, 1172));//a patra camera
            Add(new Enemy(5184, 1708));//a patra camera
            Add(new Enemy(5576, 2002));//a patra camera
            Add(new Enemy(4608, 2000));//a patra camera
            Add(new Enemy(3584, 1472)); // a cincea camera
            Add(new Enemy(3584, 1792)); // a cincea camera

            Add(new Jake(1000, 1620));

            AddGraphicsGUI(heart1, heart2, heart3, heart4);
            heart1.Visible = true;
            heart2.Visible = true;
            heart3.Visible = true;
            heart4.Visible = true;

            heart1.CenterOrigin();
            heart2.CenterOrigin();
            heart3.CenterOrigin();
            heart4.CenterOrigin();

            heart1.Y = 32;
            heart2.Y = 32;
            heart3.Y = 32;
            heart4.Y = 32;

            heart1.X = 1895;
            heart2.X = 1839;
            heart3.X = 1783;
            heart4.X = 1727;

            AddGraphicGUI(scorText);
        }
        public override void Update()
        {
            base.Update();

            if (Global.paused)
            {
                return;
            }
            scorText.String = "Score: " + Convert.ToString(Global.scor);
            if(Global.PlayerHealth==4)
            {
                heart1.Visible = true;
                heart2.Visible = true;
                heart3.Visible = true;
                heart4.Visible = true;
            }
            else if(Global.PlayerHealth == 3)
            {
                heart1.Visible = true;
                heart2.Visible = true;
                heart3.Visible = true;
                heart4.Visible = false;
            }
            else if(Global.PlayerHealth == 2)
            {
                heart1.Visible = true;
                heart2.Visible = true;
                heart3.Visible = false;
                heart4.Visible = false;
            }
            else if (Global.PlayerHealth == 1)
            {
                heart1.Visible = true;
                heart2.Visible = false;
                heart3.Visible = false;
                heart4.Visible = false;
            }
            else if(Global.PlayerHealth ==0)
            {
                Global.timpscurs.Stop();
                Global.Joc.RemoveScene();
                Global.Joc.AddScene(new LoseScene());
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