

using Event;
using Events;

Teacher teacher = new Teacher();
Student student = new Student();

teacher.Notification += student.Teachercall;

teacher.StartProcess(" Hello students");