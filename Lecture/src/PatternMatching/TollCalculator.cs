using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    public class TollCalculator
    {
        //switch (vehicle)
        //    {
        //    case Car c when c.Passengers == 0:
        //        return 2.5M;
        //        break;
        //    default:
        //        break;
        //    }
        public decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car { Passengers: 0} => 2.5M,
                Car c => 2.0M,
                Taxi t => 3.5M,
                Bus b => 5M,
                DeliveryTruck dt => 10M,
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                _ => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}
