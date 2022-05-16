using System.Collections.Generic;

namespace RoleplayGame
{
    public class CombatEncounter : Encounter
    {
        private List<IHero> heroes = new List<IHero>{};
        private List<IEnemy> enemies = new List<IEnemy>{};
        
        public CombatEncounter (IHero heroe, IEnemy enemy)
        {
            this.heroes.Add(heroe);
            this.enemies.Add(enemy);
        }


        public List<IHero> Heroes 
        { 
            get
            {
                return this.heroes;
            }
        }

        public List<IEnemy> Enemies 
        { 
            get
            {
                return this.enemies;
            }
        }

        public void DoEncounter()
        {
            // Lógica que permite el combate
        }
    }
}