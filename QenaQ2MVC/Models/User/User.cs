namespace QenaQ2MVC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<MyTask> MyTasks { get; set; }
    }
}
