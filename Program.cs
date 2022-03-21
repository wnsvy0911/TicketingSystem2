﻿using System;
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
            TicketManager manager = new TicketManager();
            manager.loadTicketsFromFile("bugTicket", "bugTickets.csv");
            manager.loadTicketsFromFile("taskTicket", "taskTickets.csv");
            manager.loadTicketsFromFile("enhancementTicket", "enhancementTickets.csv");
            logger.Info("Program started");

            string typeSelected = "";
            string filename = "";

            do 
            {

                Console.WriteLine("Please Select Type Of Ticket To Manage\n 1 - Bug Tickets\n 2 - Task Tickets\n 3 - Enhancement Tickets");
                string typeChoice = Console.ReadLine();
                if (typeChoice == "1") {
                    typeSelected = "bug";
                    filename = "bugTickets.csv";
                } else if (typeChoice == "2") {
                    typeSelected = "task";
                    filename = "taskTickets.csv";
                } else if (typeChoice == "3") {
                    typeSelected = "enhancements";
                    filename = "enhancementTickets.csv";
                } else {
                    typeSelected = "no Choice";
                }

                string choice;
                if (typeSelected != "no Choice") {

                    do
                    {
                        Console.WriteLine("\n1) List Tickets From File.");
                        Console.WriteLine("2) Create New Ticket And Write To File.");
                        Console.WriteLine("Enter any other key to exit.");
                        choice = Console.ReadLine();
                        logger.Info("User choice: {Choice}", choice);


                        if (choice == "1")
                        {
                        // TODO: read data from file
                        // create file from data
                        // read data from file
                            manager.listTickets(typeSelected);
                        }
                        else if (choice == "2")
                        {
                            if (typeSelected == "bugTicket") {
                                int id = manager.bugTickets[manager.bugTickets.Count - 1].ticketId + 1;
                                manager.bugTickets.Add(BugTicket.createTicket(id));
                                manager.writeTicketsToFile("bugTicket", "bugTickets.csv");
                            } else if (typeSelected == "taskTicket") {
                                int id = manager.taskTickets[manager.taskTickets.Count - 1].ticketId + 1;
                                manager.taskTickets.Add(TaskTicket.createTicket(id));
                                manager.writeTicketsToFile("taskTicket", "taskTickets.csv");
                            } else if (typeSelected == "enhancementTicket") {
                                int id = manager.enhancementTickets[manager.enhancementTickets.Count - 1].ticketId + 1;
                                manager.enhancementTickets.Add(EnhancementTicket.createTicket(id));
                                manager.writeTicketsToFile("enhancementTicket", "enhancementTickets.csv");
                            }
                            manager.writeTicketsToFile(typeSelected, filename);

                        } else {
                            typeSelected = "";
                        }
                    } while (choice == "1" || choice == "2");
                } else {
                    Console.WriteLine("Please Make a Valid Choice");
                    typeSelected = "";
                }
            } while (typeSelected == "");
          
            
        }
    }
}