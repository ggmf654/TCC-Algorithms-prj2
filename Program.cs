namespace TCC_1_Alg
{
    using System;


    class Program
    {

        static void Main()
        {//التعريف عن نسخة من ادارة الطلاب 
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            StudentManager manager = new StudentManager();
            int choice = -1;
            //التأكد من ان علامة الطالب ضمن المجال من 0 الى 100 
            static double ReadMark()
            {
                double mark = Convert.ToDouble(Console.ReadLine());
                if (mark < 0 || mark > 100)
                    throw new ArgumentOutOfRangeException("The score should be between 0 and 100.");
                return mark;
            }
            //عرض خيارات العمليات 
            do
            {
                try
                {
                    Console.WriteLine("\n===== Student Management System =====");
                    Console.WriteLine("1 - Add Student");
                    Console.WriteLine("2 - Remove Student");
                    Console.WriteLine("3 - Search for Student");
                    Console.WriteLine("4 - Sort by Average");
                    Console.WriteLine("5 - Display All Students");
                    Console.WriteLine("6 - Display Students Above a Certain Average");
                    Console.WriteLine("0 - Exit");
                    Console.Write("Select an option: ");


                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice < 0 || choice > 6)
                        throw new ArgumentOutOfRangeException();
                    // تحديد نوع العملية التي يريذد المستخدم تنفيذها 
                    switch (choice)
                    {
                        case 1:
                            Console.Write(" STD Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("STD Name: ");
                            string name = Convert.ToString(Console.ReadLine());

                            Console.Write("EXM1 : ");
                            double exam1 = Convert.ToDouble(Console.ReadLine());

                            Console.Write("EXM2: ");
                            double exam2 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Phone Number: ");
                            string Num = Convert.ToString(Console.ReadLine());

                            manager.AddStudent(new Student(id, name, exam1, exam2, Num));
                            break;

                        case 2:
                            Console.Write("Enter STD Id to delet: ");
                            int delId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(manager.RemoveStudent(delId)
                                ? "Deleted."
                                : "the std is not avilebol.");
                            break;

                        case 3:
                            Console.Write("Enter STD Id to search: ");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            Student std = manager.GetStudentById(searchId);
                            Console.WriteLine(std != null ? std.ToString() : "the std is not avilebol.");
                            break;

                        case 4:
                            manager.SortByAverageDescending();
                            Console.WriteLine("The order is based on average in descending order.");
                            break;

                        case 5:
                            manager.DisplayAllStudents();
                            break;

                        case 6:
                            Console.Write("Enter the minimum rate:");
                            double threshold = ReadMark();
                            manager.DisplayStudentsAboveAverage(threshold);
                            break;
                    }
                }
                //في حال ادخال قيمة غير صحيحة
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter correct numerical values..");
                }
                //في حال اختيار رقم خارج الرينج من 0 الى 6
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                //في حال الاخطاء الاخرى
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            } while (choice != 0);
        }

    }
}

