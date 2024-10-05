using ConsoleTables;
using System.Collections.Generic;
using System.Reflection;
namespace CaseStudy.Main
{
    internal class PrettyConsole
    {
        public PrettyConsole() { }

        public void Print(string message,string type)
        {
            type = type.ToLower();
            if (type == "success")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else if(type == "fail")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else if(type == "exception")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        public void Table<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            ConsoleTable table = new ConsoleTable();
            string[] headers = Array.ConvertAll(properties, prop => prop.Name);
            table = new ConsoleTable(headers);

            foreach (var item in list)
            {
                var values = new List<object>();
                foreach (var property in properties)
                {
                    object value = property.GetValue(item, null);
                    values.Add(value);
                }
                table.AddRow(values.ToArray());
            }
            Console.WriteLine(table.ToString());
        }
    }
}

