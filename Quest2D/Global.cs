using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using Quest2D;
using Quest2D.Entities;
using Quest2D.Util;

namespace Quest2D
{    public class Global
    {
        public static Game Joc = null;
        public static Session PlayerSession;
        public static Player player = null;
        public static bool attacking = false;
        public static bool paused = false;
        public static Music gameMusic = null;
        public const int GRID_WIDTH = 64;
        public const int GRID_HEIGHT = 64;
        public static CameraShaker camShaker = new CameraShaker();
        public enum Type
        {
            PLAYER,
            ATTACKINGPLAYER,
            ENEMY
        }
    }
}
