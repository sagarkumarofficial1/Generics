using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.WithGenerics
{
    public class GenericTextFileProcessor
    {
        public static List<T> LoadDataFromFile<T>(string filePath) where T : class,new()
        {
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            List<T> Output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            if (lines.Count < 2)
            {
                throw new IndexOutOfRangeException("The File is Empty or Not Found");
            }

            var headers = lines[0].Split(',');

            lines.RemoveAt(0);

            foreach (var row in lines)
            {
                entry = new T();

                var vals = row.Split(',');

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                        }
                    }
                }
                Output.Add(entry);
            }

            return Output;
        }
        public static void SaveData<T>(List<T> Data,string FilePath) where T : class
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (Data == null || Data.Count == 0)
            {
                throw new ArgumentNullException("Data", "Data must be populated with atleast one value");
            }

            var cols = Data[0].GetType().GetProperties();

            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(",");
            }

            lines.Add(line.ToString().Substring(0,line.Length - 1));

            foreach (var row in Data)
            {
                line = new StringBuilder();

                foreach (var col in cols)
                {
                     line.Append(col.GetValue(row));
                    line.Append(",");
                }

                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }
            System.IO.File.WriteAllLines(FilePath, lines);
        }
    }
}
