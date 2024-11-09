namespace WorkerApp
{
    public abstract class Worker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            Name = name;
        }

        public abstract void Print();
    }

    public class President : Worker
    {
        public President(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"{Name} - President of the company, overseeing operations.");
        }
    }

    public class Security : Worker
    {
        public Security(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"{Name} - Security officer, ensuring safety and protection.");
        }
    }

    public class Manager : Worker
    {
        public Manager(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"{Name} - Manager, responsible for project management.");
        }
    }

    public class Engineer : Worker
    {
        public Engineer(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"{Name} - Engineer, involved in technical design and development.");
        }
    }

    class Program
    {
        static void Main()
        {
            Worker[] workers = { new President("Alice"), new Security("Bob"), new Manager("Carol"), new Engineer("Dave") };
            foreach (var worker in workers)
            {
                worker.Print();
            }
        }
    }
}
