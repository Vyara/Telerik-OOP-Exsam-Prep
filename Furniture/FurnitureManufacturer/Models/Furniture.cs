namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;
        private readonly MaterialType material;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.material = material;

        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 3) //TODO: make a static method for this logic
                {
                    throw new ArgumentException("Model cannot be empty, null or with less than 3 symbols.");
                }

                this.model = value;
            }

        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }

        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentException("Price cannot be less or equal to $0.00."); // TODO: make a static method for this logic
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 m."); // TODO: make a static method for this logic
                }

                this.height = value;
            }
        }
    }
}
