using Otter;

namespace Quest2D.Effects
{
    public class WalkParticle : Entity
    {
        public const int PARTICLE_FRAMES = 4;
        public Image image;
        public int direction = 0;
        public int particleTimer = 0;
        public WalkParticle(float x, float y) : base(x, y+30)
        {
            Color col = new Color("DDDAD0");
            image = Image.CreateCircle(3, col);
            Graphic = image;
        }
        public override void Update()
        {
            Y -= (float)(5 / Otter.Rand.Float(1, 3));
            image.Alpha -= 0.05f;
            particleTimer++;
            if (particleTimer >= PARTICLE_FRAMES)
            {
                RemoveSelf();
            }
        }
    }
}