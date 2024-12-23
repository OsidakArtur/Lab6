using System;

class SemesterControlInfo
{
    protected string controlForm;
    protected string gradingScale;
    protected DateTime examinationDate;
    protected DateTime resultsFillingDate;
    protected int hours;

    public string ControlForm { get => controlForm; set => controlForm = value; }
    public string GradingScale { get => gradingScale; set => gradingScale = value; }
    public DateTime ExaminationDate { get => examinationDate; set => examinationDate = value; }
    public DateTime ResultsFillingDate { get => resultsFillingDate; set => resultsFillingDate = value; }
    public int Hours { get => hours; set => hours = value; }

    public SemesterControlInfo() { }
    public SemesterControlInfo(string controlForm, string gradingScale, DateTime examDate, DateTime fillDate, int hours)
    {
        this.controlForm = controlForm;
        this.gradingScale = gradingScale;
        this.examinationDate = examDate;
        this.resultsFillingDate = fillDate;
        this.hours = hours;
    }

    public double GetTotalTime() => hours * studentsCount;
    public bool IsHappeningToday() => examinationDate.Date == DateTime.Today.Date || resultsFillingDate.Date == DateTime.Today.Date;

    public override string ToString()
    {
        return $"Контроль: {controlForm}, Шкала: {gradingScale}, Дата екзамену: {examinationDate.ToShortDateString()}, Дата заповнення: {resultsFillingDate.ToShortDateString()}, Час: {hours} год";
    }
}

class TeachersWorkload
{
    protected string subjectName;
    protected string semester;
    protected int studentsCount;
    protected SemesterControlInfo semesterControl;

    public string SubjectName { get => subjectName; set => subjectName = value; }
    public string Semester { get => semester; set => semester = value; }
    public int StudentsCount { get => studentsCount; set => studentsCount = value; }
    public SemesterControlInfo SemesterControl { get => semesterControl; set => semesterControl = value; }

    public TeachersWorkload() { }
    public TeachersWorkload(string subjectName, string semester, int studentsCount, SemesterControlInfo semesterControl)
    {
        this.subjectName = subjectName;
        this.semester = semester;
        this.studentsCount = studentsCount;
        this.semesterControl = semesterControl;
    }

    public override string ToString()
    {
        return $"Дисципліна: {subjectName}, Семестр: {semester}, Кількість студентів: {studentsCount}, {semesterControl.ToString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        Console.Write("Введіть кількість дисциплін: ");
        int.TryParse(Console.ReadLine(), out n);

        TeachersWorkload[] workloads = new TeachersWorkload[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведіть дані для дисципліни #{i + 1}:");

            Console.Write("Назва дисципліни: ");
            string subject = Console.ReadLine();

            Console.Write("Семестр: ");
            string semester = Console.ReadLine();

            Console.Write("Кількість студентів: ");
            int studentCount = int.Parse(Console.ReadLine());

            Console.Write("Форма контролю: ");
            string controlForm = Console.ReadLine();

            Console.Write("Шкала оцінювання: ");
            string gradingScale = Console.ReadLine();

            Console.Write("Дата екзамену (yyyy-mm-dd): ");
            DateTime examDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Дата заповнення (yyyy-mm-dd): ");
            DateTime fillDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Кількість годин: ");
            int hours = int.Parse(Console.ReadLine());

            SemesterControlInfo semesterControl = new SemesterControlInfo(controlForm, gradingScale, examDate, fillDate, hours);
            workloads[i] = new TeachersWorkload(subject, semester, studentCount, semesterControl);
        }

        while (true)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1 - Перевірити, чи проходить контроль сьогодні");
            Console.WriteLine("2 - Підсумкова тривалість екзамену");
            Console.WriteLine("3 - Вивести всі дисципліни");
            Console.WriteLine("4 - Вихід");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                foreach (var workload in workloads)
                {
                    Console.WriteLine($"Дисципліна: {workload.SubjectName}, сьогодні контроль: {workload.SemesterControl.IsHappeningToday()}");
                }
            }
            else if (choice == 2)
            {
                foreach (var workload in workloads)
                {
                    Console.WriteLine($"Дисципліна: {workload.SubjectName}, загальна тривалість: {workload.SemesterControl.GetTotalTime()} год");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("\nВиведення всіх дисциплін:");
                foreach (var workload in workloads)
                {
                    Console.WriteLine(workload);
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Програма завершена.");
                break;
            }
            else
            {
                Console.WriteLine("Невірний вибір, спробуйте ще раз.");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
