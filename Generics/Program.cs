using Generics.Model;
using Generics.WithGenerics;
using Generics.WithoutGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            TextFileStorage();

            Console.WriteLine();
            Console.Write("Press Enter to Shut Down......");
            Console.ReadLine();
        }

        private static void TextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logEntries = new List<LogEntry>();

            string peopleFile = @"G:\document\Programing\C#\Generics\Generics\Temp\Person.csv";
            string logFile = @"G:\document\Programing\C#\Generics\Generics\Temp\Logs.csv";

            PopulateList(people, logEntries);

            //********************** With Generics ***************

            GenericTextFileProcessor.SaveData<Person>(people, peopleFile);
            List<Person> peopleList = GenericTextFileProcessor.LoadDataFromFile<Person>(peopleFile);

            GenericTextFileProcessor.SaveData<LogEntry>(logEntries, logFile);
            List<LogEntry> LogList = GenericTextFileProcessor.LoadDataFromFile<LogEntry>(peopleFile);

            foreach (var person in peopleList)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} (IsAlive = {person.IsAlive})");
            }

            foreach (var log in LogList)
            {
                Console.WriteLine($"{log.ErrorCode} : {log.Message} at {log.TimeOfEvent}");
            }

            //**************** Without Generics ********************

            //OriginalTextFileProcessor.SavePeople(people, peopleFile);
            //List<Person> peopleList = OriginalTextFileProcessor.LoadPeople(peopleFile);

            //OriginalTextFileProcessor.SaveLogs(logEntries, logFile);
            //List<LogEntry> LogList = OriginalTextFileProcessor.Loadlogs(logFile);

            //foreach (var person in peopleList)
            //{
            //    Console.WriteLine($"{person.FirstName} {person.LastName} (IsAlive = {person.IsAlive})");
            //}

            //foreach (var log in LogList)
            //{
            //    Console.WriteLine($"{log.ErrorCode} : {log.Message} at {log.TimeOfEvent}");
            //}
        }

        private static void PopulateList(List<Person> persons, List<LogEntry> logEntries)
        {
            persons.Add(new Person { FirstName = "Sagar", LastName = "Kumar" });
            persons.Add(new Person { FirstName = "Rohit", LastName = "Sharma",IsAlive=false });
            persons.Add(new Person { FirstName = "Sushil", LastName = "Kumar" });

            logEntries.Add(new LogEntry { ErrorCode = 221, Message = "Hello World" });
            logEntries.Add(new LogEntry { ErrorCode = 566, Message = "Awsome!" });
            logEntries.Add(new LogEntry { ErrorCode = 4554, Message = "So Much Traffic!!" });
        }
    }
}
