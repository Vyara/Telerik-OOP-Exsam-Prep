
namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Table : Furniture, IFurniture, ITable
    {
        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get; private set;}


        public decimal Width { get; private set;}


        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }


        public override string ToString()
        {
            var table = new StringBuilder();
            table.Append(String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", 
                             this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area));
            
            return table.ToString();
        }
    }
}
