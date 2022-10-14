using Curso6.Entities;
using System;
using System.Collections.Generic;


namespace Curso6.Services
{
    class RentalService
    {
        public double PriceHour { get; set; }
        public double PriceDay { get; set; }

        public ItaxService _taxService { get; set; }

        public RentalService(double priceHour, double priceDay, ItaxService taxService)
        {
            PriceHour = priceHour;
            PriceDay = priceDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {

            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            if(duration.TotalHours>= 12)
            {
               double basicPayment = PriceDay*Math.Ceiling(duration.TotalDays);
               double tax = _taxService.Tax(basicPayment);
                carRental.Invoice =new Invoice(basicPayment, tax);
            }
            else
            {
               double basicPayment = PriceHour * Math.Ceiling(duration.TotalHours);
                double tax = _taxService.Tax(basicPayment);
                carRental.Invoice = new Invoice(basicPayment, tax);
            }
            Console.WriteLine(carRental.Invoice);
        }
    }
}
