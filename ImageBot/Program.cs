using System;
using System.Drawing;
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

            LimpiarCarpeta();

            GenerarImagen(Convert.ToInt32(numerodeimagenes));

            //Console.ReadKey();
        }

        private static void GenerarImagen( int numerodeimagenes)
        {
            //dimenciones
            int width = 1000, height = 1000;

            try
            {
                //bitmap
                Bitmap bmp = new Bitmap(width, height);
                
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
                    var rutaimagen = @"C:\Users\juane\Desktop\imagenes_prueba\"+ i.ToString()+ ".jpg";

                    bmp.Save(rutaimagen);
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
