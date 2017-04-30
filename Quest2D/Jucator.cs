using Otter;
using Quest2D.Effects;


namespace Quest2D.Entities
{
    public class Player : Entity
    {
        public float MoveSpeed = 5.0f;
        public const float DIAGONAL_SPEED = 1.4f;
        public bool movement = false;
        public float animationSpeed = 7;
        public float animationSpeed2 = 4;
        public const int WIDTH = 60;
        public const int HEIGHT = 81;
        public const float TIMER_BLINK = 90f;
        public float blinkTimer = 60;

        enum FacingPosition
        {
            Front,
            Back,
            Left,
            Right,
            Idle
        }


        Spritemap<string> idleFront = new Spritemap<string>("Assets/idleFront.png", 64, 79);
        Spritemap<string> idleBack = new Spritemap<string>("Assets/idleBack.png", 64, 77);
        Spritemap<string> idleSide = new Spritemap<string>("Assets/idleSide.png", 44, 83);
        Spritemap<string> runBack = new Spritemap<string>("Assets/runBack.png", 76, 81);
        Spritemap<string> runFront = new Spritemap<string>("Assets/runFront.png", 80, 81);
        Spritemap<string> runSide = new Spritemap<string>("Assets/runSide.png", 64, 87);
        Spritemap<string> attackBack = new Spritemap<string>("Assets/attackBack.png", 140, 135);
        Spritemap<string> attackFront = new Spritemap<string>("Assets/attackFront.png", 124, 147);
        Spritemap<string> attackSide = new Spritemap<string>("Assets/attackSide.png", 162, 121);
        FacingPosition direction = FacingPosition.Idle;
        BoxCollider player = new BoxCollider(63, 81, Global.Type.PLAYER);
        BoxCollider playerattacking = new BoxCollider(140, 130, Global.Type.PLAYER);

