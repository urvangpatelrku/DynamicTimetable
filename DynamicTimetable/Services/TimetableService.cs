using DynamicTimetable.Models;

namespace DynamicTimetable.Services
{
    public class TimetableService
    {
        public static List<List<string>> Generate(TimetableInput input, List<SubjectAllocation> subjects)
        {
            var timetable = new List<List<string>>();
            var subjectPool = subjects.SelectMany(s => Enumerable.Repeat(s.SubjectName, s.Hours)).ToList();
            var rand = new Random();

            for (int i = 0; i < input.SubjectsPerDay; i++)
            {
                var row = new List<string>();
                for (int j = 0; j < input.WorkingDays; j++)
                {
                    int index = rand.Next(subjectPool.Count);
                    row.Add(subjectPool[index]);
                    subjectPool.RemoveAt(index);
                }
                timetable.Add(row);
            }
            return timetable;
        }
    }
}
