using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Encounter
    {
        protected List<Hero> heroes = new List<Hero>{};
        protected List<Enemy> enemies = new List<Enemy>{};

        // En un principio se nos ocurrió que el constructor tenga como parámetro dos listas, una
        // con enemigos y otras con heroes. Sin embargo al hacer eso, existe la posibilidad de que 
        // se cree un encuentro sin enemigos o heroes, enviando dos listas vacias.
        // Para solucionarlo decidi hacer que el constructor tenga como parámetro un heroe y un enemigo
        // ,de esta forma si o sí va a haber 1 de cada uno como mínimo. Luego se agregan más enemigos
        // o heroes con los métodos AddCharacter
        // La parte buena de esta opción es que se pueden agregar o eliminar enemigos en un encuentro antes
        // de realizar el DoEncounter.
        public Encounter (Hero hero, Enemy enemy)
        {
            this.heroes.Add(hero);
            this.enemies.Add(enemy);
        }

        public void AddCharacter (Hero hero)
        {
            if (!this.heroes.Contains(hero))
            {
                this.heroes.Add(hero);
            }
        }

        public void AddCharacter (Enemy enemy)
        {
            if(!this.enemies.Contains(enemy))
            {
                this.enemies.Add(enemy);
            }
        }

        public void RemoveCharacter (Hero hero)
        {
            if (this.heroes.Contains(hero) && (this.heroes.Count > 1))
            {
                this.heroes.Remove(hero);
            }
        }

        public void RemoveCharacter (Enemy enemy)
        {
            if (this.enemies.Contains(enemy) && (this.enemies.Count > 1))
            {
                this.enemies.Remove(enemy);
            }
        }

        public abstract void DoEncounter();

    }
}