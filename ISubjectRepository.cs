using System.Collections.Generic;

namespace SchoolSubjectsSystem
{
    public interface ISubjectRepository
    {
        IEnumerable<ISubject> GetAllSubjects();
        ISubject GetSubjectByName(string name);
        void AddSubject(ISubject subject);
        void DeleteSubject(string name);
    }
} 