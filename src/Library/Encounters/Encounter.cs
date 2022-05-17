using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Encounter
    {
        protected List<IHero> heroes = new List<IHero>{};
        protected List<IEnemy> enemies = new List<IEnemy>{};

        public Encounter (IHero hero, IEnemy enemy)
        {
            this.heroes.Add(hero);
            this.enemies.Add(enemy);
        }

        public void AddCharacter (IHero hero)
        {
            this.heroes.Add(hero);
        }

        public void AddCharacter (IEnemy enemy)
        {
            this.enemies.Add(enemy);
        }

        public void RemoveCharacter (IHero hero)
        {
            if (this.heroes.Contains(hero) && (this.heroes.Count > 1))
            {
                this.heroes.Remove(hero);
            }
        }

        public void RemoveCharacter (IEnemy enemy)
        {
            if (this.enemies.Contains(enemy) && (this.enemies.Count > 1))
            {
                this.enemies.Remove(enemy);
            }
        }

        public abstract void DoEncounter();

    }
}