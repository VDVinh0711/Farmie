


using System.Collections.Generic;

namespace Player
{
    public class LevelPlayer
    {
        public int maxLevel = 5;

        public Dictionary<int, float> Levels = new();

        public LevelPlayer()
        {
            for (int i = 0; i < maxLevel; i++)
            {
                Levels.Add(i,1000*i/2);
            }
        }

    }
}

