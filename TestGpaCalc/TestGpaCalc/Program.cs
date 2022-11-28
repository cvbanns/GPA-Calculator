
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics.Metrics;

namespace TestGpaCalc
{
    class program
    {
        public static void Main(string[] args)
        {
            
            var courseCode = new List<string>();
            var score = new List<int>();
            var courseUnit = new List<int>();
            bool inputCheck = true;
            Regex rgLetter = new Regex("^[a-zA-Z]{3}$");
            Regex rgNo = new Regex("^[0-9]{3}$");
            Console.WriteLine("    *****WELCOME*****    ");
            Console.WriteLine("\n");
            Console.WriteLine("YOUR GPA CALCULATOR IS READY TO ACCEPT INPUT");
            Console.WriteLine("\n");
            Console.WriteLine("You will be prompted to enter a six character Course Code. The first three characters are alphabets and the rest are numeric e.g NET101.");
            Console.WriteLine();
            Console.WriteLine("You can now enter course codes for the courses you are offering...");
            Console.WriteLine("");



            while (inputCheck)
                {
                    string courseCD = Console.ReadLine();
                    if (courseCD.Length != 6 || courseCD.Contains(" ") || courseCD == "")
                    {
                        Console.WriteLine("Enter a Valid Course Code (E.G NET101) this field cannot be empty.");
                        
                        continue;
                    }
                    if (!rgLetter.IsMatch(courseCD.Substring(0, 3)) || !rgNo.IsMatch(courseCD.Substring(3)))
                    {
                        Console.WriteLine("Enter a valid Course Code according to the format: The first three characters are alphabets and the rest are numeric characters e.g NET101");
                        continue;
                    }

                else courseCode.Add(courseCD.Substring(0, 3).ToUpper() + courseCD.Substring(3));

                    if (courseCode.Contains(courseCD))
                    {
                        Console.WriteLine("This Course has already been entered, enter another course");
                        
                        continue;
                    }
                    bool inputField = true;

                    while (inputField)
                    {
                    
                    Console.WriteLine("Kindly enter your score below for  " + courseCD + " (enter a number between 0-100)");
                        //bool passScore = true;
                        while (true)
                        {
                            bool correctScore = int.TryParse(Console.ReadLine(), out int scoreCD);
                            if (correctScore && scoreCD <= 100 && scoreCD > 0)
                            {
                                score.Add(scoreCD);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input, number must be between 0 and 99");
                            }
                        }
                        Console.WriteLine("Kindly enter the Course unit for " + courseCD + "   (only numbers between 0 and 9 are valid)");
                       // bool passCode = true;
                        while (true)
                        {
                            bool correctUnit = int.TryParse(Console.ReadLine(), out int unitCD);
                            if (correctUnit && unitCD >= 0 && unitCD <= 9)
                            {
                                 courseUnit.Add(unitCD);
                                //passCode = false;
                                break;
                            }
                            else
                            {
                                 Console.WriteLine("Incorrect input, course unit must be between 0-9");
                            }
                        }
                        
                        inputField = false;
                        Console.WriteLine("Do you want to add more Courses? \n Y - add more courses \n N - Calculate GP");


                        while (true)
                        {
                            string addMore = Console.ReadLine().ToUpper();

                            if (addMore.ToUpper() == "Y")
                            {
                            Console.WriteLine("Input course code for another course");
                            break;
                            }
                            else if (addMore.ToUpper() == "N")
                            {
                                inputCheck = false;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please type Y or N to add more courses or Calculate GP");
                                continue;
                            }
                        }
                    }
                

                }

            var table = new Table(courseCode, score, courseUnit);
            table.TableMaker();

        }
    }
}
