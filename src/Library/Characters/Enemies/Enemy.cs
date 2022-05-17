namespace RoleplayGame
{
    public abstract class Enemy : Character, IEnemy
    {
        public Enemy(string name) : base(name)
        {
            
        }
    }
}