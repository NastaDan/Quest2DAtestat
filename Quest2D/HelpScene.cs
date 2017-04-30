using Otter;

namespace Quest2D
{
    class HelpScene : Scene
    {
        public Image titleImage = new Image("fundal2.png");
        public Text helpText = new Text("Instructions", "Little Kid.otf", 256);
        public Text helpText2 = new Text("W = Forward, A = Left", "Little Kid.otf", 180);
        public Text helpText3 = new Text("S = Backward, D = Right", "Little Kid.otf", 180);
        public Text helpText4 = new Text("Space = Attack, Esc = Exit", "Little Kid.otf", 180);
        public Text returnText = new Text("Return  to menu", "Little Kid.otf", 120);
        public Image darkScreen = Image.CreateRectangle(1920, 1080, new Otter.Color("000000"));
        public const float TIMER_BLINK = 30f;
        public float blinkTimer = 0;
        
        

        public HelpScene()
        {
            AddGraphic(titleImage);
            AddGraphic(helpText);
            AddGraphic(returnText);
            AddGraphic(helpText2);
            AddGraphic(helpText3);
            AddGraphic(helpText4);
            returnText.CenterOrigin();
            returnText.X = Global.Joc.HalfWidth;
            returnText.Y = Global.Joc.Height - 150;
            helpText2.X = 70;
            helpText2.Y = Global.Joc.Height - 750;
            helpText3.X = 70;
            helpText3.Y = Global.Joc.Height - 600;
            helpText4.X = 70;
            helpText4.Y = Global.Joc.Height - 450;

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
