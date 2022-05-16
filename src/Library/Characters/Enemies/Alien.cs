namespace RoleplayGame
{
    public class Alien: Enemy
    {

        public Alien(string name) : base(name)
        {
            this.Name = name;
            this.vp = 20;
        }
        
    }
}