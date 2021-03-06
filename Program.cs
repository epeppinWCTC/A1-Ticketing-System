﻿using System;
using System.Collections.Generic;
using System.IO;

namespace A1_Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;

            do
            {
                 // ask user a question
                Console.WriteLine("Welcome to Ticketing System for Peppin and Son's");
                Console.WriteLine("1) Read Ticket Log.");
                Console.WriteLine("2) Add Tickets to Log.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                            while (!sr.EndOfStream)
                            {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            
                            Console.WriteLine(line);

                            }
                        
                    }else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }else if (choice == "2")
                {
                    
                    //write file or append if file exists
                    StreamWriter sw = new StreamWriter(file, true);
                     for (int i = 0; i < 7; i++)
                    {
                        // ask a question
                        Console.WriteLine("Enter a Ticket (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }
                        // prompt for Ticket ID
                        Console.WriteLine("Enter the Ticket id.");
                        // save the Ticket ID
                        string id = Console.ReadLine();
                        // prompt for Ticket Summary
                        Console.WriteLine("Enter the Ticket Summary.");
                        // save the Ticket Summary
                        string summary = Console.ReadLine();
                        // prompt for status
                        Console.WriteLine("Enter Ticket Status");
                        // save the status
                        string status = Console.ReadLine();
                        // prompt for Priority
                        Console.WriteLine("Enter Ticket Priority");
                        // save the Priority
                        string priority = Console.ReadLine();
                        // prompt for Submitter
                        Console.WriteLine("Enter Ticket Submitter Name (First Last)");
                        // save the Submitter
                        string submitter = Console.ReadLine();
                        // prompt for Assigned
                        Console.WriteLine("Enter Ticket Assigned Name");
                        // save the Assigned
                        string assigned = Console.ReadLine();
                        //Set variables for watching loop
                        string watchingResp;
                        string watchers;
                        List<string> watchingUsers = new List<string>();
                        for (int x = 0; x < 7; x++)
                        {  
                            // prompt for adding watching                  
                            Console.WriteLine("Enter A Watching User? (Y/N)?");
                            watchingResp = Console.ReadLine().ToUpper();
                            if (watchingResp != "Y") {break;}
                            //Prompt for names
                            Console.WriteLine("Enter Watching User's Name (First Last)");
                            watchingUsers.Add(Console.ReadLine());
                        }
                        //join list as string with pipes
                        watchers = string.Join("|", watchingUsers);                    
                                       
                        //write to file
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", id,summary,status,priority,submitter,assigned,watchers);
                    }
                    sw.Close();
                }


            }while (choice == "1" || choice == "2");
        }
    }
}
