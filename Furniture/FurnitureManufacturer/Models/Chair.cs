
namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Chair : Furniture, IChair, IFurniture
    {
        public Chair(string model, MaterialType material, decimal price, decimal height, int legs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = legs;
        }

        public int NumberOfLegs { get; private set; }

        public override string ToString()
        {
            var chair = new StringBuilder();
            chair.Append(String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                       this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs));

            return chair.ToString();
        }

    }
}
