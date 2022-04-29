using ActionsAzureFunction.Domain;
using ActionsAzureFunction.Model;
using NUnit.Framework;
using System.Linq;

namespace ActionsAzureFunction.Tests
{
    public class PairGeneratorTests
    {
        [Test]
        public void CanGenertatePairs_WithEvenNumberOfPeople()
        {
            // Arrange
            var sut = new PairGenerator();

            var people = new Person[]
            {
                new Person("Jim"),
                new Person("Jane"),
                new Person("John"),
                new Person("Bob"),
            };

            var team = new Team(people);

            // Act
            var result = sut.GetPairs(team);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void CanGenertatePairs_WithOddNumberOfPeople()
        {
            // Arrange
            var sut = new PairGenerator();

            var people = new Person[]
            {
                new Person("Jim"),
                new Person("Jane"),
                new Person("John")
            };

            var team = new Team(people);

            // Act
            var result = sut.GetPairs(team);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.True(result.Any(pair => pair.personTwo.Name == "Al"));
        }
    }
}
