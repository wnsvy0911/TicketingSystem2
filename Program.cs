using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;


namespace TicketingSystem2
{
    class Program
    {
       private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        static void Main(string[] args)
        {
        /*      string file = "Tickets.csv";
                logger.Info("Program started");
                StreamReader sr = new StreamReader(file);
                List<string> originalFile = new List<string>();
                while (!sr.EndOfStream)
                {
                    originalFile.Add(sr.ReadLine());
                    
                }
                sr.Close(); */
                TicketManager manager = new TicketManager("Tickets.csv");
                manager.loadTicketsFromFile();                
                logger.Info("Program started");

              string choice;
            do
            {
                Console.WriteLine("1) Read data from CSV file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);


                if (choice == "1")
                {
                    // TODO: read data from file
                     // create file from data
                     // read data from file
                    manager.listTickets();
                }
                else if (choice == "2")
                {
                    
                    manager.writeTicketsToFile();
                    manager.createTicket();
                   
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
