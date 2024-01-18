




namespace Player
{
    public struct PlayerData
    {
        public int Level;
        public float Money;
        public int Experience;
        public float Posx;
        public float Posy;

        public PlayerData(int level, float money, int experience, float posx, float posy)
        {
            Level = level;
            Money = money;
            Experience = experience;
            Posx = posx;
            Posy = posy;
        }
    }
}

