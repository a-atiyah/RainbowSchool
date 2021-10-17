using RainbowSchool.Model;
using System;
using System.IO;

namespace RainbowSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rainbow School:\n...\n...\n...");
            Console.WriteLine("Choose the Operation you want:");
            Console.WriteLine("1- Display teachers info, 2- Update teacher info, 3- Add new teacher");

            // Read user input
            string choice = Console.ReadLine();
            //Select function
            while (choice != "4")
            {
                switch (choice)
                {
                    case "1":
                        displayTeachersData();
                        break;
                    case "2":
                        UpdateacherData();
                        break;
                    case "3":
                        AddNewTeacherData();
                        break;
                    default:
                        Console.WriteLine("Thanks For using our system!");
                        return;

                }
                Console.WriteLine("\n...\n...\n...");
                Console.WriteLine("Choose the Operation you want:");
                Console.WriteLine("1- Display teachers info, 2- Update teacher info, 3- Add new teacher");
                choice = Console.ReadLine();

            };

            Console.WriteLine("Thanks For using our system!");
        }

        //Method to display all the data
        static void displayTeachersData()
        {
            string[] lines = Helper.HelperClass.ReadAllData();

            foreach (string line in lines)
                Console.WriteLine(line);
        }

        // Method to update teacher data
        static void UpdateacherData()
        {
            Console.Write("Please, Enter Teacher ID:");
            string tId = Console.ReadLine();
            string[] teacherData = retrieveTeacherData(tId);
            if (teacherData == null)
            {
                Console.WriteLine("No teacher with this id");
                return;
            }
            string[] fields = teacherData[0].Split(' ');
            Console.Write("What do you want to update: 1- Teacher Name, 2- Teacher Class, 3- Teacher Section ");
            string fieldToUpdate = Console.ReadLine();
            //Select the field to be updated
            switch (fieldToUpdate)
            {
                case "1":
                    Console.Write("Enter Teacher Name: ");
                    fields[1] = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter Teacher Class: ");
                    fields[2] = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Enter Teacher Section: ");
                    fields[3] = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Thanks For using our system!");
                    return;

            }
            string updatedTeacherData = string.Join(" ", fields);
            Helper.HelperClass.UpdateExistingData(updatedTeacherData, Int16.Parse(teacherData[1]));
            Console.WriteLine("Updated Success!");
        }

        //Method to insert new line of data into the file
        static void AddNewTeacherData()
        {
            Teacher teacher = new Teacher();
            Console.Write("Please, Enter Teacher Name: ");
            teacher.Name = Console.ReadLine();
            Console.Write("Please, Enter Teacher Id: ");
            teacher.ID = Int32.Parse(Console.ReadLine());
            Console.Write("Please, Enter Teacher Class: ");
            teacher.ClassNo = Int32.Parse(Console.ReadLine());
            Console.Write("Please, Enter Teacher Section: ");
            teacher.Section = Console.ReadLine();

            string newRec = $"{teacher.ID} {teacher.Name} {teacher.ClassNo} {teacher.Section}";
            Console.WriteLine("Saved!");
            Helper.HelperClass.WriteNewLine(newRec);
        }

        //Read all data & return the selected teacher line
        private static string[] retrieveTeacherData(string tID)
        {
            string[] lines = Helper.HelperClass.ReadAllData();
            int counter = 0;
            foreach (string line in lines)
            {
                string id = line.Split(" ")[0];
                if (Int32.Parse(id) == Int32.Parse(tID))
                {
                    return new string[] { line, counter.ToString() };
                }
                counter++;
            }


            return null;
        }
    }
}
