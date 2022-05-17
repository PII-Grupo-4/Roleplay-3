using System.Collections.Generic;

namespace RoleplayGame
{
    public class CombatEncounter : Encounter
    {        
        public CombatEncounter (IHero heroe, IEnemy enemy) : base(heroe, enemy)
        {
            this.heroes.Add(heroe);
            this.enemies.Add(enemy);
        }

        public override void DoEncounter()
        {
            bool enemiesAlive = true;
            bool heroesAlive = true;

            while (enemiesAlive == true && heroesAlive == true)
            {
                // Enemies atacan heroes
                    // Un solo hero
                if (this.heroes.Count == 1)
                {
                    foreach (Character enemy in this.enemies)
                    {
                        if ((this.heroes[0] as Character).Health > 0)
                        {
                            (this.heroes[0] as Character).ReceiveAttack(enemy.AttackValue);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                    // Más de un hero
                else
                {
                    int difference = this.enemies.Count - this.heroes.Count; // Se utiliza en caso que hayan mas enemies que heroes
                    difference = difference < 0 ? 0 : difference;

                    int counter = this.enemies.Count - difference;

                    for (int i = 0; i < counter; i++)
                    {
                        if ((this.heroes[i] as Character).Health > 0)
                        {
                            (this.heroes[i] as Character).ReceiveAttack((this.enemies[i + difference] as Character).AttackValue);
                        }
                    }
                }

                // Heroes atacan enemies
                foreach (Character hero in this.heroes)
                {
                    if (hero.Health > 0)
                    {
                        foreach(Character enemy in this.enemies)
                        {
                            if (enemy.Health > 0)
                            {
                                enemy.ReceiveAttack(hero.AttackValue);
                                if (enemy.Health == 0)
                                {
                                    // El siguiente bloque se utiliza para analizar si hero es magic o no
                                    var magicOrNot = hero as MagicHero;
                                    if (magicOrNot != null)
                                    {
                                        magicOrNot.IncreaseVP(enemy.VP);
                                    }
                                    else
                                    {
                                        (hero as Hero).IncreaseVP(enemy.VP);
                                    }
                                }
                            }
                        }
                    }
                }

                // Se verifica si aún quedan heroes vivos
                heroesAlive = false; // Tomo por suposición que los heroes están muertos
                foreach(Character hero in this.heroes)
                {
                    if (hero.Health > 0)
                    {
                        heroesAlive = true; // Si alguno está vivo, la suposición es falsa
                        break;
                    }
                }
                
                // Se verifica si aún quedan enemies vivos (en caso que los heroes estén vivos)
                if (heroesAlive == true)
                {
                    enemiesAlive = false;
                    foreach(Character enemy in this.enemies)
                    {
                        if (enemy.Health > 0)
                        {
                            enemiesAlive = true;
                            break;
                        }
                    }
                }
            }

            // Se verifican los heroes que consiguieron 5VP o más y se los cura
            foreach (Character hero in this.heroes)
            {
                if (hero.VP >= 5)
                {
                    hero.Cure();
                }
            }
        }
    }
}