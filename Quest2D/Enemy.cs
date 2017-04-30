using Otter;


namespace Quest2D.Entities
{
    class Enemy : Entity
    {
        public const float DEFAULT_SPEED = 3.4f;
        public const int DEFAULT_HEALTH = 4;
        public int health = 4;
        public float speed = 1f;
        public float animationSpeed = 7;
        public float animationSpeed2 = 4;
        public bool direction = true;
        public float distMoved = 0f;


        Spritemap<string> MuffinidleFront = new Spritemap<string>("Assets/MuffinidleFront.png", 78, 79);
        Spritemap<string> MuffinidleBack = new Spritemap<string>("Assets/MuffinidleBack.png", 76, 77);
        Spritemap<string> MuffinidleSide = new Spritemap<string>("Assets/MuffinidleSide.png", 64, 83);
        Spritemap<string> MuffinwalkFront = new Spritemap<string>("Assets/MuffinwalkFront.png", 72, 83);
        Spritemap<string> MuffinwalkBack = new Spritemap<string>("Assets/MuffinwalkBack.png", 72, 81);
        Spritemap<string> MuffinwalkSide = new Spritemap<string>("Assets/MuffinwalkSide.png", 64, 83);

        public Enemy(float x, float y) : base(x, y)
        {
            health = DEFAULT_HEALTH;
            speed = DEFAULT_SPEED;
            MuffinidleFront.Add("MuffinidleFront", "0,1,2,3,4", animationSpeed);
            MuffinidleBack.Add("MuffinidleBack", "0,1,2,3,4", animationSpeed);
            MuffinidleSide.Add("MuffinidleSide", "0,1,2,3,4", animationSpeed);
            MuffinwalkFront.Add("MuffinwalkFront", "0,1,2,3,4,5", animationSpeed2);
            MuffinwalkBack.Add("MuffinwalkBack", "0,1,2,3,4,5", animationSpeed2);
            MuffinwalkSide.Add("MuffinwalkSide", "0,1,2,3,4,5", animationSpeed2);
            AddGraphics(MuffinidleBack, MuffinidleFront, MuffinidleSide, MuffinwalkBack, MuffinwalkFront, MuffinwalkSide);
            MuffinidleBack.Visible = false;
            MuffinidleFront.Visible = false;
            MuffinidleSide.Visible = false;
            MuffinwalkBack.Visible = false;
            MuffinwalkFront.Visible = false;
            MuffinwalkSide.Visible = true;
            MuffinwalkSide.Play("MuffinwalkSide");


            SetHitbox(64, 81, (int)Global.Type.ENEMY);
            BoxCollider collider = new BoxCollider(64, 81, Global.Type.ENEMY);
            AddCollider(collider);
            collider.CenterOrigin();
        }

        public void Death()
        {
            MuffinidleBack.Alpha -= 0.25f;
            MuffinidleFront.Alpha -= 0.25f;
            MuffinidleSide.Alpha -= 0.25f;
            MuffinwalkBack.Alpha -= 0.25f;
            MuffinwalkFront.Alpha -= 0.25f;
            MuffinwalkSide.Alpha -= 0.25f;
            if(MuffinidleBack.Alpha == 0  ||MuffinidleFront.Alpha == 0 ||  MuffinidleSide.Alpha ==0 || MuffinwalkBack.Alpha==0 || MuffinwalkFront.Alpha==0|| MuffinwalkSide.Alpha==0)
            {
                 RemoveSelf();
            }
        }

        public override void Update()
        {
            base.Update();
            GameScene checkScene = (GameScene)Scene;
            if (Collider.Overlap(X, Y, Global.Type.PLAYER))
            {
                if (Global.attacking == true)
                {

                    health--;
                    Global.scor = Global.scor + 30;
                    Global.camShaker.ShakeCamera();
                    DamageText dt = new DamageText(X, Y, "30");
                    Global.Joc.Scene.Add(dt);
                    if (health <= 0)
                    {
                        Death();
                    }
                }
            }

            MuffinwalkSide.FlippedX = direction;
            if (direction)
            {
                X -= speed;
            }
            else
            {
                X += speed;
            }
            distMoved += speed;
            if (checkScene.grid.GetRect(X, Y, X + 64, Y + 81, false))
            {
                direction = !direction;
                distMoved = 0f;
            }
        }
    }
}