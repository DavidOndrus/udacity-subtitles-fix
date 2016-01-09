using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace FixUdacitySubs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Subtitles fix for UDACITY";

            Console.WriteLine("***********************************************************");
            Console.WriteLine("************     Subtitles fix for UDACITY     ************");
            Console.WriteLine("************              by banyy             ************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("****** HOW TO:");
            Console.WriteLine("****** 1. Copy this program into the root directory of your srt files");
            Console.WriteLine("****** 2. Run");
            Console.WriteLine("****** 3. All *.srt files UNDER this program will be fixed");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Getting files.");
            Console.WriteLine("Getting files...");
            Console.WriteLine("Getting files.....");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.srt", SearchOption.AllDirectories);
            int filesToConvert = files.Length;
            sw.Stop();
            Console.WriteLine("DONE...[" + sw.Elapsed.TotalSeconds + " s]");
            Console.WriteLine("Files to fix: " + files.Length);

            Thread.Sleep(1500);

            if (filesToConvert < 1)
            {
                Console.WriteLine("ERROR: Files not found !");
            }
            else
            {
                Console.WriteLine("Working.");
                Console.WriteLine("Working...");
                Console.WriteLine("Working.....");
                sw.Restart();

                int success = 0;
                for (int i = 0; i < filesToConvert; i++)
                {
                    string[] lines = File.ReadAllLines(files[i]);

                    for (int j = 0; j < lines.Length; j++)
                    {
                        if (lines[j].Length == 23 && lines[j].Contains(":"))
                        {
                            lines[j] = lines[j].Replace(",", " --> ");
                        }
                        else if (lines[j].Length > 2 && lines[j].Contains("[br]"))
                        {
                            lines[j] = lines[j].Replace("[br]", Environment.NewLine);
                        }
                    }
                    File.WriteAllLines(files[i], lines);
                    success++;
                }
                sw.Stop();
                Console.WriteLine("DONE...[" + sw.Elapsed.TotalSeconds + " s]");
                Console.WriteLine("Files successfully fixed: " + success + "/" + filesToConvert);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
