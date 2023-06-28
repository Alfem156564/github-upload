using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Core.Contracts;
using TestAzure.Api.Helpers;
using TestAzure.Api.Definition;
using Azure.Messaging.ServiceBus;
using Data.Contracts;

namespace TestAzure.Api.Functions
{
    public class TestServiceBusFunction
    {
        ICommonSerializer _serializer;

        public TestServiceBusFunction(ICommonSerializer serializer)
        {
            _serializer = serializer;
        }


        [FunctionName("TestServiceBus")]
        public async Task<IActionResult> TestServiceBus(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "TEST")] HttpRequest request)
        {
            string ServiceBusConnectString = "Endpoint=sb://dlt-sbrecibos2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=TEHEOrIWuyP9oHPeQ4/rTmjAaygaaESYoEWAuR/TOOY=";
            string QueueName = "Actualizawsi";

            var client = new ServiceBusClient(ServiceBusConnectString);
            var sender = client.CreateSender(QueueName);
            // create a batch 
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
            var res = messageBatch.TryAddMessage(new ServiceBusMessage(_serializer.Serialize(new DaltonToCloudResponse
            {
                daltoncloud = "ok",
                fechaDia = DateTime.Now.ToString("yyyy-MM-dd"),
                hora = DateTime.Now.ToString("HH:mm:ss")
            })));
            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue
                await sender.SendMessagesAsync(messageBatch);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }

            return new OkResult();
        }


        [FunctionName("TestTry")]
        public async Task<IActionResult> TestTry(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "TEST/{intvalue}")] HttpRequest request, 
            int intvalue)
        {
            
            try
            {
                double div = 1 / intvalue;
                return new OkObjectResult("Success");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Failure");
            }
            finally
            {
                Console.WriteLine("TEST");
            }
        }
    }
}
