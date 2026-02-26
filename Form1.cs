using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gtauGabut
{
    public partial class Form1 : Form
    {
        private DataTable dtBarang;
        public Form1()
        {
            InitializeComponent();
            LoadBarang();
        }

        private void LoadBarang()
        {
            dtBarang = new DataTable();
            dtBarang.Columns.Add("Pilih", typeof(bool));
            dtBarang.Columns.Add("Barang", typeof(string));
            dtBarang.Columns.Add("Harga", typeof(int));
            dtBarang.Columns.Add("Qty", typeof(int));

            dtBarang.Rows.Add(false, "Kaos", 50000, 1);
            dtBarang.Rows.Add(false, "Celana", 80000, 1);
            dtBarang.Rows.Add(false, "Jaket", 120000, 1);
            dtBarang.Rows.Add(false, "Sepatu", 150000, 1);

            dgvBarang.DataSource = dtBarang;
            HitungTotal();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int total = 0;
            foreach (DataRow row in dtBarang.Rows)
            {
                if ((bool)row["Pilih"])
                {
                    total += (int)row["Harga"] * (int)row["Qty"];
                }
            }

            MessageBox.Show($"Total belanja: Rp{total:N0}", "Checkout");
            lblTotal.Text = $"Total: Rp{total:N0}";
        }

        private void dgvBarang_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvBarang.IsCurrentCellDirty)
            {
                dgvBarang.CommitEdit(DataGridViewDataErrorContexts.Commit);  
                HitungTotal();  
            }
        }

        private void HitungTotal()
        {
            int total = 0;
            foreach (DataRow row in dtBarang.Rows)
            {
                if ((bool)row["Pilih"])
                {
                    total += (int)row["Harga"] * (int)row["Qty"];
                }
            }
            lblTotal.Text = $"Total: Rp{total:N0}";
        }
    }
}
