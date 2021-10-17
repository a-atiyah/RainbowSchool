using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RainbowSchool.Helper
{
    class HelperClass
    {
        //Path - Data File
        static string fPath = @"C:\Users\Abdulrahman\source\repos\RainbowSchool\RainbowSchool\Data\Teacher.txt";

        //Method to read all data from the file
        public static string[] ReadAllData()
        {
            return File.ReadAllLines(fPath);
        }

        //Method to insert new Data to the file
        public static void WriteNewLine(string newTxt)
        {
            File.AppendAllText(fPath, newTxt + Environment.NewLine);
        }

        //Method to Update File data
        public static void UpdateExistingData(string newTxt, int lineNo)
        {
            string[] arrLine = File.ReadAllLines(fPath);
            if (arrLine != null && arrLine.Length > 0)
            {
                if (lineNo == -1)
                    lineNo = arrLine.Length;
                arrLine[lineNo] = newTxt;
                File.WriteAllLines(fPath, arrLine);
            }
            else
            {
                File.WriteAllText(fPath, newTxt);
            }
        }
    }
}
