using System;
using Autopark.CustomCollection;
using Autopark.Model.Vehicle;

namespace Autopark.Controller
{
    public class QueueController
    {
        public static void Start()
        {
            Queue<Vehicle> queue = new Queue<Vehicle>(10);

            for (int i = 0; i < queue.Size; i++)
            {
                queue.Enqueue(new Vehicle() { ModelName = $"Auto #{i + 1}" });
            }

            queue.Enqueue(new Vehicle() { ModelName = $"Auto #new" });

            while (queue.Count != 0)
            {
                var vehicle = queue.Dequeue();
                Console.WriteLine($"{ vehicle.ModelName,-10 } is washed up");
            }
        }
    }
}
