using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ActionsAzureFunction.Domain;
using ActionsAzureFunction.Model;

namespace ActionsAzureFunction
{
    public static class GetPairs
    {
        [FunctionName("get-pairs")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest request)
        {
            var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var team = JsonConvert.DeserializeObject<Team>(requestBody);

            var pairs = new PairGenerator().GetPairs(team);

            var responseObject = PairResponseMapper.MapToResponseObject(pairs);
            var responseBody = JsonConvert.SerializeObject(responseObject);

            return new OkObjectResult(responseBody);
        }
    }
}
