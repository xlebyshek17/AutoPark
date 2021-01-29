using System;
using Autopark.CustomCollection;
using Autopark.Model.Vehicle;

namespace Autopark.Controller
{
    public class StackController
    {
        public static void Start()
        {
            Stack<Vehicle> stack = new Stack<Vehicle>(10);

            for (int i = 0; i < stack.Size; i++)
            {
                stack.Push(new Vehicle() { ModelName = $"Auto #{i + 1}"});
                Console.WriteLine($"{stack.Peek().ModelName,-10} drove into the garage");
            }

            if (stack.IsFull())
                Console.WriteLine("\n\tGarage is full!\n");

            while (stack.Count != 0)
                Console.WriteLine($"{stack.Pop().ModelName, -10} is left the garage");
        }
    }
}
