using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Vista
{
    public partial class cambiodecantidad : Form
    {
        Form1 f;
        public cambiodecantidad(Form1 f1)
        {
            InitializeComponent();
            f = f1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar)||char.IsControl(e.KeyChar) ||e.KeyChar=='.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cambiodecantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!string.IsNullOrEmpty(textBox1.Text) && Int64.Parse(textBox1.Text) > 0.9)
                    {
                        foreach (DataGridViewColumn c in f.dataGridView1.Columns)
                        {
                            f.dataGridView1.Rows[f.rowSelected].Cells["Cantidad"].Value = textBox1.Text;
                            this.Visible = false;
                            f.calcularTotal();
                            f.dataGridView1.MultiSelect = true;
                        }
                    }
                }
                catch (Exception l)
                {

                    MessageBox.Show(l.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }


            }
        }
    }
}
