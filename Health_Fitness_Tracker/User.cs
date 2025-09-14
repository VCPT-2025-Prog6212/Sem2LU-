using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Fitness_Tracker
{
    public struct Measurement
    {
        public double Weight { get; set; }
        public double Height { get; set; }

        public Measurement(double weight, double height)
        {
            Weight = weight;
            Height = height;
        }
    }
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Measurement Measurement { get; set; }

       // [System.ComponentModel.Browsable(false)] // Hide this property from data binding
        public double Weight
        {
            get { return Measurement.Weight; }
            set { Measurement = new Measurement(value, Measurement.Height); }
        }

       // [System.ComponentModel.Browsable(false)] // Hide this property from data binding
        public double Height
        {
            get { return Measurement.Height; }
            set { Measurement = new Measurement(Measurement.Weight, value); }
        }

        public User(string name, int age, double weight, double height)
        {
            Name = name;
            Age = age;
            Measurement = new Measurement(weight, height);
        }
    }
}
