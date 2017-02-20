using System;
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
    class Enemy : Entity
    {
        public const float DEFAULT_SPEED = 3.4f;

        public const int DEFAULT_HEALTH = 4;
        public int health = 1;
        public float speed = 1f;
        public float animationSpeed = 7;
        public float animationSpeed2 = 4;
        public const float MOVE_DISTANCE = 600;

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

            SetHitbox(71, 81, (int)Global.Type.ENEMY);
            BoxCollider collider = new BoxCollider(78, 81, Global.Type.ENEMY);
            AddCollider(collider);
            collider.CenterOrigin();
        }
        public override void Update()
        {
            base.Update();
            
            if(Collider.Overlap(X, Y, Global.Type.ATTACKINGPLAYER ))
            {
                if(Global.attacking == true)
                {
                    Console.Write("test");
                    health--;
                    if(health<=0)
                    {
                        RemoveSelf();
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
            if (distMoved >= MOVE_DISTANCE)
            {
                direction = !direction;
                distMoved = 0f;
            }
        }
    }
}
