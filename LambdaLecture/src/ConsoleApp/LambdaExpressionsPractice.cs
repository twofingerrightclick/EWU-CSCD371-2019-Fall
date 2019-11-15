using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class LambdaExpressionsPractice
    {

        static void Main(string[] args)
        {
            List<int> myInts = new List<int> { 1, 2, 3, 4, 5, 6 };
            var myQeryable = myInts.AsQueryable();

            Console.WriteLine(string.Join(',', myInts.Where(t => t > 3)));


            //===================

            Thermostat thermo = new Thermostat();

            Heater heater = new Heater { MinTemp = 60 };

            thermo.OnTermeratureChange += heater.OnTempChange;
            //with multicast delegates null plus 1 equals 1; 




        }


        public class Thermostat
        {
            public int MyProperty { get; set; }
            public Action<float> OnTermeratureChange { get; set; }

            public float currentTemp
            {
                get { return currentTemp; }
                set
                {
                    if (currentTemp != value)
                    {
                        currentTemp = value;
                        //only call action if listeners are intitiaded/ active. 
                        OnTermeratureChange?.Invoke(value);

                        List<Exception> exceptions = new List<Exception>();
                        var onTempChanged = OnTermeratureChange;
                        if (OnTermeratureChange != null)
                        {
                            foreach (Action<float> tempChangeListener in OnTermeratureChange.GetInvocationList())

                            {
                                try
                                {
                                    tempChangeListener(value);
                                }
                                catch (Exception e)
                                {

                                    exceptions.Add(e);

                                }


                            }

                        }

                        //instead of letting the action hadnlder go through its listnerns you can do this to catch exceptions


                    }

                }
            }


        }

        public class Heater
        {

            public void OnTempChange(float currentTemp)
            {
                if (MinTemp > currentTemp)
                {
                    Console.WriteLine("Heater is on!");
                }

            }
            public float MinTemp { get; set; }

            public int MyProperty { get; set; }
        }
    }


}
