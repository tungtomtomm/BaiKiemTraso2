using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiKiemTraso2
{
    public partial class Form1 : Form
    {
        private List<Sanpham> items = new List<Sanpham>();
        private Giohang cart = new Giohang();
        public class Sanpham
        {
            public string tensp { get; set; }
            public decimal gia { get; set; }
            public int soluong { get; set; }
            public Sanpham(string name, decimal price, int sl)
            {
                tensp = name;
                gia = price;
                soluong = sl;
            }
        }
        public class Giohang
        {
            private List<Sanpham> items = new List<Sanpham>();
            public void Themsp(Sanpham sanpham)
            {
                items.Add(sanpham);
            }
            public void Xoasp(Sanpham sanpham)
            {
                items.Remove(sanpham);
            }
            public decimal Tinhtong(Sanpham sanpham)
            {
                return items.Sum(p => p.gia * p.soluong);
            }
            public List<Sanpham> GetItems()
            {
                return items;
            }
            public void Clear()
            {
                items.Clear();
            }
        }
        public Form1()
        {
            InitializeComponent();
            capnhatdanhsach();
           // capnhatgia();
            chonsanphamtudanhsach();
        }
        private void sanpham()
        {
            items.Add(new Sanpham("sp1", 1500, 1));
            items.Add(new Sanpham("sp2", 100, 5));
            items.Add(new Sanpham("sp3", 2500, 11));
            items.Add(new Sanpham("sp4", 3500, 17));
            items.Add(new Sanpham("sp5", 5000, 16));
            items.Add(new Sanpham("sp6", 10000, 19));
        }
        private void capnhatdanhsach()
        {
            listView1.Items.Clear();
            foreach (var product in items)
            {
                ListViewItem item = new ListViewItem(product.tensp);
                item.SubItems.Add(product.gia.ToString("C"));
                item.SubItems.Add(product.soluong.ToString());
                listView1.Items.Add(item);
            }
        }
        private Sanpham chonsanphamtudanhsach()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selecteditem = listView1.SelectedItems[0];
                string name = selecteditem.SubItems[0].Text;
                decimal price = decimal.Parse(selecteditem.SubItems[1].Text, System.Globalization.NumberStyles.Currency);
                int sl = int.Parse(selecteditem.SubItems[2].Text);
                return new Sanpham(name, price, sl);
            }
            return null;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("thanh toan thanh cong");
            cart.GetItems();
            capnhatdanhsach();
            capnhatgia();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            foreach (var item in cart.GetItems())
            {
                var listitem = new ListViewItem(item.tensp);
                listitem.SubItems.Add(item.gia.ToString("C"));
                listitem.SubItems.Add(item.soluong.ToString());
                listView2.Items.Add(listitem);
            }
        }
        
        private void capnhatgia()
        {
            //label3.Text = $"Tong gia tri don hang: {cart.Tinhtong():C}";
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