        public Player(float x = 0, float y = 0)
        {
            X = x;
            Y = y;

            idleFront.Add("idleFront", "0,1,2,3,4,5,6", animationSpeed);
            idleBack.Add("idleBack", "0,1,2,3,4,5,6", animationSpeed);
            idleSide.Add("idleSide", "0,1,2,3,4,5,6", animationSpeed);
            runFront.Add("runFront", "0,1,2,3,4,5,6,7,8,9", animationSpeed2);
            runBack.Add("runBack", "0,1,2,3,4,5,6,7,8,9", animationSpeed2);
            runSide.Add("runSide", "0,1,2,3,4,5,6,7,8,9", animationSpeed2);
            attackBack.Add("attackBack", "0,1,2,3,4,5,6", animationSpeed);
            attackFront.Add("attackFront", "0,1,2,3,4,5,6", animationSpeed);
            attackSide.Add("attackSide", "0,1,2,3,4,5,6", animationSpeed);
            AddGraphics(idleBack, idleFront, idleSide, runFront, runBack, runSide, attackFront, attackSide, attackBack);

            idleFront.Visible = true;
            idleBack.Visible = false;
            idleSide.Visible = false;
            runFront.Visible = false;
            runBack.Visible = false;
            runSide.Visible = false;
            attackBack.Visible = false;
            attackFront.Visible = false;
            attackSide.Visible = false;
            idleFront.Play("idleFront");

            SetHitbox(63, 81, (int)Global.Type.PLAYER);
            SetHitbox(140, 130, (int)Global.Type.ATTACKINGPLAYER);
            AddColliders(player, playerattacking);
            SetCollider(player);
            player.CenterOrigin();


        }
        public override void Update()
        {
            base.Update();

            SetCollider(player);

            float xSpeed = 0;
            float ySpeed = 0;
            float newX;
            float newY;

            GameScene checkScene = (GameScene)Scene;

            if (Global.attacking)
            {
                SetCollider(playerattacking);
            }
            else
            {
                SetCollider(player);
            }

            if (Collider.Overlap(X, Y, Global.Type.ENEMY) && !Global.attacking)
            {
                blinkTimer++;
                if (blinkTimer >= TIMER_BLINK)
                {
                    Global.PlayerHealth--;
                    blinkTimer = 0;
                    Global.camShaker.ShakeCamera(10);
                }
            }


            if (Global.PlayerSession.Controller.Button("Attack").Pressed)
            {
                idleFront.Visible = false;
                idleBack.Visible = false;
                idleSide.Visible = false;
                runFront.Visible = false;
                runBack.Visible = false;
                runSide.Visible = false;
                attackBack.Visible = false;
                attackFront.Visible = false;
                attackSide.Visible = false;
                movement = false;
                Global.camShaker.ShakeCamera();
                    switch (direction)
                    {
                        case FacingPosition.Front:
                        {
                            Global.attacking = true;
                            idleFront.Visible = false;
                            idleBack.Visible = false;
                            idleSide.Visible = false;
                            runFront.Visible = false;
                            runBack.Visible = false;
                            runSide.Visible = false;
                            attackBack.Visible = true;
                            attackFront.Visible = false;
                            attackSide.Visible = false;
                            attackBack.Play("attackBack");
                            Global.camShaker.ShakeCamera();
                            break;
                        }
                        case FacingPosition.Back:
                        {
                            Global.attacking = true;
                            idleFront.Visible = false;
                            idleBack.Visible = false;
                            idleSide.Visible = false;
                            runFront.Visible = false;
                            runBack.Visible = false;
                            runSide.Visible = false;
                            attackBack.Visible = false;
                            attackFront.Visible = true;
                            attackSide.Visible = false;
                            attackFront.Play("attackFront");
                            Global.camShaker.ShakeCamera();
                            break;
                        }
                        case FacingPosition.Left:
                        {
                            Global.attacking = true;
                            idleFront.Visible = false;
                            idleBack.Visible = false;
                            idleSide.Visible = false;
                            runFront.Visible = false;
                            runBack.Visible = false;
                            runSide.Visible = false;
                            attackBack.Visible = false;
                            attackFront.Visible = false;
                            attackSide.Visible = true;
                            attackSide.Play("attackSide");
                            attackSide.FlippedX = true;
                            Global.camShaker.ShakeCamera();
                            break;
                        }
                        case FacingPosition.Right:
                        {
                            Global.attacking = true;
                            idleFront.Visible = false;
                            idleBack.Visible = false;
                            idleSide.Visible = false;
                            runFront.Visible = false;
                            runBack.Visible = false;
                            runSide.Visible = false;
                            attackBack.Visible = false;
                            attackFront.Visible = false;
                            attackSide.Visible = true;
                            attackSide.Play("attackSide");
                            attackSide.FlippedX = false;
                            Global.camShaker.ShakeCamera();
                            break;
                        }
                     }
            }
            if (Global.PlayerSession.Controller.Button("Attack").Released)
            {
                SetCollider(player);
                switch (direction)
                {
                    case FacingPosition.Front:
                    {
                        Global.attacking = false;
                        idleFront.Visible = false;
                        idleBack.Visible = true;
                        idleSide.Visible = false;
                        runFront.Visible = false;
                        runBack.Visible = false;
                        runSide.Visible = false;
                        attackBack.Visible = false;
                        attackFront.Visible = false;
                        attackSide.Visible = false;
                        idleBack.Play("idleBack");
                        break;
                    }
                    case FacingPosition.Back:
                    {
                        Global.attacking = false;
                        idleFront.Visible = true;
                        idleBack.Visible = false;
                        idleSide.Visible = false;
                        runFront.Visible = false;
                        runBack.Visible = false;
                        runSide.Visible = false;
                        attackBack.Visible = false;
                        attackFront.Visible = false;
                        attackSide.Visible = false;
                        idleFront.Play("idleFront");
                        break;
                    }
                    case FacingPosition.Left:
                    {
                        Global.attacking = false;
                        idleFront.Visible = false;
                        idleBack.Visible = false;
                        idleSide.Visible = true;
                        runFront.Visible = false;
                        runBack.Visible = false;
                        runSide.Visible = false;
                        attackBack.Visible = false;
                        attackFront.Visible = false;
                        attackSide.Visible = false;
                        idleSide.Play("idleSide");
                        idleSide.FlippedX = true;
                        break;
                    }
                    case FacingPosition.Right:
                    {
                        Global.attacking = false;
                        idleFront.Visible = false;
                        idleBack.Visible = false;
                        idleSide.Visible = true;
                        runFront.Visible = false;
                        runBack.Visible = false;
                        runSide.Visible = false;
                        attackBack.Visible = false;
                        attackFront.Visible = false;
                        attackSide.Visible = false;
                        idleSide.Play("idleSide");
                        idleSide.FlippedX = false;
                        break;
                    }
                }
            }
            if (Global.attacking == false)
            {
                if (Global.PlayerSession.Controller.Button("Up").Down)
                {
                    newY = Y - MoveSpeed;
                    if (!checkScene.grid.GetRect(X, newY, X + WIDTH, newY + HEIGHT, false))
                    {
                        ySpeed = -MoveSpeed;
                        if (Collider.Overlap(X, Y, Global.Type.ENEMY))
                        {
                            ySpeed = ySpeed / 2;
                        }
                    }

                }
                if (Global.PlayerSession.Controller.Button("Left").Down)
                {
                    newX = X - MoveSpeed;
                    if (!checkScene.grid.GetRect(newX, Y, newX + WIDTH, Y + HEIGHT, false))
                    {
                        xSpeed = -MoveSpeed;
                        if (Collider.Overlap(X, Y, Global.Type.ENEMY))
                        {
                            xSpeed = xSpeed / 2;
                        }
                    }
                }
                if (Global.PlayerSession.Controller.Button("Right").Down)
                {
                    newX = X + MoveSpeed;
                    if (!checkScene.grid.GetRect(newX, Y, newX + WIDTH, Y + HEIGHT, false))
                    {
                        xSpeed = MoveSpeed;
                        if (Collider.Overlap(X, Y, Global.Type.ENEMY))
                        {
                            xSpeed = xSpeed / 2;
                        }
                    }
                }
                if (Global.PlayerSession.Controller.Button("Down").Down)
                {
                    newY = Y + MoveSpeed;
                    if (!checkScene.grid.GetRect(X, newY, X + WIDTH, newY + HEIGHT, false))
                    {
                        ySpeed = MoveSpeed;
                        if (Collider.Overlap(X, Y, Global.Type.ENEMY))
                        {
                            ySpeed = ySpeed / 2;
                        }
                    }
                }

                if (Global.PlayerSession.Controller.Button("Left").Pressed)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = false;
                    idleSide.Visible = false;
                    runFront.Visible = false;
                    runBack.Visible = false;
                    runSide.Visible = true;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    runSide.Play("runSide");
                    runSide.FlippedX = true;
                    movement = true;
                    direction = FacingPosition.Left;
                }
                else if (Global.PlayerSession.Controller.Button("Right").Pressed)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = false;
                    idleSide.Visible = false;
                    runFront.Visible = false;
                    runBack.Visible = false;
                    runSide.Visible = true;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    runSide.Play("runSide");
                    runSide.FlippedX = false;
                    movement = true;
                    direction = FacingPosition.Right;
                }
                else if (Global.PlayerSession.Controller.Button("Up").Pressed)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = false;
                    idleSide.Visible = false;
                    runFront.Visible = false;
                    runBack.Visible = true;
                    runSide.Visible = false;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    runBack.Play("runBack");

