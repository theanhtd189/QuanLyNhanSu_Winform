﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BTL_QLNS.BUS;
namespace BTL_QLNS
{
    public partial class QuanLyDuAn : Form
    {
        public QuanLyDuAn()
        {
            InitializeComponent();
        }
        DuAn_BUS dab = new DuAn_BUS();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgV.DataSource=dab.Search(txtSearch.Text);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            int sonv = 0;
            if (txtMaDA.Text.Trim() == "")
                MessageBox.Show("Mã dự án không được để trống !");
            else if (txtTenDA.Text.Trim() == "")
                MessageBox.Show("Tên dự án không được để trống !");
            else
                dab.insertDA(txtMaDA.Text, txtTenDA.Text, sonv, txtMotaDA.Text);
            Quanlyduan_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDA.Text.Trim() == "")
                MessageBox.Show("Mã dự án không được để trống !");
            else if (txtTenDA.Text.Trim() == "")
                MessageBox.Show("Tên dự án không được để trống !");
            else
            {
                try
                {
                    dab.updateDA(txtMaDA.Text, txtTenDA.Text, int.Parse(txtSoNVDA.Text), txtMotaDA.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Số nhân viên phải là kiểu số nguyên !" + ex.Message);
                }
            }
            Quanlyduan_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dab.deleteDA(txtMaDA.Text);
            Quanlyduan_Load(sender, e);
        }

        private void Quanlyduan_Load(object sender, EventArgs e)
        {
            dgV.DataSource = dab.getDUAN();
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaDA.Text = dgV.Rows[index].Cells[0].Value.ToString();
                txtTenDA.Text = dgV.Rows[index].Cells[1].Value.ToString();
                txtSoNVDA.Text = dgV.Rows[index].Cells[2].Value.ToString();
                txtMotaDA.Text = dgV.Rows[index].Cells[3].Value.ToString();
            }
        }
    }
}
