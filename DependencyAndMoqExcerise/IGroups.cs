using System;
using System.Collections.Generic;

namespace DependencyAndMoqExcerise
{
    public interface IGroups
    {
        List<string> GetAGroup(string groupName);
        Dictionary<string, List<string>> GetAllGroups();
    }
}
