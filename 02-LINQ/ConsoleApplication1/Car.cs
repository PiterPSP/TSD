using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.Linq.Cars
{
   
    public class Car
    {
        public Car(string make)
        {
            Make = make;
        }

        public int? NumberOfSeats { get; set; }

        public string Make { get; }

        public int Sales2015 { get; set; }

        public int Sales2014 { get; set; }
    }

   
}
