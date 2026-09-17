using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        // Alex Eisenmann
        public frmNewItem()
        {
            InitializeComponent();
        }

        private InvItem invItem = null;

        // Alex Eisenmann
        public InvItem GetNewItem()
        {
            LoadComboBox();
            this.ShowDialog();
            return invItem;
        }

        // Alex Eisenmann
        private void LoadComboBox()
        {
            cboSizeOrManufacturer.Items.Clear();
            if (rdoPlant.Checked)
            {
                cboSizeOrManufacturer.Items.Add("1 gallon");
                cboSizeOrManufacturer.Items.Add("5 gallon");
                cboSizeOrManufacturer.Items.Add("15 gallon");
                cboSizeOrManufacturer.Items.Add("24-inch box");
                cboSizeOrManufacturer.Items.Add("36-inch box");
            }
            else
            {
                cboSizeOrManufacturer.Items.Add("Bayer");
                cboSizeOrManufacturer.Items.Add("Jobe's");
                cboSizeOrManufacturer.Items.Add("Ortho");
                cboSizeOrManufacturer.Items.Add("Roundup");
                cboSizeOrManufacturer.Items.Add("Scotts");
            }
        }

        // Alex Eisenmann
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int itemNo = Convert.ToInt32(txtItemNo.Text);
                string description = txtDescription.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);
                string sizeOrManufacturer = cboSizeOrManufacturer.Text;

                if (rdoPlant.Checked)
                {
                    invItem = new Plant(itemNo, description, price, sizeOrManufacturer);
                }
                else
                {
                    invItem = new Supply(itemNo, description, price, sizeOrManufacturer);
                }

                this.Close();
            }
        }

        // Alex Eisenmann
        private bool IsValidData()
        {
            return Validator.IsPresent(txtItemNo) &&
                   Validator.IsInt32(txtItemNo) &&
                   Validator.IsPresent(txtDescription) &&
                   Validator.IsPresent(txtPrice) &&
                   Validator.IsDecimal(txtPrice);
        }

        // Alex Eisenmann
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Alex Eisenmann
        private void rdoPlant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPlant.Checked)
            {
                lblSizeOrManufacturer.Text = "Size:";
            }
            else
            {
                lblSizeOrManufacturer.Text = "Manufacturer:";
            }
            LoadComboBox();
        }
    }
}
