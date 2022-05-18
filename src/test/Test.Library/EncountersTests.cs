using NUnit.Framework;
using RoleplayGame;
using System;

namespace Test.Library
{
    public class EncountersTests
    {
        private Dwarf dwarfTest;
        private Knight knightTest;
        private Archer archerTest;
        private Wizard wizardTest;

        private Alien alienTest;
        private Demon demonTest;
        private Orc orcTest;
        private Vampire vampireTest;
        private Viking vikingTest;

        
        // En SetUp creamos y armamos heroes y enemies
        [SetUp]
        public void SetUp()
        {
            dwarfTest = new Dwarf("DwarfTest");
            knightTest = new Knight("KnightTest");
            archerTest = new Archer("ArcherTest");
            wizardTest = new Wizard("wizardTest");

            alienTest = new Alien("AlienTest");
            demonTest = new Demon("DemonTest");
            orcTest = new Orc("OrcTest");
            vampireTest = new Vampire("VampireTest");
            vikingTest = new Viking("VikingTest");

            dwarfTest.AddItem(new Axe());
            dwarfTest.AddItem(new Helmet());
            dwarfTest.AddItem(new Shield());
            knightTest.AddItem(new Sword());
            knightTest.AddItem(new Armor());
            archerTest.AddItem(new Bow());
            archerTest.AddItem(new Helmet());
            wizardTest.AddItem(new Staff());

            alienTest.AddItem(new Axe());
            alienTest.AddItem(new Helmet());
            alienTest.AddItem(new Shield());
            demonTest.AddItem(new Staff());
            orcTest.AddItem(new Helmet());
            orcTest.AddItem(new Sword());
            vampireTest.AddItem(new Bow());
            vampireTest.AddItem(new Helmet());
            vikingTest.AddItem(new Sword());
            vikingTest.AddItem(new Armor());
        }


        [Test]
        public void CombatEncounter1vs1()
        {
            CombatEncounter CombatTest = new CombatEncounter(dwarfTest, orcTest);
            CombatTest.DoEncounter();

            Assert.AreEqual(false, CombatTest.HeroesWin);
        }

        [Test]
        public void CombatEncounter1vs3EnemiesWin()
        {
            
            CombatEncounter CombatTest = new CombatEncounter(dwarfTest, orcTest);
            CombatTest.AddCharacter(demonTest);
            CombatTest.AddCharacter(alienTest);

            CombatTest.DoEncounter();

            Assert.AreEqual(false, CombatTest.HeroesWin);
        }

        [Test]
        public void CombatEncounter1vs3HeroWin()
        {
            dwarfTest.AddItem(new Staff());
            CombatEncounter CombatTest = new CombatEncounter(dwarfTest, orcTest);
            CombatTest.AddCharacter(demonTest);
            CombatTest.AddCharacter(alienTest);

            CombatTest.DoEncounter();

            Assert.AreEqual(true, CombatTest.HeroesWin);
        }

        [Test]
        public void CombatEncounter3vs3()
        {
            CombatEncounter CombatTest = new CombatEncounter(dwarfTest, orcTest);
            CombatTest.AddCharacter(knightTest);
            CombatTest.AddCharacter(archerTest);
            CombatTest.AddCharacter(demonTest);
            CombatTest.AddCharacter(alienTest);

            CombatTest.DoEncounter();

            Assert.AreEqual(false, CombatTest.HeroesWin);
        }

        [Test]
        public void CombatEncounter3vs2()
        {
            CombatEncounter CombatTest = new CombatEncounter(dwarfTest, orcTest);
            CombatTest.AddCharacter(knightTest);
            CombatTest.AddCharacter(archerTest);

            CombatTest.DoEncounter();

            Assert.AreEqual(true, CombatTest.HeroesWin);
        }

        // El siguiente test se realiza para el caso en que el personaje más
        // fuerte entre los enemies y entre los heroes tengan los mismo valores
        // de defensa y ataque.
        
        [Test]
        public void CombatEncounter1vs1EqualsValues()
        {
            demonTest.AddItem(new Staff());
            wizardTest.AddItem(new Staff());
            
            Assert.AreEqual(200, wizardTest.DefenseValue);
            Assert.AreEqual(200, wizardTest.DefenseValue);
            Assert.AreEqual(200, demonTest.AttackValue);
            Assert.AreEqual(200, demonTest.AttackValue);

            
            CombatEncounter CombatTest = new CombatEncounter(wizardTest, demonTest);

            CombatTest.DoEncounter();
            Assert.AreEqual(true, CombatTest.Tie);
        }
        
    }
}