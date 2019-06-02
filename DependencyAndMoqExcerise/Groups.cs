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
        public List<string> GetGroup(string groupName)
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
    }
}
