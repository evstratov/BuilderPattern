using System;

namespace BuilderPattern
{
    interface IBuilder
    {
        public IBuilder CreateTransport(string name);
        public IBuilder SetWheel(int wheelCount);
        public IBuilder SetMaxSpeed(int maxSpeed);
        public IBuilder SetGPS(bool hasGPS);
    }

    class TransportBuilder : IBuilder
    {
        private Transport transport;
        public IBuilder CreateTransport(string name)
        {
            transport = new Transport();
            transport.Name = name;

            return this;
        }
        public IBuilder SetMaxSpeed(int maxSpeed)
        {
            if (transport != null)
                transport.MaxSpeed = maxSpeed;
            return this;
        }

        public IBuilder SetWheel(int wheelCount)
        {
            if (transport != null)
                transport.Wheel = wheelCount;
            return this;
        }
        public IBuilder SetGPS(bool hasGPS)
        {
            if (transport != null)
                transport.GPS = hasGPS;
            return this;
        }

        public Transport GetTransport()
        {
            return this.transport;
        }
    }
    class Transport
    {
        public string Name { get; set; }
        public int Wheel { get; set; }
        public int MaxSpeed { get; set; }
        public bool GPS { get; set; }

        public override string ToString()
        {
            return $"{Name} имеет {Wheel} колеса, максимальная скорость {MaxSpeed}, наличие GPS: {GPS}";
        }
    }

    class Director
    {
        private TransportBuilder builder = new TransportBuilder();

        public Transport CreateFerrari()
        {
            builder.CreateTransport("Ferrari").SetGPS(true).SetMaxSpeed(320).SetWheel(4);
            return builder.GetTransport();
        }

        public Transport CreateDucatti()
        {
            builder.CreateTransport("Ducatti").SetMaxSpeed(300).SetWheel(2);
            return builder.GetTransport();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TransportBuilder builder = new TransportBuilder();

            builder.CreateTransport("Honda").SetWheel(4).SetMaxSpeed(200);

            Transport honda = builder.GetTransport();

            Console.WriteLine(honda);

            Director director = new Director();

            Transport ferrari = director.CreateFerrari();
            Transport ducatti = director.CreateDucatti();

            Console.WriteLine(ferrari);
            Console.WriteLine(ducatti);

            Console.Read();
        }
    }
}
