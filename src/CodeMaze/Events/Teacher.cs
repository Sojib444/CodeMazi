namespace Event
{
    public delegate void Notic(string massage);
    public class Teacher
    {
        public event Notic? Notification;

        public void StartProcess(string massage)
        {
            OnNotification(massage);
        }
        
        protected virtual void OnNotification(string massage)
        {
            Notification?.Invoke(massage);
        }
    }
}
