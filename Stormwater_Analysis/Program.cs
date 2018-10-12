using System;

namespace Stormwater_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var new_pipe = new Pipe //create a new object initialization
            {
                Pipe_Type = TypesOfPipes.Mains, // set it to one of the enum type values.
                DateOfInstallation = DateTime.Now,
                Material = TypesOfMaterials.Concrete, // set it to one of the enum type values.
                Depth =  20,
                Critical_Infrastructure = true,
                Critical_Structure = false,
                Pipe_Length = 500,
               
                
            };
            new_pipe.Est_Life = new_pipe.PipeLife(new_pipe.Material);






            var new_pipe2 = new Pipe();

            Console.WriteLine($"Pipe Number 1:{new_pipe.Pipe_ID},  Type of Pipe : {new_pipe.Pipe_Type} , Estimated years : {new_pipe.Est_Life} / n Pipe Number 2: {new_pipe2.Pipe_ID}");
        }
    } 
}
