using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace RespaldosTarea
{
    internal class Program
    {


        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            try 
            {
                Console.WriteLine("Respaldo Realizado con exito");
                Console.ReadKey();
                // Get information about the source directory
                var dir = new DirectoryInfo(sourceDir);

                // Check if the source directory exists
                if (!dir.Exists)
                    throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

                // Cache directories before we start copying
                DirectoryInfo[] dirs = dir.GetDirectories();

                // Create the destination directory
                Directory.CreateDirectory(destinationDir);

                // Get the files in the source directory and copy to the destination directory
                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }

                // If recursive and copying subdirectories, recursively call this method
                if (recursive)
                {
                    foreach (DirectoryInfo subDir in dirs)
                    {
                        string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                        CopyDirectory(subDir.FullName, newDestinationDir, true);
                    }
                }

            }catch(Exception e) 
            {
                Console.WriteLine("El proceso fallo: {0}", e.ToString());
                Console.ReadKey();
            }

           

            
        }
            static void Main(string[] args)
        {
            int salir = 0;
            string  basedata = "";
            string tabla = "";
            string opc = "";
            do
            {
                basedata = "";
                tabla = "";
                Console.WriteLine("bases de datos disponibles:\n");
                // DirectoryInfo di = new DirectoryInfo(path);
                string[] folders = Directory.GetDirectories(@"c:\BasesDatos\");
                //Console.WriteLine("No search pattern returns:");
                foreach (string f in folders)
                {
                    Console.WriteLine("" + f.Substring(14)); // Mostramos las carpetas en la consola

                }
                

                Console.WriteLine("\n------------------------------Menu----------------------");
                Console.WriteLine("1) respaldar todas las bases de datos");
                Console.WriteLine("2) Respaldar una base de datos en especifico");
                Console.WriteLine("3) Respaldar tablas");
                opc=Console.ReadLine();
                //     Console.WriteLine("2) Respaldar una base de datos en especifico");




                switch (opc)
                {
                    case "1":



                        //Metodo para respaldar 
                        CopyDirectory(@"C:\BasesDatos", @"C:\respaldos", true);

                        break;
                    case "2":


                        Console.WriteLine("Ingresa el nombre de la base que desea respaldar:");
                        basedata = Console.ReadLine();

                        if (Directory.Exists(@"C:\respaldos\" + basedata))
                        {


                        }
                        else
                        {
                            DirectoryInfo di = Directory.CreateDirectory(@"C:\respaldos\" + basedata);

                        }

                        CopyDirectory(@"C:\BasesDatos\" + basedata, @"C:\respaldos\" + basedata, true);
                        break;
                    case "3":


                        try 
                        {
                            
                            Console.WriteLine("Ingresa el nombre de la base de datos:");
                            basedata = Console.ReadLine();
                            Console.Write("" + basedata);
                            Console.Clear();
                            Console.WriteLine("Tablas presentes en la base de datos " + basedata);

                            // DirectoryInfo di = new DirectoryInfo(path);
                            string[] folderss = Directory.GetFiles(@"c:\BasesDatos\" + basedata);
                            //Console.WriteLine("No search pattern returns:");
                            foreach (string f in folderss)
                            {
                                Console.WriteLine("" + f.Substring(25)); // Mostramos las carpetas en la consola

                            }
                        }
                        catch (Exception e) 
                        {
                            Console.WriteLine("El proceso fallo: {0}", e.ToString());
                            Console.ReadKey();
                        }
                       


                        bool s = false;
                        do
                        {
                            Console.Clear();
                            try
                            {

                               
                                Console.WriteLine("Tablas presentes en la base de datos " + basedata);

                                // DirectoryInfo di = new DirectoryInfo(path);
                                string[] folderss = Directory.GetFiles(@"c:\BasesDatos\" + basedata);
                                //Console.WriteLine("No search pattern returns:");
                                foreach (string f in folderss)
                                {
                                    Console.WriteLine("" + f.Substring(25)); // Mostramos las carpetas en la consola

                                }

                                Console.WriteLine("\n------------------------------Menu----------------------");
                                Console.WriteLine("1) respaldar todas las tablas");
                                Console.WriteLine("2) Respaldar una tabla en especifico");
                                Console.WriteLine("3) Regresar al menu anterior");
                                Console.WriteLine("ingresa una opcion");
                                string opcs = Console.ReadLine();
                                switch (opcs)
                                {
                                    case "1":

                                        if (Directory.Exists(@"C:\respaldos\" + basedata))
                                        {


                                        }
                                        else
                                        {
                                            DirectoryInfo di = Directory.CreateDirectory(@"C:\respaldos\" + basedata);

                                        }

                                        CopyDirectory(@"C:\BasesDatos\" + basedata, @"C:\respaldos\" + basedata, true);
                                        break;

                                    case "2":

                                        Console.WriteLine("Ingresa el nombre de la base que desea respaldar:");
                                        tabla = Console.ReadLine();

                                        if (Directory.Exists(@"C:\respaldos\" + basedata /*"\\"+ tabla*/))
                                        {


                                        }
                                        else
                                        {
                                            DirectoryInfo di = Directory.CreateDirectory(@"C:\respaldos\" + basedata);

                                        }
                                        File.Copy(@"C:\BasesDatos\" + basedata + "\\" + tabla, @"C:\respaldos\" + basedata+ "\\" + tabla) ;

                                        break;

                                    case "3":
                                        s = true;
                                        break;


                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("El proceso fallo: {0}", e.ToString());
                                Console.ReadKey();
                            }
                           

                                    Console.ReadKey();
                        } while (s ==false);
                       
                        break;
                    default:
                        
                        break;
                }

                Console.Clear();    
            } while (salir == 0);
        }
    }
}
