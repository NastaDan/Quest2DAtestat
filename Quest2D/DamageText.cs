using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using Quest2D;

namespace Quest2D
{
    public class DamageText : Entity
    {
        private const int MIN_X_JITTER = 0;
        private const int MAX_X_JITTER = 30;

        private Text text;

        public DamageText(float x, float y, string dmgText, int fontSize = 16)
        {
            text = new Text(dmgText, fontSize);
            text.Color = Color.Red;
            X = x + Otter.Rand.Int(MIN_X_JITTER, MAX_X_JITTER);
            Y = y - 20;

            Graphic = text;
        }

        public override void Update()
        {
            base.Update();


            text.Alpha -= 0.02f;
            Y -= 1.25f; 

            if (text.Alpha <= 0)
            {
                RemoveSelf();
            }
        }
    }
}