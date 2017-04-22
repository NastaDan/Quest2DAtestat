using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
namespace Quest2D.Entities
{
    class HUD : Otter.Entity
    {
        private Text scorText;
        public HUD()
        {
            scorText = new Text("Score: " + Convert.ToString(Global.scor), "VCR.ttf", 40);
            AddGraphicGUI(scorText);
        }
        public override void Update()
        {
            base.Update();

        }
    }
}
