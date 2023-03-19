namespace QenaQ2MVC.Models
{
    public class CategoryTask
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<MyTask> MyTasks { get; set; }
    }
}
