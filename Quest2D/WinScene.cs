using System;
using Otter;


namespace Quest2D
{
    class WinScene : Scene
    {
        public Image Rectangle0 = Image.CreateRectangle(1920, 180, new Color(Color.Random));
        public Image Rectangle1 = Image.CreateRectangle(1920, 180, new Color(Color.Random));
        public Image Rectangle2 = Image.CreateRectangle(1920, 180, new Color(Color.Random));
        public Image Rectangle3 = Image.CreateRectangle(1920, 180, new Color(Color.Random));
        public Image Rectangle4 = Image.CreateRectangle(1920, 180, new Color(Color.Random));
        public Image Rectangle5 = Image.CreateRectangle(1920, 180, new Color(Color.Random));
        public Image ScoreBackground = Image.CreateRectangle(1280, 720, new Color(Color.Grey));
        public Text WinText = new Text("ÎYOU'WINÏ", "yorkwhiteletter.otf", 160);
        public Text ScoreText = new Text("Score: " + Convert.ToString(Global.scor) + " points  ", "VCR.ttf", 60);
        public Text TimerText = new Text("Time: " + Convert.ToString((Global.timpscurs.ElapsedMilliseconds)/1000) + " seconds  ", "VCR.ttf", 60);
        public Text button = new Text("Press Enter to play/Delete to exit", "VCR.ttf", 40);
        public Image vignette = new Image("Assets/vignette.png");
        public Image darkScreen = Image.CreateRectangle(1920, 1080, new Otter.Color("000000"));
        public Random rnd = new Random();
        public WinScene()
        {
            Global.PlayerHealth = 4;
            AddGraphicGUI(vignette);
            AddGraphics(Rectangle0, Rectangle1, Rectangle2, Rectangle3, Rectangle4, Rectangle5);
            AddGraphicGUI(ScoreBackground);
            AddGraphicsGUI(WinText, ScoreText, TimerText, button);
            WinText.CenterOrigin();
            WinText.X = 960;
            WinText.Y = 235;
            ScoreText.CenterOrigin();
            ScoreText.X = 680;
            ScoreText.Y = 400;
            TimerText.CenterOrigin();
            TimerText.X = 680;
            TimerText.Y = 500;
            button.CenterOrigin();
            button.X = 960;
            button.Y = 800;
            button.Color.SetColor(Color.Gold);
            WinText.Color.SetColor(Color.Gold);
            ScoreBackground.OutlineColor.SetColor(Color.Gold);
            ScoreBackground.OutlineThickness = 18;
            Rectangle0.SetPosition(0, 0);
            Rectangle1.SetPosition(0, 180);
            Rectangle2.SetPosition(0, 360);
            Rectangle3.SetPosition(0, 540);
            Rectangle4.SetPosition(0, 720);
            Rectangle5.SetPosition(0, 900);
            ScoreBackground.SetPosition(320, 180);

            darkScreen.Alpha = 0;
            AddGraphic(darkScreen);
        }
        public override void Update()
        {
            base.Update();
            int halfer = rnd.Next(0, Int32.MaxValue);
            if(halfer < (Int32.MaxValue)/8)
            {
                Rectangle0.Color.SetColor(Color.Random);
                Rectangle1.Color.SetColor(Color.Random);
                Rectangle2.Color.SetColor(Color.Random);
                Rectangle3.Color.SetColor(Color.Random);
                Rectangle4.Color.SetColor(Color.Random);
                Rectangle5.Color.SetColor(Color.Random);
            }
            if (Global.PlayerSession.Controller.Button("Start").Pressed)
            {
                Tweener.Tween(darkScreen, new { Alpha = 1 }, 60f, 0).OnComplete(PlayGame);
            }
            if (Global.PlayerSession.Controller.Button("Help").Pressed)
            {
                Tweener.Tween(darkScreen, new { Alpha = 1 }, 60f, 0).OnComplete(PlayHelp);
            }
        }
        private void PlayGame()
        {
            Global.Joc.RemoveScene();
            Global.Joc.AddScene(new TitleScene());
            Global.scor = 0;
        }
        private void PlayHelp()
        {
            Global.Joc.Close();
        }
    }
}
