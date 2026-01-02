// كلاس الادارة يحذف يضيف يخزن و يرتب الطلاب 
class StudentManager
{ 
    //ليس تخزين الطلاب و معلوماتهم
    private List<Student> students = new List<Student>();
    //إضافة طالب جديد إلى القائمة بشرط عدم تكرار الرقم
    public void AddStudent(Student std)
    {
        if (GetStudentById(std.Id) != null)
        {
            Console.WriteLine("This number is already in use for another student..");
            return;
        }

        students.Add(std);
        Console.WriteLine("The student has been added successfully.");
    }
    //حذف طالب  من القائمة بشرط وجوده 

    public bool RemoveStudent(int id)
    {
        Student std = GetStudentById(id);
        if (std != null)
        {
            students.Remove(std);
            return true;
        }
        return false;
    }
    //البحث عن طالب باستخدام الرقم
    public Student GetStudentById(int id)
    {
        foreach (var std in students)
        {
            if (std.Id == id)
                return std;
        }
        return null;
    }

    //ترتيب الطلاب حسب المعدل تنازليا باستخدام البوبيل سورت

    public void SortByAverageDescending()
    {
        int n = students.Count;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (students[j].Average < students[j + 1].Average)
                {
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }
    }
    //عرض جميع الطلاب
    public void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("There are no students to show them.");
            return;
        }

        foreach (var std in students)
            Console.WriteLine(std);
    }
    //عرض الطلاب الذين معدلهم أكبر أو يساوي حد معيّن
    public void DisplayStudentsAboveAverage(double threshold)
    {
        bool found = false;
        foreach (var std in students)
        {
            if (std.Average >= threshold)
            {
                Console.WriteLine(std);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("There are no students with the required GPA..");
    }
}
