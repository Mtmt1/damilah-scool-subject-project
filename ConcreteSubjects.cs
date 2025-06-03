namespace SchoolSubjectsSystem
{
    public class MathSubject : BaseSubject
    {
        public MathSubject()
        {
            Name = "Mathematics";
            Description = "Study of numbers, quantities, shapes, and patterns";
            WeeklyClasses = 5;
            Literature.Add("Basic Mathematics by Kiril Dimovski");
            Literature.Add("Advanced Algebra by Elena Petrovska");
        }
    }

    public class EnglishSubject : BaseSubject
    {
        public EnglishSubject()
        {
            Name = "English";
            Description = "Study of language, literature, and communication";
            WeeklyClasses = 4;
            Literature.Add("English Grammar in Use");
            Literature.Add("Shakespeare's Complete Works");
        }
    }

    public class ArtSubject : BaseSubject
    {
        public ArtSubject()
        {
            Name = "Art";
            Description = "Study of visual arts, creativity, and artistic expression";
            WeeklyClasses = 3;
            Literature.Add("The Story of Art by E.H. Gombrich");
            Literature.Add("Color Theory and Practice");
        }
    }
} 