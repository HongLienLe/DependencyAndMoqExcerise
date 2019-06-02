using System;
using System.Linq;
using System.Collections.Generic;

namespace DependencyAndMoqExcerise
{
    public class Groups : IGroups
    {
        Dictionary<string, List<string>> AddedGroups = new Dictionary<string, List<string>>();

        public Groups(Dictionary<string,List<string>> AddedGroups)
        {
            this.AddedGroups = AddedGroups;
        }

        public bool DoesKeyExist(string key)
        {
            if (AddedGroups.ContainsKey(key))
            {
                return AddedGroups.ContainsKey(key);
            }

            return false;
        }

        public IEnumerable<string> GetGroup(string groupName)
        {
            List<string> value;
           
                if (DoesKeyExist(groupName))
                {
                AddedGroups.TryGetValue(groupName, out value);
                return value;

                } else{
                throw new Exception("Group does not Exist");
                 
                 };

            
        }

        public List<string> GettingAllNamesFromGroups(IEnumerable<string> groupChoice)
        {
            Queue<string> groupQueue = new Queue<string>() { groupChoice};
            List<string> returnNames = new List<string>();

            while (groupQueue.Count > 0)
            {
                var groupName = groupQueue.Dequeue();
                if (DoesKeyExist(groupName))
                {
                   
                    foreach(var name in AddedGroups[groupName])
                    {
                        if (AddedGroups.ContainsKey(name))
                        {
                            if (!returnNames.Contains(name))
                            {
                                returnNames.Add(name);
                                groupQueue.Enqueue(name);
                            }
                        } else if(returnNames.){

                        }

                    }
                }
            }



            return null;
        }

        public void RemoveGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public void ThrowExceptions(string groupName)
        {
            if (!DoesKeyExist(groupName)){
                            
                    throw new Exception("Group does not exist");
            };
        }
    }
}
