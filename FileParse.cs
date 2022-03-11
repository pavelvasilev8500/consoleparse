using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ParseData
{
    class FileParse
    {
        ManagerData managerData = new ManagerData();

        private readonly string _datapattern = @"(\d{2}\.\d{4})\,\s(\d{2}\.\d{4})$";
        private List<string> data = new List<string>();
        private List<string> validdata = new List<string>();
        private int index = 0;

        public void Data(string PATH)
        {
            SetData(PATH);
            GetData();
        }

        private void GetData()
        {
            Console.WriteLine("Your Data:");
            foreach (var vd in validdata)
            {
                var parseData = vd.Split(",");
                Console.Write($"X: {parseData[0]} Y: {parseData[1]}\n");
            }
        }

        private List<string> SetData(string PATH)
        {
            if (File.Exists(PATH))
            {
                using (StreamReader stream = new StreamReader(PATH))
                {
                    while (!stream.EndOfStream)
                    {
                        data.Add(stream.ReadLine());
                    }
                }
                foreach (var d in data)
                {
                    index++;
                    if (Regex.IsMatch(d, _datapattern, RegexOptions.IgnoreCase))
                    {
                        validdata.Add(d);
                    }
                    else
                    {
                        Console.WriteLine("Warnin! Invalind value!");
                        Console.WriteLine($"{index}: {d}");
                    }
                }
                return validdata;
            }
            else
            {
                Console.WriteLine("File not fund!\nСheck the file availability or path to file!");
                managerData.Manager();
                return null;
            }
        }
    }
}
