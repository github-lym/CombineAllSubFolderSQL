using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir_now = Directory.GetCurrentDirectory();
            string FILE_NAME = "MyFile.txt";
            StreamWriter sw = File.CreateText(FILE_NAME);
            sw.WriteLine("--This is my file.");
            sw.Close();
            try
            {
                StreamWriter app = File.AppendText(FILE_NAME);
                DirectoryInfo dir = new DirectoryInfo(dir_now);
                String line;
                foreach (DirectoryInfo dChild in dir.GetDirectories("*"))
                {
                    foreach (FileInfo dFile in dChild.GetFiles("*.sql"))
                    {
                        //app.WriteLine(dFile.FullName);
                        StreamReader sr = new StreamReader(dFile.FullName);
                        while ((line = sr.ReadLine()) != null)
                        {
                            app.WriteLine(line);
                        }
                        sr.Close();
                    }
                }
                app.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                MessageBox.Show("The file could not be read!!");
                MessageBox.Show(e.Message);
                 //Console.WriteLine(e.Message);
            }
            MessageBox.Show("DONE!!");
        }
        
    }
}
