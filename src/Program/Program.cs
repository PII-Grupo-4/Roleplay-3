﻿using System;
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
        }
    }
}
