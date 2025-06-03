using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SchoolSubjectsSystem
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly List<ISubject> _subjects;
        private readonly string _jsonFilePath;

        public SubjectRepository()
        {
            _subjects = new List<ISubject>();
            _jsonFilePath = "subjects.json";
            LoadDefaultSubjects();
            LoadSubjectsFromJson();
        }

        private void LoadDefaultSubjects()
        {
            _subjects.Add(new MathSubject());
            _subjects.Add(new EnglishSubject());
            _subjects.Add(new ArtSubject());
        }

        private void LoadSubjectsFromJson()
        {
            if (File.Exists(_jsonFilePath))
            {
                try
                {
                    var jsonString = File.ReadAllText(_jsonFilePath);
                    var additionalSubjects = JsonSerializer.Deserialize<List<BaseSubject>>(jsonString);
                    if (additionalSubjects != null)
                    {
                        foreach (var subject in additionalSubjects)
                        {
                            if (!_subjects.Any(s => s.Name == subject.Name))
                            {
                                _subjects.Add(subject);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading subjects from JSON: {ex.Message}");
                }
            }
        }

        public IEnumerable<ISubject> GetAllSubjects()
        {
            return _subjects;
        }

        public ISubject GetSubjectByName(string name)
        {
            return _subjects.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddSubject(ISubject subject)
        {
            if (!_subjects.Any(s => s.Name == subject.Name))
            {
                _subjects.Add(subject);
                SaveSubjectsToJson();
            }
        }

        public void DeleteSubject(string name)
        {
            var subject = _subjects.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (subject != null)
            {
                _subjects.Remove(subject);
                SaveSubjectsToJson();
            }
        }

        private void SaveSubjectsToJson()
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(_subjects, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_jsonFilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving subjects to JSON: {ex.Message}");
            }
        }
    }
} 