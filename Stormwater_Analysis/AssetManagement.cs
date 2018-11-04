using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Stormwater_Analysis
{
    /// <summary>
    /// Static class to handle entry of data and analysis, reports of assets. Defined as default Internal-only visible within this assembly.
    /// </summary>
    static class AssetManagement //a class that is static, will not have any properties,
        // will only have methods to handle all the data gathering and analysis for Pipe and Manhole classes
       
     {
        //static property to be seen and used only within this class. Contains a list of Pipe Objects as a temporary store.
    private static List<Pipe> pipeCollection = new List<Pipe>();

        #region Methods
        public static Pipe CreatePipe(TypesOfPipes temppipetypeselected, int tempmanholeID, decimal temppipeLength,
            int tempdepth, TypesOfMaterials temppipematerialselected, decimal tempslope, bool tempcritinfra,
            bool tempboolstruc, int tempmaintid)
        {

           //create a new object of type pipe
            var newPipe = new Pipe()
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
            newPipe.Est_Life = PipeLife(newPipe.Material);
            // Store this new pipe into the collection created 
            pipeCollection.Add(newPipe);
            return newPipe;
        }
        /// <summary>
        /// PipeLife is a method to calculate and set the life of a pipe based on the pipe material.
        /// </summary>
        /// <param name="mater">provide the type of material from a predefined list of materials</param>
        /// <returns></returns>
        public static int PipeLife(TypesOfMaterials mater)
        {
            var plife = 0;

            switch (mater.ToString())
            {
                case "HDPE":
                case "PVC":
                case "Corrugated_Metal_with_Tar_Lining":
                    plife = 75;
                    break;
                case "Cast_Iron":
                case "Concrete":
                    plife = 60;
                    break;

                case "Masonry":
                case "Corrugated_Iron":
                    plife = 50;
                    break;

                default:
                    break;

            }
            return plife;
        }

        //method to calculate the COF using Critical_Infrastructure, Critical_Structure
        public static decimal CalculateCOF()

        {
            decimal COFValue = 0;


            COFValue = 0;
            return COFValue;
        }


        // Pipe Age / Est_Life gives you a EEL - if EEL is closer to 1 then POF Coeff is higher(worse)
        public static decimal CalculatePOF(DateTime InstallationDate, TypesOfMaterials Material, decimal Depth, int Est_Life)
        {
            decimal material_coeff = 0;
            int pipe_age_value = 0;
            decimal soil_type_value = 0;
            decimal depth_coeff = 0;
            decimal POFValue = 0;
            int pipe_age = 0;
            int est_life = 0;
            int pipe_age_coeff = 0;
            // Array material_arr = Enum.GetNames(typeof(TypesOfMaterials));

            switch (Material.ToString())
            {
                case "HDPE":
                    return material_coeff = 1;
                case "PVC":
                    return material_coeff = 2;
                case "Corrugated_Metal_with_Tar_Lining":
                    return material_coeff = 2;
                case "Masonry":
                    return material_coeff = 3;
                case "Corrugated_Iron":
                    return material_coeff = 3;
                case "Cast_Iron":
                    return material_coeff = 3;
                case "Concrete":
                    return material_coeff = 3;
                default:
                    break;
            }

            //pipe_age_coeff is got by dividing age by the estimated life.
            pipe_age = (DateTime.Today).Year - InstallationDate.Year;
            if (pipe_age / est_life <= 0.2)
            {
                pipe_age_coeff = 1;
            }
            else
            {
                if (pipe_age / est_life > 0.2 && pipe_age / est_life <= 0.5)
                {
                    pipe_age_coeff = 3;
                }
                else
                {
                    if (pipe_age / est_life > 0.5 && pipe_age / est_life <= 0.8)
                    {
                        pipe_age_coeff = 4;
                    }

                    else
                    {
                        if (pipe_age / est_life > 0.8)
                        {
                            pipe_age_coeff = 5;
                        }
                        else
                        {
                            pipe_age_coeff = 0;
                        }
                    }
                }

            }


            // checking the Depth to find the depth coefficient 
            if (Depth > 0 && Depth < 8)
            {
                depth_coeff = 1;
            }
            else
            {
                if (Depth >= 8 && Depth < 12)
                {
                    depth_coeff = 1.5M;
                }
                else
                {
                    if (Depth >= 12 && Depth < 16)
                    {
                        depth_coeff = 2.0M;
                    }
                    else
                    {
                        if (Depth >= 16 && Depth < 20)
                        {
                            depth_coeff = 2.5M;
                        }

                    }

                }
            }

            //get the POF value and pass it back to calling program.
            POFValue = material_coeff + pipe_age_value + soil_type_value + depth_coeff;
            return POFValue;
        }

        //Method to get all the Pipe Information-pass back as an IEnumerable collection.
        public static IEnumerable<Pipe> GetAllPipes()
        {
            return pipeCollection;
        }
        #endregion


    }
}
