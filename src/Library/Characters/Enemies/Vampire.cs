namespace RoleplayGame
{
    public class Vampire: Enemy
    {
        public Vampire(string name) : base(name)
        {
            this.Name = name;
            this.vp = 3;
        }
    }
}