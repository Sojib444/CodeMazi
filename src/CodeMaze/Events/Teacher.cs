using Events;

namespace Event
{
    public delegate void Notic(string massage);
    public class Teacher
    {
        public event Notic? Notification;
        public event EventHandler<Student> ProcessCompleted;

        public void StartProcess()
        {
            OnNotification();
        }
        
        protected virtual void OnNotification()
        {
            ProcessCompleted.Invoke(this, new Student("Sojib"));
        }
    }
}
