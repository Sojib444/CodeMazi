namespace Events
{
    public class Student:EventArgs
    {
        public readonly string name;

        public Student(string name)
        {
            this.name = name;
        }
    }
}
