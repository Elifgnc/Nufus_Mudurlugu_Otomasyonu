﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _202503071_nüfus_müdürlüğü_otomosyonu
{
    public partial class FrmGiris : Form
    {
        public static string kullanicimSession = "";

        public FrmGiris()
        {
            InitializeComponent();
          
        }

        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog=202503071;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();

            if(cmbmemurturu.SelectedIndex==0)
            {
                SqlCommand komut = new SqlCommand("Select * From Table_sifre_bilgileri where (memur_kullanici_adi=@p1 and memur_sifre=@p2)", baglanti);
                komut.Parameters.AddWithValue("@p1", kullanicitxt.Text);
                komut.Parameters.AddWithValue("@p2", kayit_listesi.MD5Sifrele(sifretxt.Text));
                kullanicimSession = kullanicitxt.Text;
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Tebrikler Giriş Başarılı");
                    baglanti.Close();
                    Frmkayit frm = new Frmkayit();
                    this.Hide();
                    frm.Show();

                }

                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
                    baglanti.Close();
                    kullanicitxt.Clear();
                    sifretxt.Clear();
                    kullanicitxt.Focus();

                }
             

            }
            else if(cmbmemurturu.SelectedIndex==1)
            {
                SqlCommand komut = new SqlCommand("Select * From Table_sifre_bilgileri where yönetici_kullanici_adi=@p3 and yönetici_sifre=@p4", baglanti);
                komut.Parameters.AddWithValue("@p3", kullanicitxt.Text);
                komut.Parameters.AddWithValue("@p4", kayit_listesi.MD5Sifrele(sifretxt.Text));
                kullanicimSession = kullanicitxt.Text;

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Tebrikler Giriş Başarılı");
                    baglanti.Close();

                    kayit_listesi  frm = new kayit_listesi ();
                    this.Hide();
                    frm.Show();

                }

                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
                    baglanti.Close();
                    kullanicitxt.Clear();
                    sifretxt.Clear();
                    kullanicitxt.Focus();

                }

               

            }


         

        }

       
    
    }
    }

