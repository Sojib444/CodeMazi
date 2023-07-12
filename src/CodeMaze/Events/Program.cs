

using Event;
using Events;

Teacher teacher = new Teacher();

teacher.ProcessCompleted += teacherCall;

teacher.StartProcess();

void teacherCall(object sender,Student student)
{
    Console.WriteLine($"{student.name} is called by teacher");
}