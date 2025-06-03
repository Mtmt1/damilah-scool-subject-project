using System.Collections.Generic;

namespace SchoolSubjectsSystem
{
    public interface ISubject
    {
        string Name { get; set; }
        string Description { get; set; }
        int WeeklyClasses { get; set; }
        List<string> Literature { get; set; }
        string GetDetailedInformation();
    }
} 