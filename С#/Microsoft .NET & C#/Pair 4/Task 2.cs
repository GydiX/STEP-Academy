namespace DeviceApp
{
    public class Device
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Device(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Sound()
        {
            Console.WriteLine("Device makes a sound.");
        }

        public void Show()
        {
            Console.WriteLine($"Device: {Name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }
    }

    public class Kettle : Device
    {
        public Kettle() : base("Kettle", "Electric kettle for boiling water") { }

        public override void Sound()
        {
            Console.WriteLine("Kettle whistling sound.");
        }
    }

    public class Microwave : Device
    {
        public Microwave() : base("Microwave", "Microwave oven for heating food") { }

        public override void Sound()
        {
            Console.WriteLine("Microwave beep sound.");
        }
    }

    public class Car : Device
    {
        public Car() : base("Car", "Automobile for transportation") { }

        public override void Sound()
        {
            Console.WriteLine("Car horn sound.");
        }
    }

    public class Steamship : Device
    {
        public Steamship() : base("Steamship", "Large ship powered by steam") { }

        public override void Sound()
        {
            Console.WriteLine("Steamship horn sound.");
        }
    }

    class Program
    {
        static void Main()
        {
            Device[] devices = { new Kettle(), new Microwave(), new Car(), new Steamship() };
            foreach (var device in devices)
            {
                device.Show();
                device.Sound();
                device.Desc();
                Console.WriteLine();
            }
        }
    }
}
