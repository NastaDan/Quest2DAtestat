using Otter;

using Quest2D;

using System;

namespace Quest2D.Effects
{
    public class WalkParticle : Entity
    {
        // Number of frames to remain on screen for
        public const int PARTICLE_FRAMES = 4;

        // Our graphic will be a simple image
        public Image image;

        public int direction = 0;
        public int particleTimer = 0;

        public WalkParticle(float x, float y) : base(x, y+30)
        {
            // Our graphic will be a purple circle, with a 4 pixel radius
            Color col = new Color("DDDAD0");
            image = Image.CreateCircle(3, col);
            Graphic = image;
        }

        public override void Update()
        {
            // Float upward
            Y -= (float)(5 / Otter.Rand.Float(1, 3));

            // Gradually become transparent before disappearing
            image.Alpha -= 0.05f;

            particleTimer++;
            if (particleTimer >= PARTICLE_FRAMES)
            {
                RemoveSelf();
            }
        }
    }
}