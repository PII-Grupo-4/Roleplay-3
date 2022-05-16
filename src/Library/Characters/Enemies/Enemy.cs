namespace RoleplayGame
{
    public abstract class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
            this.Name = name;
        }

        public int VP
        {
            get
            {
                return this.vp;
            }
        }
    }
}