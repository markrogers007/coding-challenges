using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public static class ReadWarFile
    {
        public static List<string> ReadFromFile(string filename)
        {
            List<string> lines = new List<string>();

            try
            {
                FileStream fs = File.Open(filename, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                sr.Close();
            }
            catch(FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lines;
        }
    }
}
