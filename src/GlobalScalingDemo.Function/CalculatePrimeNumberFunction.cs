using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;


namespace GlobalScalingDemo.Function
{
    public class CalculatePrimeNumberFunction
    {
        [FunctionName("CalculatePrimeNumber")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            int nthPrimeNumber = 10000;
            long result = FindPrimeNumber(nthPrimeNumber);

            string currentHostingLocation = Environment.GetEnvironmentVariable("CurrentHostingLocation");

            return new OkObjectResult($"Hello, the {nthPrimeNumber}th prime number is  {result}.   This result was calculated in {currentHostingLocation}");
        }

        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                bool isPrime = false;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        isPrime = true;
                        break;
                    }
                    b++;
                }
                if (!isPrime)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
