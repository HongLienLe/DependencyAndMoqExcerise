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
            readFile.LoadFromFile(path);

            foreach (var thing in readFile.GetDictionary())
            {
                Console.WriteLine(thing);
            }

        }
    }
}
