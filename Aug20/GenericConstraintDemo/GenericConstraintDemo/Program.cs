
class Program
{
    static void Main1()
    {
        MarksPrinter<GraduateStudent> marksPrinter = new MarksPrinter<GraduateStudent>();
        MarksPrinter<Student> mp = new MarksPrinter<Student>();

        Student student1 = new GraduateStudent() {
            Marks = 100
        };
        mp.stu = student1;
        mp.PrintMarks();
        Student student2 = new PostGraduateStudent()
        {
            Marks = 40
        };
        mp.stu = student2;
        mp.PrintMarks();
    }
}