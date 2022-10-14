using System;
using System.Reflection.Metadata.Ecma335;

namespace Curso6.Entities
{
    class CarRental
    {
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }
        public Invoice Invoice { get; set; }
        public Vehicle Model { get; set; }

        public CarRental(DateTime start, DateTime finish, Vehicle model)
        {
            Start = start;
            Finish = finish; 
            Model = model;
        }

    }
}
