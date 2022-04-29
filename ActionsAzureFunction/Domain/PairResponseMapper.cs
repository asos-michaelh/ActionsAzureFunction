using System.Collections.Generic;
using System.Linq;
using ActionsAzureFunction.Model;

namespace ActionsAzureFunction.Domain
{
    public static class PairResponseMapper
    {
        public static string[][] MapToResponseObject(List<(Person personOne, Person personTwo)> pairs) =>
            pairs.Select(pair => new string[2] { pair.personOne.Name, pair.personTwo.Name }).ToArray();
    }
}
