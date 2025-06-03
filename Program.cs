using System;
using System.Linq;

namespace SchoolSubjectsSystem
{
    class Program
    {
        private static readonly ISubjectRepository _subjectRepository = new SubjectRepository();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllSubjects();
                        break;
                    case "2":
                        DisplaySubjectDetails();
                        break;
                    case "3":
                        AddNewSubject();
                        break;
                    case "4":
                        DeleteSubject();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("School Subjects Information System");
            Console.WriteLine("1. View All Subjects");
            Console.WriteLine("2. View Subject Details");
            Console.WriteLine("3. Add New Subject");
            Console.WriteLine("4. Delete Subject");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice: ");
        }

        private static void DisplayAllSubjects()
        {
            Console.WriteLine("\nAvailable Subjects:");
            var subjects = _subjectRepository.GetAllSubjects();
            foreach (var subject in subjects)
            {
                Console.WriteLine($"- {subject.Name}");
            }
        }

        private static void DisplaySubjectDetails()
        {
            Console.Write("\nEnter subject name: ");
            var subjectName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                Console.WriteLine("Subject name cannot be empty.");
                return;
            }

            var subject = _subjectRepository.GetSubjectByName(subjectName);

            if (subject != null)
            {
                Console.WriteLine("\nSubject Details:");
                Console.WriteLine(subject.GetDetailedInformation());
            }
            else
            {
                Console.WriteLine("Subject not found.");
            }
        }

        private static void AddNewSubject()
        {
            Console.WriteLine("\nAdd New Subject");
            Console.Write("Enter subject name: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Subject name cannot be empty.");
                return;
            }

            if (_subjectRepository.GetSubjectByName(name) != null)
            {
                Console.WriteLine("Subject already exists.");
                return;
            }

            Console.Write("Enter description: ");
            var description = Console.ReadLine();

            Console.Write("Enter number of weekly classes: ");
            if (!int.TryParse(Console.ReadLine(), out int weeklyClasses))
            {
                Console.WriteLine("Invalid number of weekly classes.");
                return;
            }

            var subject = new CustomSubject
            {
                Name = name,
                Description = description ?? "No description provided",
                WeeklyClasses = weeklyClasses
            };

            Console.WriteLine("Enter literature (one per line, press Enter twice to finish):");
            while (true)
            {
                var literature = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(literature))
                    break;
                subject.Literature.Add(literature);
            }

            _subjectRepository.AddSubject(subject);
            Console.WriteLine("Subject added successfully.");
        }

        private static void DeleteSubject()
        {
            Console.WriteLine("\nDelete Subject");
            Console.Write("Enter subject name to delete: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Subject name cannot be empty.");
                return;
            }

            var subject = _subjectRepository.GetSubjectByName(name);
            if (subject == null)
            {
                Console.WriteLine("Subject not found.");
                return;
            }

            _subjectRepository.DeleteSubject(name);
            Console.WriteLine("Subject deleted successfully.");
        }
    }

    public class CustomSubject : BaseSubject
    {
        public CustomSubject()
        {
            Name = "New Subject";
            Description = "No description provided";
            WeeklyClasses = 0;
        }
    }
} 