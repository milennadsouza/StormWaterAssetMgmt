using System;
using System.Linq;

namespace Stormwater_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
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
                Console.WriteLine("3 to Get a report on POF for particular Pipe ");
                Console.WriteLine("4 to Search for an Asset in a particular slope range ");
                Console.WriteLine("5 to Search for Assets based on age");
                Console.WriteLine("6 to Search for Assets near Critical Infrastructures");

                Console.Write("Enter your choice: ");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        return; //takes control out of the Main() method
                    case 1:
                        Console.WriteLine("New Pipe Information: ");
                        Console.WriteLine("-----------******------------");
                        Console.WriteLine("Type of Pipe:");
                        var temppipetypeselected = TypesOfPipes.Culvert; //default is set
                        var pipetypes = Enum.GetNames(typeof(TypesOfPipes));//pipetypes is now an array of the values in TypesOfPipes enum.
                        for (int i = 0; i < pipetypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1} for {pipetypes[i]}");
                        }
                        //exception handling
                        try
                        {
                           var pipetypeselection = Convert.ToInt32(Console.ReadLine());
                            temppipetypeselected = Enum.Parse<TypesOfPipes>(pipetypes[pipetypeselection - 1]);//because array is 0 based index- we can subtract 1 from what user has chosen
                        }
                        catch (IndexOutOfRangeException e)
                        {
                        Console.WriteLine($"{e.Message} : Please enter a valid number from 1 to {pipetypes.Length}");
                            // if no break, control then passes to "starting manhole id" basically control flow goes to the next line after all catch blocks have executed.
                            break;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine($"{e.Message} : Please enter a valid number from 1 to {pipetypes.Length}");
                            break; //break causes control after exception to get out of the switch...case block, back to main menu screen.
                        }
                        catch(OverflowException e)
                        {
                            Console.WriteLine($"{e.Message} : Please enter a valid number from 1 to {pipetypes.Length}");
                            break; //break like above, prevents control of program from completely ending. Just gets control out of the switch case loop.
                        }

                        //All exceptions from other inputs are going to be try{} together and catch{} together at the end of section.
                        // get all other field data from user
                        try
                        {

                            Console.Write("Starting Manhole ID: ");
                            var tempmanholeID = Convert.ToInt32(Console.ReadLine());
                            // application exception to make sure a value is entered.
                            if (tempmanholeID < 0)
                            {
                                throw new ArgumentNullException(nameof(Pipe.Start_Manhole_ID));
                            }
                            Console.Write("Pipe Length: ");
                            var temppipeLength = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Pipe Depth: ");
                            var tempdepth = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Type of Pipe Material :");
                            // get the enums converted to a list in an array and display.
                            var pipematerials = Enum.GetNames(typeof(TypesOfMaterials));
                            for (int i = 0; i < pipematerials.Length; i++)
                            {
                                Console.WriteLine($"{i + 1} for {pipematerials[i]} :");
                            }
                            var selectedpipematerial = Convert.ToInt32(Console.ReadLine());
                            if ((selectedpipematerial > pipematerials.Length) | (selectedpipematerial < 0))
                                    {
                               var materexcept = new MaterialRangeException();
                                materexcept.paraminfo = nameof(Pipe.Material);//not hardcoding the name of the parameter that is affected.
                                throw materexcept;
                                    }
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
                            var tempboolstruc = true;
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

                            AssetManagement.CreatePipe(temppipetypeselected, tempmanholeID, temppipeLength, tempdepth, temppipematerialselected, tempslope, tempcritinfra, tempboolstruc, tempmaintid);

                            Console.WriteLine("Pipe Information Entered successfully !");
                            break;
                        }
                        //all catch clauses
                        catch(ArgumentNullException e)
                        {
                            Console.WriteLine($"Value for {e.ParamName} needs to be given");
                            break;
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine($"Data entered incorrectly : {e.Message}");
                            break;
                        }
                        catch(OverflowException e)
                        {
                            Console.WriteLine($"{e.Message} :Please input valid integers and decimals only");
                            break;
                        }
                        catch(MaterialRangeException e)
                        {
                            Console.WriteLine($"{e.Message}, {e.paraminfo}");
                            break;
                        }
                        catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine($"{e.Message} : Please enter a valid number within the range");
                            
                            break;
                        }

                    case 3: //Get a report for POF of a certain Pipe
                        {
                            //Get all the Pipes. Ask User to enter Pipe ID
                            var PipeColl =  AssetManagement.GetAllPipes();
                            foreach(var p in PipeColl) //loop through the entire collection passed back and print it out.
                            {
                                Console.WriteLine($"Pipe ID: {p.Pipe_ID} \n Pipe Life: {p.Est_Life} \n Critical Infrastructure: {p.Critical_Infrastructure} \n Date of Installation: {p.DateOfInstallation} \n Pipe Material {p.Material}");
                                Console.WriteLine("\n");
                                
                            }
                            Console.WriteLine("Please enter Pipe ID");
                            var pipeID = Convert.ToInt32(Console.ReadLine());
                             var reqdPipe = PipeColl.FirstOrDefault(a=>a.Pipe_ID == pipeID);
                            
                            //AssetManagement is a static class. Instance cannot be created. So object reference is not passed in.
                            //Hence we have to pass all the details in to calculate the POF
                            var POF = AssetManagement.CalculatePOF(reqdPipe.DateOfInstallation, reqdPipe.Material, reqdPipe.Depth, reqdPipe.Est_Life);
                            Console.WriteLine($"The POF for Pipe ID: {reqdPipe.Pipe_ID}  is : {POF}");
                            break;
                        }

                };

            }
        }

    }
    
        
} 

