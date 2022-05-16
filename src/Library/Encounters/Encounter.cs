using System.Collections.Generic;

namespace RoleplayGame
{
    public interface Encounter
    {
        public List<IHero> Heroes { get;}
        public List<IEnemy> Enemies { get;}
        
        public void DoEncounter();

    }
}