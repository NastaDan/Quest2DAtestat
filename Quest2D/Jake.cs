using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using Quest2D;
using Quest2D.Effects;
using Quest2D.Entities;
namespace Quest2D.Entities
{
    class Jake : Entity
    {
        Spritemap<string> Jakesprite = new Spritemap<string>("Assets/Jake.png", 108, 85);
        Image image = Image.CreateCircle(5, Color.Random);
        public Jake(float x, float y) : base(x, y)
        {
            Jakesprite.Add("Jakedance", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26", 7);
            AddGraphic(Jakesprite);
            Jakesprite.Play("Jakedance");
            SetHitbox(100, 85, (int)Global.Type.JAKE);
            BoxCollider collider = new BoxCollider(100, 85, Global.Type.JAKE);
            AddCollider(collider);
            collider.CenterOrigin();
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
            Global.Joc.Coroutine.Start(MainRoutine());

        }
        IEnumerator MainRoutine()
        {
            yield return Coroutine.Instance.WaitForFrames(30);
            Global.Joc.RemoveScene();
            Global.Joc.AddScene(new WinScene());
        }
    }
}
