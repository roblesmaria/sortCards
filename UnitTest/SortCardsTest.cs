using cs;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    public class SortCardsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenGivenValidCards_ShouldBeSortedCards()
        {
            //assign
            IList<string> testInput = new List<string>() { "3c", "Js", "2d", "10h", "Kh", "8s", "Ac", "4h" };
            IList<string> expected = new List<string>() { "2d", "8s", "Js", "3c", "Ac", "4h", "10h", "Kh" };

            SortCards sort = new SortCards();

            //act
            var output = sort.SortCardList(testInput);

            //assert
            Assert.That(output, Is.EquivalentTo(expected));
        }

        [Test]
        public void WhenGivenInvalidSuit_ShouldThrowException()
        {
            //assign
            IList<string> testInput = new List<string>() { "3z" };

            SortCards sort = new SortCards();

            //act assert 
            var ex = Assert.Throws<Exception>(() => sort.SortCardList(testInput));
            Assert.That(ex.Message, Is.EqualTo("Card invalid: 3z"));
        }

        [Test]
        public void WhenGivenInvalidCardNumber_ShouldThrowKeyNotFoundException()
        {
            //assign
            IList<string> testInput = new List<string>() { "zd" };

            SortCards sort = new SortCards();

            //act assert
            var ex = Assert.Throws<KeyNotFoundException>(() => sort.SortCardList(testInput));
            Assert.That(ex.Message, Is.EqualTo("The given key 'z' was not present in the dictionary."));
        }

        [Test]
        public void WhenGivenNoCards_ShouldThrowArgumentException()
        {
            //assign
            IList<string> testInput = new List<string>();

            SortCards sort = new SortCards();

            //act assert
            var ex = Assert.Throws<ArgumentException>(() => sort.SortCardList(testInput));
            Assert.That(ex.Message, Is.EqualTo("Card list is invalid."));
        }

        [Test]
        public void WhenGivenNullCards_ShouldThrowNullReferenceException()
        {
            //assign
            SortCards sort = new SortCards();

            //act assert
            var ex = Assert.Throws<NullReferenceException>(() => sort.SortCardList(null));
            Assert.That(ex.Message, Is.EqualTo("Object reference not set to an instance of an object."));
        }
    }
}