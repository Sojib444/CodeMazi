namespace Delegate
{
    public delegate void Mydelegate(string massage);
    public delegate T GenericDelegates<T>(T massage);
    public delegate res func< T1,res>(T1 arg);
    public class Day1
    {
        public static void Getmyname(string name)
        {
            Console.WriteLine(name);
        }
    }
}
