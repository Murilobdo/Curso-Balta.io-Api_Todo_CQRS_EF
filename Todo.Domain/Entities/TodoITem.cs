namespace Todo.Domain.Entities
{
    public class TodoITem : Entity
    {
        public TodoITem(string title, DateTime date, string user)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
        }

        public TodoITem()
        { }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void MarkAsDone() =>  Done = true;
        public void MarkAsUndone() =>  Done = false;
        public void UpdateTitle(string title) => Title = title;
        
    }
}