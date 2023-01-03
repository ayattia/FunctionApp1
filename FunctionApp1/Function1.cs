using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Sql;

namespace FunctionApp1
{
    public static class Function1
    {
        //[FunctionName("Function1")]
        //public static async Task<IActionResult> Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        //    ILogger log)
        //{
        //    log.LogInformation("C# HTTP trigger function processed a request.");

        //    string name = req.Query["name"];

        //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    dynamic data = JsonConvert.DeserializeObject(requestBody);
        //    name = name ?? data?.name;

        //    string responseMessage = string.IsNullOrEmpty(name)
        //        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
        //        : $"Hello, {name}. This HTTP triggered function executed successfully.";

        //    //log.LogInformation($"Response: {responseMessage}");

        //    return new OkObjectResult(responseMessage);
        //}
        [FunctionName("ToDoTrigger")]
        public static void Run(
            [SqlTrigger("Notifications", ConnectionStringSetting = "SqlConnectionString")]
            IReadOnlyList<SqlChange<Notifications>> changes,
            ILogger logger)
        {
            foreach (SqlChange<Notifications> change in changes)
            {
                Notifications notification = change.Item;
                logger.LogInformation($"Change operation: {change.Operation}");
                logger.LogInformation($"ID: {notification.NotificationID}, Client ID: {notification.ClientID}, Attempts: {notification.AttemptsCount}, Last Attempt: {notification.LastAttempt}, Notification Sent At: {notification.NotificationSentAt}");
            }
        }
    }
}
