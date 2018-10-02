using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda
{
    public class Contract1
    {
        [JsonProperty(PropertyName = "First")] public string First { get; set; }

        [JsonProperty(PropertyName = "Sec")] public string Sec { get; set; }

        [JsonProperty(PropertyName = "Third")] public string Third { get; set; }
    }

    public class Function
    {
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            context.Logger.Log("MYSTART\n");
            context.Logger.Log(input.Body);
            context.Logger.Log("MYEND\n");

            if (input.HttpMethod == "POST")
            {
                var shitstick = JsonConvert.DeserializeObject<Contract1>(input.Body);
                APIGatewayProxyResponse response = new APIGatewayProxyResponse()
                {
                    Body = shitstick.First
                };

                return response;
            }
            else
            {
                return new APIGatewayProxyResponse()
                    { Body =  input.HttpMethod};
            }
        }
    }
}