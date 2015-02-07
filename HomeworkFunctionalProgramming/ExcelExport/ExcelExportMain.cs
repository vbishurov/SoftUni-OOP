namespace ExcelExport
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    public static class ExcelExportMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader("../../Students-data.txt"))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    string[] student = Regex.Split(line, @"\s+");
                    students.Add(new Student(
                        int.Parse(student[0]),
                        student[1],
                        student[2],
                        student[3],
                        (Gender)Enum.Parse(typeof(Gender), student[4]),
                        (StudentType)Enum.Parse(typeof(StudentType), student[5]),
                        int.Parse(student[6]),
                        int.Parse(student[7]),
                        int.Parse(student[8]),
                        float.Parse(student[9]),
                        float.Parse(student[10]),
                        float.Parse(student[11])));

                    line = reader.ReadLine();
                }
            }

            var result = from student in students
                         where student.StudentType == StudentType.Online
                         orderby student.Result descending
                         select student;

            string file = "../../Online-Students.xlsx";

            using (ExcelPackage package = new ExcelPackage())
            {
                package.Workbook.Worksheets.Add("Online Students");
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "online";
                worksheet.Cells.Style.Font.Size = 11;
                worksheet.Cells.Style.Font.Name = "Calibri";

                worksheet.Cells[1, 1, 1, 13].Merge = true;
                worksheet.Cells[1, 1, 1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 1, 1, 13].Style.Font.Size = 24;
                worksheet.Cells[1, 1, 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, 13].Value = "SoftUni OOP Course Results";

                worksheet.Column(13).Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Column(13).Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                worksheet.Cells[2, 1, 2, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[2, 1, 2, 13].Style.Fill.BackgroundColor.SetColor(Color.DarkGreen);

                worksheet.Cells[2, 1].Value = "ID";
                worksheet.Cells[2, 2].Value = "First Name";
                worksheet.Cells[2, 3].Value = "Last Name";
                worksheet.Cells[2, 4].Value = "Email";
                worksheet.Cells[2, 5].Value = "Gender";
                worksheet.Cells[2, 6].Value = "Student Type";
                worksheet.Cells[2, 7].Value = "Exam Result";
                worksheet.Cells[2, 8].Value = "Homework Sent";
                worksheet.Cells[2, 9].Value = "Homework Evaluated";
                worksheet.Cells[2, 10].Value = "Teamwork";
                worksheet.Cells[2, 11].Value = "Attendances";
                worksheet.Cells[2, 12].Value = "Bonus";
                worksheet.Cells[2, 13].Value = "Result";

                for (int i = 0; i < result.ToList().Count; i++)
                {
                    Student student = result.ToList()[i];
                    worksheet.Cells[i + 3, 1].Value = student.Id;
                    worksheet.Cells[i + 3, 2].Value = student.FirstName;
                    worksheet.Cells[i + 3, 3].Value = student.LastName;
                    worksheet.Cells[i + 3, 4].Value = student.Email;
                    worksheet.Cells[i + 3, 5].Value = student.Gender;
                    worksheet.Cells[i + 3, 6].Value = student.StudentType;
                    worksheet.Cells[i + 3, 7].Value = student.ExamResult;
                    worksheet.Cells[i + 3, 8].Value = student.HomeworkSent;
                    worksheet.Cells[i + 3, 9].Value = student.HomeworkEvaluated;
                    worksheet.Cells[i + 3, 10].Value = student.TeamworkScore;
                    worksheet.Cells[i + 3, 11].Value = student.Attendances;
                    worksheet.Cells[i + 3, 12].Value = student.Bonus;
                    worksheet.Cells[i + 3, 13].Value = student.Result;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                byte[] bin = package.GetAsByteArray();
                File.WriteAllBytes(file, bin);
            }
        }
    }
}
