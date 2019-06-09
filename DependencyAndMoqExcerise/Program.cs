using System;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;
using System.IO;
using Castle.Windsor;

namespace DependencyAndMoqExcerise
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/Users/hongle/Projects/DependencyAndMoqExcerise/DependencyAndMoqExcerise/Groups.txt";
            var container = new WindsorContainer();
            container.Register(Component.For<IReadFile>().ImplementedBy<ReadFile>().LifestyleSingleton());
            container.Register(Component.For<IGroups>().ImplementedBy<Groups>());

            var readFile = container.Resolve<IReadFile>();
            var groups = container.Resolve<IGroups>();
            readFile.LoadFromFile(path);

            Console.WriteLine( "Enter Group1, Group2,Group3 for the names in Groups");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "Group1":
                    var names1 = groups.GetAGroup(userInput);
                    foreach(var name in names1)
                    {
                        Console.WriteLine(name);
                    }
                    break;
                case "Group2":
                   var names2 = groups.GetAGroup(userInput);
                    foreach (var name in names2)
                    {
                        Console.WriteLine(name);
                    }
                    break;
                case "Group3":
                    var names3 = groups.GetAGroup(userInput);
                    foreach (var name in names3)
                    {
                        Console.WriteLine(name);
                    }
                    break;
                default:
                    Console.WriteLine("UserInput Invalid.");
                    break;
            }


        }
    }
}
