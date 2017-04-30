using System.Diagnostics;
using Otter;
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
        public static int scor = 0;
        public static CameraShaker camShaker = new CameraShaker();
        public static Stopwatch timpscurs = Stopwatch.StartNew();
        public static int PlayerHealth = 4;
        public enum Type
        {
            PLAYER,
            ATTACKINGPLAYER,
            ENEMY,
            JAKE
        }
    }
}
