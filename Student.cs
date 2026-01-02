
//كلاس الطلاب يمثل طالب و يحوي بياناته
using System.Text.RegularExpressions;

class Student
{
    public int Id { get; }
    public string Name { get; set; }
    public double Exam1 { get; set; }
    public double Exam2 { get; set; }
    private string _num;

    // رقم الهاتف مع تحقق Regex
    public string Num
    {
        get { return _num; }
        set
        {
            if (Regex.IsMatch(value, @"^09\d{8}$"))
            {
                _num = value;
            }
            else
            {
                throw new ArgumentException(
                    "Phone number must start with 09 and contain exactly 10 digits."
                );
            }
        }
    }
    public double Average => (Exam1 + Exam2) / 2.0;

    //اعادة تقدير لكل طالب حسب العلامة 
    public string Grade
    {
        get
        {
            if (Average >= 90) return "A+";
            else if (Average >= 80) return " A";
            else if (Average >= 70) return "B+";
            else if (Average >= 60) return "B";
            else return "c";
        }
    }

    public Student(int id, string name, double exam1, double exam2, object _num)
    {
        Id = id;
        Name = name;
        Exam1 = exam1;
        Exam2 = exam2;
        Num = _num.ToString();
    }

    public override string ToString()
    {
        return $"STD ID: {Id} | NAME: {Name} | EXAM1: {Exam1} |  EXAM2: {Exam2} |Average: {Average} | Grade: {Grade}";
    }
}