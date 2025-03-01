﻿using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            myPc.turnOn();

            Assert.That(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            
            myPc.installGame(new Game("Final Fantasy XI"));

           

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            myPc.installGame(new Game("Duck Game"));
            myPc.installGame(new Game("Dragon's Dogma: Dark Arisen"));


            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame(new Game("Duck Game"))));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame(new Game("Dragon's Dogma: Dark Arisen"))));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame(new Game("Morrowind"))));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            Computer myPc = new Computer(myPsu, preInstalled);
            List<Game> copyOfPreInstalled = new List<Game>(preInstalled);


            copyOfPreInstalled.Add(new Game("Dwarf Fortress"));
            copyOfPreInstalled.Add(new Game("Baldur's Gate"));
       
           copyOfPreInstalled.ForEach(x => myPc.installGame(x));
            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].name));
        }
    }
}