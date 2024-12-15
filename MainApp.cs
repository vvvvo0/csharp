using System;

namespace Overriding
{
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            Console.WriteLine("Armored");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Initialize() // override
        {
            base.Initialize() // 들고와서
            Console.WriteLine("Repulsor Rays Armed"); // 개조
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize() // override
        {
            base.Initialize(); // 들고와서
            Console.WriteLine("Double-Barrel Cannons Armed"); // 개조
            Console.WriteLine("Micro-Rocket Launcher Armed"); // 개조
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating ArmorSuite...");
            ArmorSuite armorsuite = new ArmorSuite();
            armorsuite.Initialize();

            Console.WriteLine("\nCreating IronMan...");
            ArmorSuite ironman = new IronMan();
            ironman.Initialize();

            Console.WriteLine("\nCreating WarMaching...");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Initialize();
        }
    }
}

