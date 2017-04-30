using Otter;

namespace Quest2D.Entities
{
    class Jake : Entity
    {
        Spritemap<string> Jakesprite = new Spritemap<string>("Assets/Jake.png", 108, 85);
        public Image darkScreen = Image.CreateRectangle(1920, 1080, new Color("000000"));
        public Jake(float x, float y) : base(x, y)
        {
            Jakesprite.Add("Jakedance", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26", 7);
            AddGraphic(Jakesprite);
            Jakesprite.Play("Jakedance");
            SetHitbox(100, 85, (int)Global.Type.JAKE);
            BoxCollider collider = new BoxCollider(100, 85, Global.Type.JAKE);
            AddCollider(collider);
            collider.CenterOrigin();
            darkScreen.Alpha = 0;
            darkScreen.CenterOrigin();
            AddGraphic(darkScreen);
        }


        public override void Update()
        {
            base.Update();
            if (Collider.Overlap(X, Y, Global.Type.PLAYER))
            {
                Win();
                Global.timpscurs.Stop();
            }
        }
        public void Win()
        {
            Global.Joc.RemoveScene();
            Global.Joc.AddScene(new WinScene());

        }
    }
}
