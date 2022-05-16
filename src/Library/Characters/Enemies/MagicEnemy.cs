namespace RoleplayGame
{
    public abstract class MagicEnemy : MagicCharacter
    {
        public MagicEnemy(string name) : base(name)
        {
            this.Name = name;
        }
    }
}