using System;
using System.Collections.Generic;

namespace DependencyAndMoqExcerise
{
    public interface IReadFile
    {
        string path { get; set; }
        List<string> ReadGroupFile();
        List<string> TrimWhiteSpace(string[] list);
        void AddToDictionary(List<string> list);
        (string, List<string>) SplitArrayContent(string content);
    }
}
