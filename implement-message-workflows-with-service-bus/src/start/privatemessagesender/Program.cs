﻿using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace privatemessagesender
{
    class Program
    {

        // This storage account was created inside a sandbox, so it will be deleted soon,
        // and will not exist in the future.
        const string ServiceBusConnectionString = "Endpoint=sb://salesteamappalvaroruano.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2aRXKaBr6WrBt/MkMe11K3VCn1dJ5ddy8G6xRWO4YNA=";
        const string QueueName = "salesmessages";
        static IQueueClient queueClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Sending a message to the Sales Messages queue...");

            SendSalesMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");
        }

        static async Task SendSalesMessageAsync()
        {
            // Create a Queue Client here
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            // Send messages.
            try
            {
                // Create and send a message here
                string messageBody = $"$10,000 order for bicycle parts from retailer Adventure Works.";
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Sending message: {messageBody}");

                await queueClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            // Close the connection to the queue here
            await queueClient.CloseAsync();
        }
    }
}
