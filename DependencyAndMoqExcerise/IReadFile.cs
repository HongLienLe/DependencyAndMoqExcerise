using System;
using System.Collections.Generic;

namespace DependencyAndMoqExcerise
{
    public interface IReadFile
    {
        void LoadFromFile(string path);
        Dictionary<string, List<string>> GetDictionary();
    }
}
