﻿using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace performancemessagesender
{
    class Program
    {
        
        // This storage account was created inside a sandbox, so it will be deleted soon,
        // and will not exist in the future.
        const string ServiceBusConnectionString = "Endpoint=sb://salesteamappalvaroruano.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2aRXKaBr6WrBt/MkMe11K3VCn1dJ5ddy8G6xRWO4YNA=";
        const string TopicName = "salesperformancemessages";
        static ITopicClient topicClient;

        static void Main(string[] args)
        {

            Console.WriteLine("Sending a message to the Sales Performance topic...");

            SendPerformanceMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");

        }

        static async Task SendPerformanceMessageAsync()
        {
            // Create a Topic Client here
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            // Send messages.
            try
            {
                // Create and send a message here
                string messageBody = $"Total sales for Brazil in August: $13m.";
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Sending message: {messageBody}");
                await topicClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            // Close the connection to the topic here
            await topicClient.CloseAsync();
        }
    }
}
