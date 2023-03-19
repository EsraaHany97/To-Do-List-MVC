namespace QenaQ2MVC.Models
{
    public class MyTask
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryTaskID { get; set; }
        public CategoryTask Category { get; set; }
        public int UserID { get; set; }
        public User Owner { get; set; }
        public DateTime? AssignDate { get; set; }
        public string Status { get; set; }


    }
}
