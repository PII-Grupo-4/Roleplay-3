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
            while (this.enemies.Count != 0 && this.heroes.Count != 0)
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
                        if (hero.VP >= 5)
                        {
                            hero.Cure();
                        }
                        RemoveCharacter(hero as IHero);
                    }
                }

                foreach (Character enemy in this.enemies)
                {
                    if (enemy.Health == 0)
                    {
                        RemoveCharacter(enemy as IEnemy);
                    }
                }

            }

            // En caso de que queden heroes vivos, si tienen >= 5VP se los cura 
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