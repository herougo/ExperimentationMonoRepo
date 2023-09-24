using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("Animal");
        }
    }
    class FlyingAnimal : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("FlyingAnimal");
        }
    }
}
