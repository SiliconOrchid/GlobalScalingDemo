using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GlobalScalingDemo.Function
{
    public class CalculatePrimeNumberFunction
    {
        [FunctionName("CalculatePrimeNumber")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            int primeNumberRangeSize = 500000;
            long result = CountPrimeNumbers(primeNumberRangeSize);

            string currentHostingLocation = Environment.GetEnvironmentVariable("CurrentHostingLocation");

            return new OkObjectResult($"Hello, there are {result} prime numbers in the range 0 - {primeNumberRangeSize}.   This result was calculated in {currentHostingLocation}");
        }

        public long CountPrimeNumbers(int rangeSize)
        {
            return ParallelEnumerable.Range(1, rangeSize)
                .Count(n => Enumerable
                    .Range(2, (int)Math.Sqrt(n) - 1)
                    .All(i => n % i > 0)
                );
        }
    }
}
