using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            Console.WriteLine($"Gimli's health = {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with {gandalf.AttackValue} of damage");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli's health = {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli's health now = {gimli.Health}");
            

            Dwarf dwarfTest = new Dwarf("DwarfTest");
            Knight knightTest = new Knight("KnightTest");
            Archer archerTest = new Archer("ArcherTest");
            Wizard wizardTest = new Wizard("wizardTest");

            Alien alienTest = new Alien("AlienTest");
            Demon demonTest = new Demon("DemonTest");
            Orc orcTest = new Orc("OrcTest");
            Vampire vampireTest = new Vampire("VampireTest");
            Viking vikingTest = new Viking("VikingTest");

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

            CombatEncounter CombatTest = new CombatEncounter(dwarfTest, orcTest);
            CombatTest.DoEncounter();
        }
    }
}
