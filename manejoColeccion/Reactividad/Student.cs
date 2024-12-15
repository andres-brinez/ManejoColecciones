public class Student

    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }

    public Student(int studentID, string studentName, int standardID)
    {
        StudentID = studentID;
        StudentName = studentName;
        StandardID = standardID;
    }
}

   
