using System;
using Curso6.Entities;
using Curso6.Services;
using System.Globalization;

namespace Curso6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Rental data: ");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("return: ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            Console.Write("enter price per hour: ");
            double priceHour = double.Parse(Console.ReadLine());
            Console.Write("Price per day: ");
            double priceDay = double.Parse(Console.ReadLine());
            RentalService rentalService = new RentalService(priceHour, priceDay, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);
        }
    }
}