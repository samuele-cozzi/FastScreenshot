using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace source
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                Console.WriteLine(keyinfo.Key.ToString() + " was pressed");
                Console.WriteLine(keyinfo.Modifiers.ToString() + " was pressed");
                if (keyinfo.Key.ToString() == "P" && keyinfo.Modifiers.ToString() == "Shift"){
                    print_screen();
                    System.Threading.Thread.Sleep(1000);
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }

        static void print_screen(){
            // Start the process... 
            Console.WriteLine("Initializing the variables...");
            Console.WriteLine();
            Bitmap memoryImage;
            memoryImage = new Bitmap(1366, 800);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            // Create graphics 
            Console.WriteLine("Creating Graphics...");
            Console.WriteLine();
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            // Copy data from screen 
            Console.WriteLine("Copying data from screen...");
            Console.WriteLine();
            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            //That's it! Save the image in the directory and this will work like charm. 
            string str = "";
            try
            {
                str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) +
                      @"\Screenshots\" + DateTime.Now.Ticks.ToString() + "_Screenshot.png");
            }
            catch (Exception er)
            {
                Console.WriteLine("Sorry, there was an error: " + er.Message);
                Console.WriteLine();
            }

            // Save it! 
            Console.WriteLine("Saving the image...");
            memoryImage.Save(str);

            // Write the message, 
            Console.WriteLine("Picture has been saved...");
            Console.WriteLine();
        }
    }
}
