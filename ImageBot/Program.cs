using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Inicio del bot
Ingrese numero de imagenes a crear");

            string numerodeimagenes = Console.ReadLine();

            //LimpiarCarpeta();  //Generado para limpiar carpeta en posterior uso

            GenerarImagen(Convert.ToInt32(numerodeimagenes));

            //Console.ReadKey();
        }

        private static void GenerarImagen( int numerodeimagenes)
        {
            //dimenciones
            int width = 500, height = 500;

            try
            {
                //bitmap
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    for (int i = 0; i < numerodeimagenes; i++)
                    {
                        //random number
                        Random rand = new Random();
                        //generate random ARGB value
                        int a = rand.Next(256);
                        int r = rand.Next(256);
                        int g = rand.Next(256);
                        int b = rand.Next(256);

                        //create random pixels
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                //set ARGB value
                                bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                            }
                        }
                        //Guardar el bitmap
                        int numerolegible = i + 1;
                        var rutaimagen = @"C:\Users\juane\Desktop\imagenes_prueba\" + numerolegible + ".jpg";

                        Console.WriteLine(numerolegible);
                        bmp.Save(rutaimagen);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ha ocurrido una excepcion {e.ToString()}");
            }
        }


        private static void LimpiarCarpeta()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\juane\Desktop\imagenes_prueba\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

    }
}
