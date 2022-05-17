using System.Collections.Generic;
using System;

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
            List<IEnemy> enemiesInCombat = new List<IEnemy>(this.enemies);
            List<IHero> heroesInCombat = new List<IHero>(this.heroes);

            while (enemiesInCombat.Count != 0 && heroesInCombat.Count != 0)
            {
                // Enemies atacan heroes
                    // Un solo hero
                if (heroesInCombat.Count == 1)
                {
                    foreach (Character enemy in enemiesInCombat)
                    {
                        if ((heroesInCombat[0] as Character).Health > 0)
                        {
                            (heroesInCombat[0] as Character).ReceiveAttack(enemy.AttackValue);
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
                    int difference = enemiesInCombat.Count - heroesInCombat.Count; // Se utiliza en caso que hayan mas enemies que heroes
                    difference = difference < 0 ? 0 : difference;

                    int counter = enemiesInCombat.Count - difference;

                    for (int i = 0; i < counter; i++)
                    {
                        if ((heroesInCombat[i] as Character).Health > 0)
                        {
                            (heroesInCombat[i] as Character).ReceiveAttack((enemiesInCombat[i + difference] as Character).AttackValue);
                        }
                    }
                }

                // Heroes atacan enemies
                foreach (Character hero in heroesInCombat)
                {
                    if (hero.Health > 0)
                    {
                        foreach(Character enemy in enemiesInCombat)
                        {
                            if (enemy.Health > 0)
                            {
                                enemy.ReceiveAttack(hero.AttackValue);
                                if (enemy.Health == 0)
                                {
                                    (hero as IHero).IncreaseVP(enemy.VP);
                                }
                            }
                        }
                    }
                }

                //Los heroes y enemies muertos se quitan del combate
                foreach (Character hero in this.heroes)
                {
                    if (hero.Health == 0)
                    {
                        if (heroesInCombat.Contains(hero as IHero))
                        {
                            heroesInCombat.Remove(hero as IHero);
                        }
                    }
                }

                foreach (Character enemy in this.enemies)
                {
                    if (enemy.Health == 0)
                    {
                        if (enemiesInCombat.Contains(enemy as IEnemy))
                        {
                            enemiesInCombat.Remove(enemy as IEnemy);
                        }
                    }
                }

            }

            // Si un héroe ha conseguido 5+ (5 o más) VP, se cura.
            foreach (Character hero in this.heroes)
            {
                if (hero.VP >= 5)
                {
                    hero.Cure();
                }
            }


            if (enemiesInCombat.Count != 0)
            {
                Console.WriteLine("The Heroes Win");
            }
            else
            {
                Console.WriteLine("The Enemies Win");
            }
        }
    }
}