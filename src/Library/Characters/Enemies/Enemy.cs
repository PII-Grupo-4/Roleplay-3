namespace RoleplayGame
{
    public abstract class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
            this.Name = name;
        }
    }
}