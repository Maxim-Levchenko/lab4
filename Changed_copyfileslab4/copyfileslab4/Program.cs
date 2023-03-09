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
                Console.WriteLine("An example of the correct launch of the program: copyfileslab4.exe \"D:\\Documents\" \"D:\\Games\" \"*.txt\" \"*.pptx\"");
                Console.WriteLine("Program execution did not complete successfully");
                Environment.ExitCode = 1;
                return;
            }

            string Folder1 = arguments[0];
            string Folder2 = arguments[1];

            if (!Directory.Exists(Folder1))
            {
                Console.WriteLine($"The folder {Folder1} from which we move the files doesn't exist");
                Console.WriteLine("Program execution did not complete successfully");
                Environment.ExitCode = 1;
                return;
            }

            if (!Directory.Exists(Folder2))
            {
                Console.WriteLine($"The folder {Folder2} in which we move the filed doesn't exist");
                Console.WriteLine("Program execution did not complete successfully");
                Environment.ExitCode = 1;
                return;
            }

            Console.WriteLine("Get the list of file formats to copy");

            string[] Formats = new string[arguments.Length - 2];
            Array.Copy(arguments, 2, Formats, 0, arguments.Length - 2);

            Console.WriteLine("Get the list of files that match the file formats");

            int filesMoved = 0;
            foreach (string fileFormat in Formats)
            {
                Console.WriteLine($"Move files to the selected folder {Folder2}");
                foreach (string file in Directory.EnumerateFiles(Folder1, fileFormat, SearchOption.AllDirectories))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(Folder2, fileName);
                    File.Move(file, destFile);
                    filesMoved++;
                }
            }
            Console.WriteLine($"{filesMoved} files successfully moved to {Folder2}");
            Console.WriteLine("Program execution completed successfully");
            Environment.ExitCode = 0;
        }
    }
}
