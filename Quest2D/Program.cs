using Otter;

namespace Quest2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.Joc = new Game("Quest2D", 1920, 1080, 60, true);

            Global.Joc.Color.SetColor(Color.Red);
            Global.Joc.FirstScene = new TitleScene();
            Global.PlayerSession = Global.Joc.AddSession("Player");
            Global.PlayerSession.Controller.AddButton("Start");
            Global.PlayerSession.Controller.AddButton("Up");
            Global.PlayerSession.Controller.AddButton("Down");
            Global.PlayerSession.Controller.AddButton("Left");
            Global.PlayerSession.Controller.AddButton("Right");
            Global.PlayerSession.Controller.AddButton("Attack");
            Global.PlayerSession.Controller.AddButton("Help");
            Global.PlayerSession.Controller.Button("Start").AddKey(Key.Return);
            Global.PlayerSession.Controller.Button("Up").AddKey(Key.W);
            Global.PlayerSession.Controller.Button("Down").AddKey(Key.S);
            Global.PlayerSession.Controller.Button("Left").AddKey(Key.A);
            Global.PlayerSession.Controller.Button("Right").AddKey(Key.D);
            Global.PlayerSession.Controller.Button("Attack").AddKey(Key.Space);
            Global.PlayerSession.Controller.Button("Help").AddKey(Key.Delete);
            Global.Joc.Start();
            
            
        }
    }
    
    

}
