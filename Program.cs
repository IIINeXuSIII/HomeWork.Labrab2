// See https://aka.ms/new-console-template for more information

//ТИП КЛАСС PROGRAMM. AGA. V NET 6 EGO NET!? Ну или пойду почитаю. А пока пусть так будет

List<Course> courses = new List<Course>(4);
List<Teacher> teachers = new List<Teacher>(5);
List<Student> students = new List<Student>(5);
List<Discipline> disciplines = new List<Discipline>(5);
static void CreateDefaultList(List<Course> courses, List<Teacher> teachers, List<Student> students, List<Discipline> disciplines)
{
    courses.Add(new Course(1));
    courses.Add(new Course(2));
    courses.Add(new Course(3));
    courses.Add(new Course(4));
    teachers.Add(new Teacher("Борис Борисович Новиков"));
    teachers.Add(new Teacher("Алена Михайловна Лезжова"));
    teachers.Add(new Teacher("Васильев Никита Алексеевич"));
    teachers.Add(new Teacher("Никитин Василий Никитич"));
    teachers.Add(new Teacher("Юлия Борисовна Егорова"));
    students.Add(new Student("Дворецкий Дмитрий", 1));
    students.Add(new Student("Алексей Кузнецов", 2));
    students.Add(new Student("Влад Кушнарев", 4));
    students.Add(new Student("Анрей Ерохин", 1));
    students.Add(new Student("Солдатов Кирилл", 1));
    disciplines.Add(new Discipline("Математический анализ", 1, "Юлия Борисовна Егорова"));
    disciplines.Add(new Discipline("Сопротивление материалов", 2, "Никитин Василий Никитич"));
    disciplines.Add(new Discipline("Web-программирование", 4, "Борис Борисович Новиков"));
    disciplines.Add(new Discipline("История", 1));
    disciplines.Add(new Discipline("Информатика", 1));
}

void AddTeacher(string Name)
{
    teachers.Add(new Teacher(Name));
}
void AddStudent(string name, int NumbOfCourse)
{
    students.Add(new Student(name, NumbOfCourse));
}
void AddDiscipline(string NameOfDiscipline, int NumbOfCourse, string TeacherName = "undefinedNamed")
{
    disciplines.Add(new Discipline(NameOfDiscipline, NumbOfCourse, TeacherName));
}

//Tip VOID MAIN(string[] args)

