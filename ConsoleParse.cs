using System;
using System.Text.RegularExpressions;

namespace ParseData
{
    class ConsoleParse
    {
        private readonly string _datapattern = @"(\d{2}\.\d{4})\,\s(\d{2}\.\d{4})$";
        private string data;
        private string validdata;
        private string[] parseData;

        public void Data()
        {
            Console.WriteLine("Input your data in next format\nxx.xxxx, yy.yyyy");
            SetData();
            GetData();
        }

        private void GetData()
        {
            parseData = validdata.Split(",");
            Console.WriteLine("Your Data:");
            Console.Write($"X: {parseData[0]} Y: {parseData[1]}\n");
        }

        private string SetData()
        {
            data = Console.ReadLine();
            if (Regex.IsMatch(data, _datapattern, RegexOptions.IgnoreCase))
                validdata = data;
            else
            {
                Console.WriteLine("Invalid data!");
                Console.WriteLine("Pleate input your data in next format:\nxx.xxxxx, yy.yyyyy");
                SetData();
            }
            return validdata;
        }
    }
}
