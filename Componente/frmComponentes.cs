using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Componente
{
    public partial class frmComponentes : Form
    {
        public frmComponentes()
        {
            InitializeComponent();
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNome.Text.Equals(""))
                {
                    MessageBox.Show("Digite algo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cbbListarNomes.Items.Add(txtNome.Text);
                    txtNome.Clear();
                    txtNome.Focus();
                }
            }
        }

        private void ckbLivros_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLivros.Checked)
            {
                ltbListarProdutos.Items.Add("Livros");
                pcbImagens.Load(@".\imagens\Livros.png");
            }
            else
            {
                ltbListarProdutos.Items.Remove("Livros");
                if (pcbImagens.ImageLocation == @".\imagens\Livros.png")
                {
                    pcbImagens.Image = null;
                }
            }
        }

        private void ckbComputador_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbComputador.Checked)
            {
                ltbListarProdutos.Items.Add("Computador");
                pcbImagens.Load(@".\imagens\Computador.png");
            }
            else
            {
                ltbListarProdutos.Items.Remove("Computador");
                if(pcbImagens.ImageLocation == @".\imagens\Computador.png")
                {
                    pcbImagens.Image = null;
                }
            }
        }

        private void ckbMesa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMesa.Checked)
            {
                ltbListarProdutos.Items.Add("Mesa");
                pcbImagens.Load(@".\imagens\Mesa.png");
            }
            else
            {
                ltbListarProdutos.Items.Remove("Mesa");
                if (pcbImagens.ImageLocation == @".\imagens\Mesa.png")
                {
                    pcbImagens.Image = null;
                }
            }
        }

        private void ckbBanana_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBanana.Checked)
            {
                ltbListarProdutos.Items.Add("Banana");
                pcbImagens.Load(@".\imagens\Banana.png");
            }
            else
            {
                ltbListarProdutos.Items.Remove("Banana");
                if (pcbImagens.ImageLocation == @".\imagens\Banana.png")
                {
                    pcbImagens.Image = null;
                }
            }
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione uma imagem.";
            ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcbImagens.ImageLocation = ofd.FileName;
                pcbImagens.Load();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pcbImagens.Image = null;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ltbListarProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ltbListarProdutos.SelectedItem != null)
            {
                string selectedItem = ltbListarProdutos.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Livros":
                        pcbImagens.Load(@".\imagens\Livros.png");
                        break;
                    case "Computador":
                        pcbImagens.Load(@".\imagens\Computador.png");
                        break;
                    case "Mesa":
                        pcbImagens.Load(@".\imagens\Mesa.png");
                        break;
                    case "Banana":
                        pcbImagens.Load(@".\imagens\Banana.png");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                pcbImagens.Image = null;
            }
        }
    }
}
