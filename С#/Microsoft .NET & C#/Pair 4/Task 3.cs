namespace MusicInstrumentApp
{
    public class MusicalInstrument
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MusicalInstrument(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Sound()
        {
            Console.WriteLine("Musical instrument sound.");
        }

        public void Show()
        {
            Console.WriteLine($"Instrument: {Name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }

        public virtual void History()
        {
            Console.WriteLine("No specific history available.");
        }
    }

    public class Violin : MusicalInstrument
    {
        public Violin() : base("Violin", "String instrument played with a bow") { }

        public override void Sound()
        {
            Console.WriteLine("Violin produces a melodious sound.");
        }

        public override void History()
        {
            Console.WriteLine("Originated in 16th-century Italy.");
        }
    }

    public class Trombone : MusicalInstrument
    {
        public Trombone() : base("Trombone", "Brass instrument with a telescoping slide") { }

        public override void Sound()
        {
            Console.WriteLine("Trombone produces a brassy sound.");
        }

        public override void History()
        {
            Console.WriteLine("Evolved from the 15th-century sackbut.");
        }
    }

    public class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Ukulele", "Small guitar-like instrument from Hawaii") { }

        public override void Sound()
        {
            Console.WriteLine("Ukulele produces a happy strumming sound.");
        }

        public override void History()
        {
            Console.WriteLine("Developed in Hawaii in the 19th century.");
        }
    }

    public class Cello : MusicalInstrument
    {
        public Cello() : base("Cello", "Large string instrument with a deep sound") { }

        public override void Sound()
        {
            Console.WriteLine("Cello produces a rich, warm sound.");
        }

        public override void History()
        {
            Console.WriteLine("Developed in the early 16th century.");
        }
    }

    class Program
    {
        static void Main()
        {
            MusicalInstrument[] instruments = { new Violin(), new Trombone(), new Ukulele(), new Cello() };
            foreach (var instrument in instruments)
            {
                instrument.Show();
                instrument.Sound();
                instrument.Desc();
                instrument.History();
                Console.WriteLine();
            }
        }
    }
}
