using System;

namespace Stormwater_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var new_pipe = new Pipe();
            
            var new_pipe2 = new Pipe();

            Console.WriteLine($"Pipe Number 1:{new_pipe.Pipe_ID}, Pipe Number 2: {new_pipe2.Pipe_ID}");
        }
    }
}
