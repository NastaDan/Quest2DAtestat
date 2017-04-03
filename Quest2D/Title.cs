﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using Quest2D;

namespace Quest2D
{
    public class TitleScene : Scene
    {
        public Image titleImage = new Image("fundal.png");
        public Text titleText = new Text("Quest 2D", "Little Kid.otf", 420);
        public Text enterText = new Text("Press Enter", "Little Kid.otf", 120);
        public Text helpText = new Text("Press Delete for help", "Little Kid.otf", 120);
        public const float TIMER_BLINK = 30f;
        public float blinkTimer = 0;
        public Image darkScreen = Image.CreateRectangle(1920, 1080, new Otter.Color("000000"));
        public Music titleSong = new Music("Sounds/title.ogg", true);
        public Random rnd = new Random();

        public TitleScene()
        {
            AddGraphic(titleImage);
            titleText.CenterOrigin();
            titleText.X = Global.Joc.HalfWidth;
            titleText.Y = 100;
            titleText.Color.SetColor(Color.Random);
            this.AddGraphic(titleText);
            enterText.CenterOrigin();
            enterText.X = Global.Joc.HalfWidth;
            enterText.Y = Global.Joc.Height - 300;
            this.AddGraphic(enterText);
            helpText.CenterOrigin();
            helpText.X = Global.Joc.HalfWidth;
            helpText.Y = Global.Joc.Height - 150;
            this.AddGraphic(helpText);
            titleSong.Play();
            darkScreen.Alpha = 0;
            this.AddGraphic(darkScreen);
        }

        public override void Update()
        {
            
            base.Update();
            blinkTimer++;
            int halfer = rnd.Next(0, 200);

            if (halfer <= 35)
            {
                titleText.Color.SetColor(Color.Random);
            }
            if (blinkTimer >= TIMER_BLINK)
            {
                enterText.Visible = !enterText.Visible;
                helpText.Visible = !helpText.Visible;
                blinkTimer = 0;
            }
            if (Global.PlayerSession.Controller.Button("Start").Pressed)
            {
                Tweener.Tween(darkScreen, new { Alpha = 1 }, 60f, 0).OnComplete(PlayGame);
            }
            if(Global.PlayerSession.Controller.Button("Help").Pressed)
            {
                Tweener.Tween(darkScreen, new { Alpha = 1 }, 60f, 0).OnComplete(PlayHelp);
            }
        }
        private void PlayGame()
        {
            titleSong.Stop();
            Global.Joc.RemoveScene();
            Global.Joc.AddScene(new GameScene());
        }
        private void PlayHelp()
        {
            Global.Joc.RemoveScene();
            Global.Joc.AddScene(new HelpScene());
        }
    }
}
