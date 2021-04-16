using System.Collections.Generic;

namespace RocketShips.Lib.QueryExtensions.Models
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public List<string> Programming { get; set; }
        public int Age { get; internal set; }
    }
}