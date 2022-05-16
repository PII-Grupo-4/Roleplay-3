namespace RoleplayGame
{
    public abstract class Heroe : Character
    {
        public Heroe(string name) : base(name)
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