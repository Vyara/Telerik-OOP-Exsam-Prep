namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AdjustableChair : Chair, IChair, IFurniture, IAdjustableChair

    {
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int legs)
            : base(model, material, price, height, legs)
        {

        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
