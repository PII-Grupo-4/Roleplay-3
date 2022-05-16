namespace RoleplayGame
{
    public abstract class MagicHero : MagicCharacter, IHero
    {
        public MagicHero(string name) : base(name)
        {
            this.Name = name;
            this.vp = 0;
        }
        
        public void IncreaseVP(int VPValue)
        {
            this.vp += VPValue;
        }
    }
}