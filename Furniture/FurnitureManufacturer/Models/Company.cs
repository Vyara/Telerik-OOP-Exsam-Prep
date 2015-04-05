namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5) //TODO: Implement method for this logic
                {
                    throw new ArgumentException("Name cannot be empty, null or with less than 5 symbols");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value.Length != 10 && !AreAllDigits(value))
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols and must contain only digits");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture as Furniture);
        }

        public void Remove(IFurniture furniture)
        {
            var itemToRemove = this.furnitures.FirstOrDefault(x => x == furniture);
            if (itemToRemove != null)
            {
                this.furnitures.Remove(itemToRemove);
            }
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var areThereFurnitures = this.Furnitures.Count > 0 ? this.Furnitures.Count.ToString() : "no";
            var isPlural = this.Furnitures.Count == 1 ? "furniture" : "furnitures";
            var sortedCatalog = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
            var catalog = new StringBuilder();
            catalog.AppendLine(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, areThereFurnitures, isPlural));

                foreach (var furniture in sortedCatalog)
                {
                    catalog.AppendLine(furniture.ToString());
                }


            return catalog.ToString().Trim();

        }

        public bool AreAllDigits(string text)
        {
            foreach (var symbol in text)
            {
                if (!Char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
