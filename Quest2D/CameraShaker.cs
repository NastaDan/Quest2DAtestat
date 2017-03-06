using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using Quest2D;

namespace Quest2D.Util
{
    public class CameraShaker : Entity
    {
        private float priorCameraX = 0f;
        private float priorCameraY = 0f;

        private float shakeTimer = 0f;

        private float shakeFrames = 0f;

        private bool shakeCamera = false;


        public CameraShaker()
        {
        }

        public void ShakeCamera(float shakeDur = 20f)
        {
            if (!shakeCamera)
            {

                priorCameraX = this.Scene.CameraX;
                priorCameraY = this.Scene.CameraY;


                shakeCamera = true;
                shakeFrames = shakeDur;
            }
        }

        public override void Update()
        {
            if (shakeCamera)
            {
                this.Scene.CameraX = priorCameraX + (10 - 6 * 2 * Rand.Float(0, 1));
                this.Scene.CameraY = priorCameraY + (10 - 6 * 2 * Rand.Float(0, 1));

                shakeTimer++;
                if (shakeTimer >= shakeFrames)
                {
                    shakeCamera = false;
                    shakeTimer = 0;
                    shakeFrames = 0;

                    this.Scene.CameraX = priorCameraX;
                    this.Scene.CameraY = priorCameraY;
                }
            }
        }
    }
}