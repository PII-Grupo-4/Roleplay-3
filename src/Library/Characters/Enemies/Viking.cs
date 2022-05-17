namespace RoleplayGame
{
    public class Viking: Enemy
    {
        public Viking(string name) : base(name)
        {
            this.Name = name;
            this.vp = 2;
        }  
    }
}