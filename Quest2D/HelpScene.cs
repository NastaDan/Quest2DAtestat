using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using Quest2D;

namespace Quest2D
{
    class HelpScene : Scene
    {
        public Image titleImage = new Image("fundal2.png");
        public Text helpText = new Text("Instructions", "Little Kid.otf", 256);
        public Text returnText = new Text("Return  to menu", "Little Kid.otf", 120);
        public Image darkScreen = Image.CreateRectangle(1920, 1080, new Otter.Color("000000"));
        public const float TIMER_BLINK = 30f;
        public float blinkTimer = 0;
        
        

        public HelpScene()
        {
            AddGraphic(titleImage);
            AddGraphic(helpText);
            AddGraphic(returnText);
            returnText.CenterOrigin();
            returnText.X = Global.Joc.HalfWidth;
            returnText.Y = Global.Joc.Height - 150;
        }
        public override void Update()
        {
            base.Update();
            blinkTimer++;
            if (blinkTimer >= TIMER_BLINK)
            {
                returnText.Visible = !returnText.Visible;
                blinkTimer = 0;
            }
            if (Global.PlayerSession.Controller.Button("Start").Pressed)
            {
                Tweener.Tween(darkScreen, new { Alpha = 1 }, 30f, 0).OnComplete(PlayGame);
            }
        }
        private void PlayGame()
        {
            Global.Joc.RemoveScene();
            Global.Joc.AddScene(new TitleScene());
        }
    }
}
