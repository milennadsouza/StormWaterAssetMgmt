using System;

namespace Stormwater_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
          
            /* 
            Console.WriteLine($"pipe ID: {new_pipe.Pipe_ID} \n Type: {new_pipe.Pipe_Type} \n Pipe Length: {new_pipe.Pipe_Length} \n Type of Material: {new_pipe.Material} \n Estimated Life: {new_pipe.Est_Life} ");
            */

            Console.WriteLine("Welcome to the Stormwater Asset Management and Reporting");
            Console.WriteLine("----------***********-------------*******");
            Console.WriteLine("Please choose one of the options below");
            Console.WriteLine("0 to Exit");
            Console.WriteLine("1 to Enter New Pipe Information");
            Console.WriteLine("2 to Enter New Manhole Information");
            Console.WriteLine("3 to Get a report on BRE & Details of particular Pipe ");
            Console.WriteLine("4 to Search for an Asset in a particular slope range ");
            Console.WriteLine("5 to Search for Assets based on age");
            Console.WriteLine("6 to Search for Assets near Critical Infrastructures");

            Console.Write("Enter your choice: ");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
                {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("New Pipe Information: ");
                    Console.WriteLine("-----------******------------");
                    Console.WriteLine("Type of Pipe:");

                    var pipetypes = Enum.GetNames(typeof(TypesOfPipes));//pipetypes is now an array of the values in TypesOfPipes enum.
                    for (int i = 0; i < pipetypes.Length; i++)
                    {
                        Console.WriteLine($"{i+1} for {pipetypes[i]}");
                    }
                    var pipetypeselection = Convert.ToInt32(Console.ReadLine());
                    var temppipetypeselected = Enum.Parse<TypesOfPipes>(pipetypes[pipetypeselection-1]);//because array is 0 based index- we can subtract 1 from what user has chosen
                    // get all other field data from user
                    Console.Write("Starting Manhole ID: ");
                    var tempmanholeID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Pipe Length: ");
                    var temppipeLength = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Pipe Depth: ");
                    var tempdepth = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type of Pipe Material :");
                    // get the enums converted to a list in an array and display.
                    var pipematerials = Enum.GetNames(typeof(TypesOfMaterials));
                    for (int i = 0; i < pipematerials.Length;i++)
                    {
                        Console.WriteLine($"{i + 1} for {pipematerials[i]} :");
                    }
                    var selectedpipematerial = Convert.ToInt32(Console.ReadLine());
                    var temppipematerialselected = Enum.Parse<TypesOfMaterials>(pipematerials[selectedpipematerial - 1]);
                    Console.Write(" Slope : ");
                    var tempslope = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Critical Infrastructure : 1 for Yes 2 for No : ");
                    var seltempcriticinfra = Convert.ToInt32(Console.ReadLine());
                    var tempcritinfra = true;
                    if (seltempcriticinfra == 1)
                    {
                        tempcritinfra = true;
                    }
                    else
                    {
                        tempcritinfra = false;
                    }

                    // Get the Critical Structure
                    Console.Write("Critical Structure : 1 for Yes 2 for No : ");
                    var boolstruc = Convert.ToInt32(Console.ReadLine());
                    var tempboolstruc= true;
                    if (boolstruc == 1)
                    {
                        tempboolstruc = true;
                    }
                    else
                    {
                        tempboolstruc = false;
                    }
                    // get the id of the Maintenance Records
                    Console.Write(" Maintenance Records ID: ");
                    var tempmaintid = Convert.ToInt32(Console.ReadLine());


                    //create a new object of type pipe
                    Pipe newPipe = new Pipe()
                    {

                        Pipe_Type = temppipetypeselected, // set it to one of the enum type values.
                        Start_Manhole_ID = tempmanholeID,
                        Pipe_Length = temppipeLength,
                        Depth = tempdepth,
                        Material = temppipematerialselected,// set it to one of the enum type values.
                        Slope = tempslope,
                        Critical_Infrastructure = tempcritinfra,
                        Critical_Structure = tempboolstruc,
                        Maintenance_Records_ID = tempmaintid
                    };
                    //set the est_life using the class method PipeLife
                    newPipe.PipeLife(newPipe.Material);
                    Console.WriteLine("Pipe Information Entered.");

                    Console.WriteLine($"Pipe ID:{newPipe.Pipe_ID}, \n Type of Pipe : {newPipe.Pipe_Type} , Estimated years : {newPipe.Est_Life}");
                    break;
                    
                
            };
            
                    

                  
         

            }

                  
        }
    } 

