namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConvertibleChair : Chair, IChair, IFurniture, IConvertibleChair
    {
        public const decimal ConvertedChairStandartHeight = 0.10m;
        

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int legs)
            : base(model, material, price, height, legs)
        {
            this.IsConverted = false;
            this.InitialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public decimal InitialHeight { get; private set; }


        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.Height = ConvertedChairStandartHeight;
                this.IsConverted = true;
            }

            else
            {
                this.Height = this.InitialHeight;
                this.IsConverted = false;
            }

        }

        public override string ToString()
        {
            var convertibleChair = new StringBuilder();
            convertibleChair.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", 
                    this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal"));

            return convertibleChair.ToString();

        }
    }
}
