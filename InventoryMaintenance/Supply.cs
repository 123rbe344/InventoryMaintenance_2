using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    public class Supply : InvItem
    {
        // Alex Eisenmann
        public Supply() { }

        // Alex Eisenmann
        public Supply(int itemNo, string description, decimal price, string manufacturer)
            : base(itemNo, description, price)
        {
            Manufacturer = manufacturer;
        }

        public string Manufacturer { get; set; }

        // Alex Eisenmann
        public override string GetDisplayText() => $"{ItemNo}    {Manufacturer} {Description} ({Price:c})";
    }
}
