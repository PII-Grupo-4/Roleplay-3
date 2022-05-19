using System.Collections.Generic;
using System;

namespace RoleplayGame
{
    public class CombatEncounter : Encounter
    {        
        public CombatEncounter (Hero heroe, Enemy enemy) : base(heroe, enemy)
        {
            
        }

        // HeroesWin y Tie los utilizo para realizar test y saber el resultado de la partida
        public bool HeroesWin{ get; private set;}
        public bool Tie{ get; private set;}

        // Un detalle, es que cuando realize tests, me di cuenta que si se inicia un encuentro con un heroe
        // y un ememigo, y ambos tienen el mismo valor de AttackValue y Defense Value, se crea un bucle infifito
        // ya que ninguno de los dos enemigos es atacado con RecieveAttack, porque para realizar un ataque
        // es necesario que el AttackValue sea mayor que el DefenseVAlue.
        // Para solucionarlo decidi agregar un contador de rounds, y si llegaron a los 100 rounds y no hubo ganador
        // termina en empate
        public override void DoEncounter()
        {
            List<Enemy> enemiesInCombat = new List<Enemy>(this.enemies);
            List<Hero> heroesInCombat = new List<Hero>(this.heroes);
            // Después de 100 enfrentamientos, termina en empate
            int roundCounter = 100;

            while (enemiesInCombat.Count != 0 && heroesInCombat.Count != 0 && roundCounter != 0)
            {
                roundCounter --;
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
                                    (hero as Hero).IncreaseVP(enemy.VP);
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
                        if (heroesInCombat.Contains(hero as Hero))
                        {
                            heroesInCombat.Remove(hero as Hero);
                        }
                    }
                }

                foreach (Character enemy in this.enemies)
                {
                    if (enemy.Health == 0)
                    {
                        if (enemiesInCombat.Contains(enemy as Enemy))
                        {
                            enemiesInCombat.Remove(enemy as Enemy);
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
                    (hero as Hero).RestoreVP();
                }
            }


            if (enemiesInCombat.Count == 0)
            {
                HeroesWin = true;
                Console.WriteLine("The Heroes Win");
            }
            else if (heroesInCombat.Count == 0)
            {
                HeroesWin = false;
                Console.WriteLine("The Enemies Win");
            }
            else
            {
                Tie = true;
                Console.WriteLine("The heroes and the enemies tied.");
            }
        }
    }
}