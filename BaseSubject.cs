using System.Collections.Generic;
using System.Text;

namespace SchoolSubjectsSystem
{
    public abstract class BaseSubject : ISubject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeeklyClasses { get; set; }
        public List<string> Literature { get; set; }

        protected BaseSubject()
        {
            Literature = new List<string>();
        }

        public virtual string GetDetailedInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {Name}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Weekly Classes: {WeeklyClasses}");
            sb.AppendLine("Literature:");
            foreach (var book in Literature)
            {
                sb.AppendLine($"- {book}");
            }
            return sb.ToString();
        }
    }
} 