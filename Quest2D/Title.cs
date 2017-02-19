using System;
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
        public Image titleImage = new Image("placeholder.png");
        public Text titleText = new Text("Quest 2D", "Little Kid.otf", 280);
        public Text enterText = new Text("Press Enter", "Little Kid.otf", 120);
        public const float TIMER_BLINK = 30f;
        public float blinkTimer = 0;
        public Music titleSong = new Music("Sounds/title.ogg", true);
        public TitleScene()
        {
            AddGraphic(titleImage);
            titleText.CenterOrigin();
            titleText.X = Global.Joc.HalfWidth;
            titleText.Y = 100;
            this.AddGraphic(titleText);
                        enterText.CenterOrigin();
            enterText.X = Global.Joc.HalfWidth;
            enterText.Y = Global.Joc.Height - 300;
            this.AddGraphic(enterText);
            titleSong.Play();
        }

        public override void Update()
        {
            base.Update();
            blinkTimer++;
            if (blinkTimer >= TIMER_BLINK)
            {
                enterText.Visible = !enterText.Visible;
                blinkTimer = 0;
            }
            if(Global.PlayerSession.Controller.Button("Start").Pressed)
            {
                titleSong.Stop();
                Global.Joc.RemoveScene();
                Global.Joc.AddScene(new GameScene());
            }
        }
    }
}
