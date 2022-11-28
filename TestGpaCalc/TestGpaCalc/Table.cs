namespace TestGpaCalc
{
    class Table
    {
         List<string> courseCode;
         List<int> score;
         List<int> courseUnit;
        public Table(List<string> courseCode,
        List<int> score,
        List<int> courseUnit)
        {
            this.courseCode = courseCode;
            this.score = score;
            this.courseUnit = courseUnit;

        }
        public void TableMaker()
        {
            var sumCourseUnit = 0;
            var sumGradeUnit = 0;
            var sumWeightPoint = 0;
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-------------|");
            Console.WriteLine("|   COURSECODE  | COURSE UNIT | GRADE | GRADE-UNIT | WEIGHT Pt. |   REMARK    |");
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-------------|");
            for (int i = 0; i < score.Count; i++)
            {
                var grade = "";
                var remarks = "";
                var gradeUnit = 0;
                var weightPoint = 0;
                double GPA = 0;
                if (score[i] >= 70 && score[i] < 100)
                {
                    grade = "A";
                    gradeUnit = 5;
                    remarks = "Excellent";
                    weightPoint = courseUnit[i] * gradeUnit;
                }
                else if (score[i] >= 60 && score[i] < 70)
                {
                    grade = "B";
                    remarks = "Very Good";
                    gradeUnit = 4;
                    weightPoint = courseUnit[i] * gradeUnit;
                }
                else if (score[i] >= 50 && score[i] < 60)
                {
                    grade = "C";
                    remarks = "Good";
                    gradeUnit = 3;
                    weightPoint = courseUnit[i] * gradeUnit;
                }
                else if (score[i] >= 45 && score[i] < 50)
                {
                    grade = "D";
                    remarks = "Fair";
                    gradeUnit = 2;
                    weightPoint = courseUnit[i] * gradeUnit;
                }
                else if (score[i] >= 40 && score[i] < 45)
                {
                    grade = "E";
                    remarks = "Pass";
                    gradeUnit = 1;
                    weightPoint = courseUnit[i] * gradeUnit;
                }
                else
                {
                    grade = "F";
                    remarks = "Fail";
                    gradeUnit = 0;
                    weightPoint = courseUnit[i] * gradeUnit;
                }

                Console.WriteLine("|    " + courseCode[i] + "     |      " + courseUnit[i] + "      |   " + grade + "   |       " + gradeUnit + "    |" + "     "
                                    + (courseUnit[i] * gradeUnit).ToString().PadRight(6, ' ') + " | " + " " + remarks.PadRight(11, ' ') + "|");

                Console.WriteLine("|--------------------------------------------------|------------|-------------|");
                Console.WriteLine();
                sumCourseUnit += courseUnit[i];
                sumGradeUnit += gradeUnit;
                sumWeightPoint += weightPoint;
                GPA = (double)Math.Round((decimal)sumWeightPoint/sumCourseUnit, 2);

                Console.WriteLine("Total course unit registered is " + sumCourseUnit+".");
                Console.WriteLine("");
                Console.WriteLine("Total Course unit passed is " +gradeUnit+".");
                Console.WriteLine("");
                Console.WriteLine("Total Weight Point is " +weightPoint+".");
                Console.WriteLine("");
                if (sumCourseUnit != 0)
                {
                    Console.WriteLine("Your GPA is = " + GPA + " to 2 decimal places");
                } else Console.WriteLine("Your GPA cannot be determined for a zero unit course");

                Console.WriteLine();

            }



        }
    }
}
