namespace Homework{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface ICarPart
    {
        ICarManufacturer Manufacturer {get;}
    }

    public interface ICarInterior : ICarPart
    {
        //materials, displays, etc.
    }

    public interface ICarEngine : ICarPart
    {
        //v12, turbo v6, etc.
    }

    public interface ICarBody : ICarPart
    {
        //windshield, etc.
    }

    public interface ICarManufacturer
    {
        string Name {get;}
        ICarBody ManufactureBody();
        ICarInterior ManufactureInterior();
        ICarEngine ManufactureEngine();
    }

    public class CarBody : ICarBody
    {
        public ICarManufacturer Manufacturer {get;}

        public CarBody(ICarManufacturer carManufacturer)
        {
            Manufacturer = carManufacturer;
        }
    }

    public class CarEngine : ICarEngine
    {
        public ICarManufacturer Manufacturer {get;}

        public CarEngine(ICarManufacturer carManufacturer)
        {
            Manufacturer = carManufacturer;
        }
    }

    public class CarInterior : ICarInterior
    {
        public ICarManufacturer Manufacturer {get;}

        public CarInterior(ICarManufacturer carManufacturer)
        {
            Manufacturer = carManufacturer;
        }
    }

    public class BMW : ICarManufacturer
    {
        public string Name => "BMW";

        public ICarBody ManufactureBody()
        {
            return new CarBody(this);
        }

        public ICarInterior ManufactureInterior()
        {
            return new CarInterior(this);
        }

        public ICarEngine ManufactureEngine()
        {
            return new CarEngine(this);
        }
    }

    public class AUDI : ICarManufacturer
    {
        public string Name => "Audi";

        public ICarBody ManufactureBody()
        {
            return new CarBody(this);
        }

        public ICarInterior ManufactureInterior()
        {
            return new CarInterior(this);
        }

        public ICarEngine ManufactureEngine()
        {
            return new CarEngine(this);
        }
    }
}