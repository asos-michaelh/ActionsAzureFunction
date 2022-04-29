using System;
using System.Collections.Generic;
using System.Linq;
using ActionsAzureFunction.Model;

namespace ActionsAzureFunction.Domain
{
    public class PairGenerator
    {
        private readonly Random rng;

        public PairGenerator()
        {
            var dateHash = DateTime.Now.ToShortDateString().GetHashCode(); 
            
            rng = new Random(dateHash);
        }

        public List<(Person personOne, Person personTwo)> GetPairs(Team team)
        {
            var teamMembersToPlace = team.teamMembers.Select(person => person.name).ToList();
            var pairs = new List<(Person, Person)>();

            do 
            {
                (Person personOne, Person personTwo) newPair = new();

                var indexOfPersonOne = rng.Next(0, teamMembersToPlace.Count);
                var personOne = teamMembersToPlace[indexOfPersonOne];
                newPair.personOne = new Person(personOne);
                teamMembersToPlace.RemoveAt(indexOfPersonOne);

                if (!teamMembersToPlace.Any())
                {
                    newPair.personTwo = new Person("Al");
                    pairs.Add(newPair);

                    break;
                }

                var indexOfPersonTwo = rng.Next(teamMembersToPlace.Count);
                var personTwo = teamMembersToPlace[indexOfPersonTwo];
                newPair.personTwo = new Person(personTwo);
                teamMembersToPlace.RemoveAt(indexOfPersonTwo);
                
                pairs.Add(newPair);
            } while (teamMembersToPlace.Any());

            return pairs;
        }
    }
}
