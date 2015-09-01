using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class AnimalShelterTests
    {
        private static readonly string[] _DOG_NAMES =
            {
                "Spike",
                "Spot",
                "Butch",
                "Ol' Yeller",
                "Dog"
            };

        private static readonly string[] _CAT_NAMES =
            {
                "Meg",
                "John",
                "Geoff",
                "Cat",
                "Mouse"
            };

        private static readonly Random _RAND = new Random();


        [TestMethod]
        public void SingleAnimalTests()
        {
            var s = new AnimalShelter();
            var animals = _DOG_NAMES.Select(an => new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Dog, an)).ToList();

            foreach (var a in animals)
            {
                s.Enqueue(a);
            }

            foreach(var a in animals)
            {
                Assert.AreEqual(a, s.Dequeue());
            }

            s = new AnimalShelter();
            animals = _CAT_NAMES.Select(an => new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Cat, an)).ToList();

            foreach (var a in animals)
            {
                s.Enqueue(a);
            }

            foreach (var a in animals)
            {
                Assert.AreEqual(a, s.Dequeue());
            }
        }

        [TestMethod]
        public void InterlacedTests()
        {
            var s = new AnimalShelter();
            var animals = new[]
            {
                new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Dog, "Dog 1"),//0
                new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Dog, "Dog 2"),//1
                new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Cat, "Cat 1"),//2
                new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Cat, "Cat 2"),//3
                new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Dog, "Dog 3"),//4
                new AnimalShelter.AnimalNode(AnimalShelter.AnimalType.Cat, "Cat 3") //5
            };

            foreach(var a in animals)
            {
                s.Enqueue(a);
            }
            
            Assert.AreEqual(animals[0], s.Dequeue());
            Assert.AreEqual(animals[2], s.Dequeue(AnimalShelter.AnimalType.Cat));
            Assert.AreEqual(animals[1], s.Dequeue(AnimalShelter.AnimalType.Dog));
            Assert.AreEqual(animals[4], s.Dequeue(AnimalShelter.AnimalType.Dog));
            Assert.AreEqual(animals[3], s.Dequeue());
            Assert.AreEqual(animals[5], s.Dequeue(AnimalShelter.AnimalType.Cat));
            Assert.IsTrue(s.IsEmpty);
        }
    }
}
