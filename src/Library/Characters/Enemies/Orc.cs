namespace RoleplayGame
{
    public class Orc: Enemy
    {

        public Orc(string name) : base(name)
        {
            this.Name = name;
            this.vp = 4;
        }
        
    }
}