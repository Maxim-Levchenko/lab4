using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace copyfileslab4
{
    internal class Program
    {
        static void Main(string[] arguments)
        {
            if (arguments.Length < 3)
            {
                Console.WriteLine("You wrote less than 3 arguments");
                return;
            }

            string Folder1 = arguments[0];
            string Folder2 = arguments[1];

            if (!Directory.Exists(Folder1))
            {
                Console.WriteLine($"The folder {Folder1} from which we move the files doesn't exist");
                return;
            }

            if (!Directory.Exists(Folder2))
            {
                Console.WriteLine($"The folder {Folder2} in which we move the filed doesn't exist");
                return;
            }

            Console.WriteLine("Get the list of file formats to copy");

            string[] Formats = new string[arguments.Length - 2];
            Array.Copy(arguments, 2, Formats, 0, arguments.Length - 2);

            Console.WriteLine("Get the list of files that match the file formats");

            foreach (string fileFormat in Formats)
            {
                string[] files = Directory.GetFiles(Folder1, fileFormat);

                Console.WriteLine($"Copy the file to the selected folder {Folder2}");
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(Folder2, fileName);
                    File.Copy(file, destFile, true);
                    Console.WriteLine("Delete file from first folder");
                    File.Delete(file);
                }
            }
            Console.WriteLine("Exported successfully if you wrote the file formats");
        }
    }
}
