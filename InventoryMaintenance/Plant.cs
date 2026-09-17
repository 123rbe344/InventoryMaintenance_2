using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    // uses inheritance by extending InvItem with a Size
    // property and overriding GetDisplayText() to format plant-specific output.
    public class Plant : InvItem
    {
        // Alex Eisenmann
        public Plant() { }

        // Alex Eisenmann
        public Plant(int itemNo, string description, decimal price, string size)
            : base(itemNo, description, price)
        {
            Size = size;
        }

        public string Size { get; set; }

        // Alex Eisenmann
        public override string GetDisplayText() => $"{ItemNo}    {Size} {Description} ({Price:c})";
    }
}
