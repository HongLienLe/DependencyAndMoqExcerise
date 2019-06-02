using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;


namespace DependencyAndMoqExcerise
{
    public class ReadFile : IReadFile
    {
        private static Dictionary<string, List<string>> _allGroups = new Dictionary<string, List<string>>();

        public void LoadFromFile(string path)
        {
            var readFile = ReadGroupFile(path);
            AddToDictionary(readFile); 
        }


        public Dictionary<string, List<string>> GetDictionary()
        {
            return _allGroups;
        }

        public List<string> ReadGroupFile(string path)
        {
            FileInfo file = new FileInfo(path);
            List<string> lines = new List<string>();
            string line;
            using (var reader = new StreamReader(file.FullName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;

        }

        public void AddToDictionary(List<string> list)
        {
            foreach(var content in list)
            {
                var keyAndValues = SplitArrayContent(content);
                _allGroups.Add(keyAndValues.Item1, keyAndValues.Item2);

            }

        }

        public List<string> TrimWhiteSpace(string[] list)
        {
            List<string> newList = new List<string>();
            foreach (var name in list)
            {
                var tidyName = name.Trim();
                newList.Add(tidyName);
            }

            return newList;
        }

        public (string, List<string>) SplitArrayContent(string content)
        {

            char[] firstSplitChar = { '-', '>' };
            char[] secondSplitChar = {'[', ']', ','};
            var splitLine = content.Split(firstSplitChar);

            string key = splitLine[0].Replace('\"',' ').Trim();


            Console.WriteLine(key);
            var replacingCharInString = splitLine[2].Replace('[', ' ').Replace(']', ' ').Replace('\"',' ').Split(',');

            var newList = TrimWhiteSpace(replacingCharInString);

            return (key, newList);
        }
    }
}
