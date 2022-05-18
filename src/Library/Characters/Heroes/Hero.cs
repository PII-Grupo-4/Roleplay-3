namespace RoleplayGame
{
    public abstract class Hero : Character, IHero
    {
        public Hero(string name) : base(name)
        {
            this.vp = 0;
        }

        public void IncreaseVP(int VPValue)
        {
            this.vp += VPValue;
        }
    }
}