using System;
using System.Linq;
using System.Collections.Generic;

namespace DependencyAndMoqExcerise
{
    public class Groups : IGroups
    {
        IReadFile loadedFile; 

        public Groups(IReadFile loadedFile)
        {
            this.loadedFile = loadedFile;

        }
        public List<string> GetAGroup(string groupName)
        {
            var _allGroups = loadedFile.GetDictionary();

            List<string> value;
           
                if (_allGroups.ContainsKey(groupName))
                {
                _allGroups.TryGetValue(groupName, out value);
                return value;

                } else{
                throw new Exception("Group does not Exist");
                 
                 };
        }

        public Dictionary<string, List<string>> GetAllGroups()
        {
            var _allGroups = loadedFile.GetDictionary();

            return _allGroups;

        }
    }
}