                    movement = true;
                    direction = FacingPosition.Front;
                }
                else if (Global.PlayerSession.Controller.Button("Down").Pressed)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = false;
                    idleSide.Visible = false;
                    runFront.Visible = true;
                    runBack.Visible = false;
                    runSide.Visible = false;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    runFront.Play("runFront");

                    movement = true;
                    direction = FacingPosition.Back;
                }

                if (Global.PlayerSession.Controller.Button("Left").Released && ySpeed == 0 && xSpeed == 0)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = false;
                    idleSide.Visible = true;
                    runFront.Visible = false;
                    runBack.Visible = false;
                    runSide.Visible = false;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    idleSide.Play("idleSide");
                    idleSide.FlippedX = true;
                    movement = false;

                }
                else if (Global.PlayerSession.Controller.Button("Right").Released && ySpeed == 0 && xSpeed == 0)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = false;
                    idleSide.Visible = true;
                    runFront.Visible = false;
                    runBack.Visible = false;
                    runSide.Visible = false;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    idleSide.Play("idleSide");
                    idleSide.FlippedX = false;
                    movement = false;

                }
                else if (Global.PlayerSession.Controller.Button("Up").Released && ySpeed == 0 && xSpeed == 0)
                {
                    idleFront.Visible = false;
                    idleBack.Visible = true;
                    idleSide.Visible = false;
                    runFront.Visible = false;
                    runBack.Visible = false;
                    runSide.Visible = false;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    idleBack.Play("idleBack");
                    movement = false;

                }
                else if (Global.PlayerSession.Controller.Button("Down").Released && ySpeed == 0 && xSpeed == 0)
                {
                    idleFront.Visible = true;
                    idleBack.Visible = false;
                    idleSide.Visible = false;
                    runFront.Visible = false;
                    runBack.Visible = false;
                    runSide.Visible = false;
                    attackBack.Visible = false;
                    attackFront.Visible = false;
                    attackSide.Visible = false;
                    idleFront.Play("idleFront");
                    movement = false;

                }
            }
            if (movement == true)
            {

                float particleXBuffer = 0;
                float particleYBuffer = 0;
                switch (direction)
                {
                    case FacingPosition.Front:
                        {
                            particleXBuffer = Rand.Float(8, 24);
                            particleYBuffer = Rand.Float(0, 5);
                            Global.Joc.Scene.Add(new WalkParticle(X + 20 + particleXBuffer, Y + 40));
                            break;
                        }
                    case FacingPosition.Back:
                        {
                            particleXBuffer = Rand.Float(8, 24);
                            Global.Joc.Scene.Add(new WalkParticle(X + 20 + particleXBuffer, Y - 5));
                            break;
                        }
                    case FacingPosition.Left:
                        {
                            particleYBuffer = Rand.Float(-5, 5);
                            Global.Joc.Scene.Add(new WalkParticle(X + 48, Y + 40 + particleYBuffer));
                            break;
                        }
                    case FacingPosition.Right:
                        {
                            particleYBuffer = Rand.Float(-5, 5);
                            Global.Joc.Scene.Add(new WalkParticle(X + 3, Y + 40 + particleYBuffer));
                            break;
                        }
                }
            }
            if (Global.PlayerSession.Controller.Button("Up").Down && Global.PlayerSession.Controller.Button("Left").Down
                || Global.PlayerSession.Controller.Button("Up").Down && Global.PlayerSession.Controller.Button("Right").Down
                || Global.PlayerSession.Controller.Button("Down").Down && Global.PlayerSession.Controller.Button("Left").Down
                || Global.PlayerSession.Controller.Button("Down").Down && Global.PlayerSession.Controller.Button("Right").Down)
            {
                X += xSpeed / DIAGONAL_SPEED;
                Y += ySpeed / DIAGONAL_SPEED;
            }
            else
            {
                    X += xSpeed;
                    Y += ySpeed;
            }
        }
    }
}