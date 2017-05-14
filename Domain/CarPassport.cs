namespace Domain
{
    public class CarPassport
    {
        public CarPassport(Car car)
        {
            Car = car;
        }

        public Driver Owner { get; set; }
        public Car Car { get; }
    }
}