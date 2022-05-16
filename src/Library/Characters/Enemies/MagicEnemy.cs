namespace RoleplayGame
{
    public abstract class MagicEnemy : MagicCharacter, IEnemy
    {
        public MagicEnemy(string name) : base(name)
        {
            this.Name = name;
        }
    }
}