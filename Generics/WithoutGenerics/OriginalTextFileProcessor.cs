using Generics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.WithoutGenerics
{
    public class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string FilePath)
        {
            List<Person> output = new List<Person>();

            Person person;

            var lines = System.IO.File.ReadAllLines(FilePath).ToList();
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                person = new Person();
                var vals = line.Split(',');
                person.FirstName = vals[0];
                person.LastName = vals[1];
                person.IsAlive = bool.Parse(vals[2]);

                output.Add(person);
            }

            return output;
        }

        public static List<LogEntry> Loadlogs(string FilePath)
        {
            List<LogEntry> output = new List<LogEntry>();

            LogEntry logs;

            var lines = System.IO.File.ReadAllLines(FilePath).ToList();
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                logs = new LogEntry();
                var vals = line.Split(',');
                logs.ErrorCode = int.Parse( vals[0]);
                logs.Message = vals[1];
                logs.TimeOfEvent = DateTime.Parse(vals[2]);

                output.Add(logs);
            }

            return output;
        }


        public static void SavePeople(List<Person> peoples,string FilePath)
        {
            List<string> Lines = new List<string>();

            Lines.Add("FirstName,LastName,IsAlive");
            foreach (Person people in peoples)
            {
                Lines.Add($"{people.FirstName},{people.LastName},{people.IsAlive}");
            }

            System.IO.File.WriteAllLines(FilePath, Lines);
        }

        public static void SaveLogs(List<LogEntry> logs, string FilePath)
        {
            List<string> Lines = new List<string>();

            Lines.Add("ErrorCode,Message,TimeOfEvent");
            foreach (LogEntry log in logs)
            {
                Lines.Add($"{log.ErrorCode},{log.Message},{log.TimeOfEvent}");
            }
            System.IO.File.WriteAllLines(FilePath, Lines);
        }
    }
}
