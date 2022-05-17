namespace RoleplayGame
{
    public class Demon: MagicEnemy
    {

        public Demon(string name) : base(name)
        {
            this.Name = name;
            this.vp = 5;
        }
        
    }
}