string temp;
CreateDefaultList(courses, teachers, students, disciplines);
while (true)
{
    Console.WriteLine("Выберите действие:\n" +
        ">>1: Добавить студента.\n>>2: Добавить преподавателя.\n>>3: Добавить дисциплину.\n" +
        ">>4: Вывести всех студентов.\n>>5: Вывести всех преподавателей.\n>>6: Вывести все дисциплины.\n" +
        ">>7: Редактирование\n>>8: Выход.");
    int choice;
    if (Int32.TryParse(Console.ReadLine(), out choice))
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите ФИ студента");
                temp = Console.ReadLine()!;
                Console.WriteLine("На каком курсе учится студент?");
                foreach (Course Course in courses)
                {
                    Console.Write($"{Course.NumbOfCourse} ");
                }
                Console.Write(": ");
                if (Int32.TryParse(Console.ReadLine(), out int NumbOfCourse)
                    && NumbOfCourse < 5)
                {
                    AddStudent(temp, NumbOfCourse);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input");
                }
                Console.WriteLine("::------------------------------::");
                break;
            case 2:
                Console.WriteLine("Введите ФИО преподавателя");
                temp = Console.ReadLine()!;
                AddTeacher(temp);
                Console.WriteLine("::------------------------------::");
                break;
            case 3:
                Console.WriteLine("На каком курсе преподаётся дисциплина?");
                foreach (Course Course in courses)
                {
                    Console.Write($"{Course.NumbOfCourse} ");
                }
                Console.Write(": ");
                if (Int32.TryParse(Console.ReadLine(), out int Numb0fCourse)
                    && Numb0fCourse < 5)
                {
                    Console.WriteLine("Введите название дисциплины:");
                    temp = Console.ReadLine()!;
                    foreach (Teacher teacher in teachers)
                    {
                        teacher.GetInfo(disciplines);
                    }
                    Console.WriteLine("Есть ли преподаватель данной дисциплины в списке? y/n");
                    string YesOrNot = Console.ReadLine()!;
                    if (YesOrNot == "y" || YesOrNot == "Y" || YesOrNot == "Н" || YesOrNot == "н")
                    {
                        Console.WriteLine("Введите id преподавателя:");
                        int id = Int32.Parse(Console.ReadLine()!);
                        foreach (Teacher teacher in teachers)
                        {
                            if (id == teacher.Id)
                            {
                                AddDiscipline(temp, Numb0fCourse, teacher.Name);
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input");
                }
                Console.WriteLine("::------------------------------::");
                break;
            case 4:
                Console.Clear();
                foreach (Student student in students)
                {
                    student.GetInfo(disciplines);
                }
                Console.WriteLine("::------------------------------::");
                break;
            case 5:
                Console.Clear();
                foreach (Teacher teacher in teachers)
                {
                    teacher.GetInfo(disciplines);
                }
                Console.WriteLine("::------------------------------::");
                break;
            case 6:
                Console.Clear();
                foreach (Discipline discipline in disciplines)
                {
                    discipline.GetInfo(students);
                }
                Console.WriteLine("::------------------------------::");
                break;
            case 7:
                Console.Clear();
                Console.WriteLine("Редактировать:\n>>1: Студента\n>>2: Преподавателя\n" +
                    ">>3: Дисциплину\n");
                int TempId;
                if (Int32.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Студенты:");
                            foreach (var student in students)
                            {
                                Console.WriteLine($"Id: {student.Id}. Name: {student.Name}");
                            }
                            Console.WriteLine("Введите Id студента: ");
                            TempId = Int32.Parse(Console.ReadLine()!);
                            foreach (var item in students.Where(p => p.Id == TempId))
                            {
                                Console.WriteLine("Введите новые данные: ");
                                item.Name = Console.ReadLine()!;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Преподаватели:");
                            foreach (var teacher in teachers)
                            {
                                Console.WriteLine($"Id: {teacher.Id}. Name: {teacher.Name}");
                            }
                            Console.WriteLine("Введите Id преподавателя: ");
                            TempId = Int32.Parse(Console.ReadLine()!);
                            foreach (var item in teachers.Where(p => p.Id == TempId))
                            {
                                Console.WriteLine("Введите новые данные: ");
                                item.Name = Console.ReadLine()!;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Дисциплины:");
                            foreach (var disciplin in disciplines)
                            {
                                Console.WriteLine($"Id: {disciplin.Id}.\tTeacher: {disciplin.teacher.Name} " +
                                    $"Name: {disciplin.NameOfDiscipline}. Cource: {disciplin.NumbOfCourse}");
                            }
                            Console.WriteLine("Введите Id дисциплины: ");
                            TempId = Int32.Parse(Console.ReadLine()!);
                            foreach (var disciplin in disciplines.Where(p => p.Id == TempId))
                            {
                                Console.WriteLine("Выберете преподавателя для курса: ");
                                foreach (var teacher in teachers)
                                    Console.WriteLine($"Id: {teacher.Id}. Name: {teacher.Name}");
                                Console.WriteLine("Введите Id преподавателя: ");
                                TempId = Int32.Parse(Console.ReadLine()!);
                                foreach (var teacher in teachers.Where(p => p.Id == TempId))
                                    disciplin.teacher.Name = teacher.Name;
                            }
                            break;
                    }
                }
                Console.WriteLine("::------------------------------::");
                break;
            case 8:
                return;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
    else
    {
        Console.WriteLine("Incorrect input");
    }
}

class User
{
    public int Id { get; init; }
    private static int IDCount = 0;

    public string Name { get; set; } = "undefined";

    public User() 
    { 
        IDCount++;
        this.Id = IDCount;
    }
}

class Student : User
{
    public Course course = new Course();
    public Student() { }
    public Student(string name, int NumbOfCource)
    {
        this.Name = name;
        course.NumbOfCourse = NumbOfCource;
    }

    public void GetInfo(List<Discipline>disciplines)
    {
        Console.WriteLine($"ID: {Id}     Name: {Name}    Cource: {course.NumbOfCourse}\n" +
            $"Студент обучается по данным дисциплинам: ");
        foreach(Discipline discipline in disciplines)
        {
            if (course.NumbOfCourse == discipline.NumbOfCourse)
            {
                Console.WriteLine($">> {discipline.NameOfDiscipline}");
            }
        }
        Console.WriteLine();
    }
}

class Teacher : User
{
    public Teacher() { }
    public Teacher(string name)
    {
        this.Name=name;
    }

    public void GetInfo(List<Discipline> disciplines)
    {
        Console.WriteLine($"ID: {Id}     Name: {Name}\nПреподаватель ведёт дисциплины: ");
        foreach (Discipline discipline in disciplines)
        {
            if (Name == discipline.teacher.Name)
            {
                Console.WriteLine($">> {discipline.NameOfDiscipline}");
            }
        }
        Console.WriteLine();
    }
}

class Course
{


    public int NumbOfCourse { get; set; } = 1;
    public Course() {  }
    public Course(int NumbOfCourse)
    {
        this.NumbOfCourse = NumbOfCourse;
    }
    
}

class Discipline : Course
{
    public int Id { get; init; }
    private static int IDCount = 0;

    public string NameOfDiscipline;

    public Teacher teacher = new Teacher();
    
    public Discipline() 
    {
        IDCount++;
        this.Id = IDCount;

        NameOfDiscipline = "undefinedDiscipline";
        NumbOfCourse = 1;
        teacher.Name = "undefinedNamed";
    }
    public Discipline(string NameOfDiscipline)
    {
        IDCount++;
        this.Id = IDCount;

        this.NameOfDiscipline=NameOfDiscipline;
        NumbOfCourse = 1;
        teacher.Name = "undefinedNamed";
    }
    public Discipline(string NameOfDiscipline, int NumbOfCourse)
    {
        IDCount++;
        this.Id = IDCount;

        this.NameOfDiscipline = NameOfDiscipline;
        this.NumbOfCourse=NumbOfCourse;
        teacher.Name = "undefinedNamed";
    }
    public Discipline(string NameOfDiscipline, int NumbOfCourse, string TeacherName)
    {
        IDCount++;
        this.Id = IDCount;

        this.NameOfDiscipline = NameOfDiscipline;
        this.NumbOfCourse = NumbOfCourse;
        teacher.Name = TeacherName;
    }

    public void GetInfo(List<Student> students)
    {
        Console.WriteLine($"Id: {Id}\t Название дисциплины: {NameOfDiscipline}, " +
       $"курс: {NumbOfCourse}, преподаватель: {teacher.Name}");
        int NumbOfStudents = 0;
        foreach (Student student in students)
        {
            if(student.course.NumbOfCourse == NumbOfCourse)
            {
                NumbOfStudents++;
            }
        }
        Console.WriteLine($"Число студентов, обучающихся по данной дисциплине: {NumbOfStudents}\n");
    }
}