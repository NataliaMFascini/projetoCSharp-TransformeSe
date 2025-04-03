using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LojaABC
{
    public partial class frmPesquisarFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmPesquisarFuncionarios()
        {
            InitializeComponent();
            desabilitarCampo();
        }

        public void desabilitarCampo()
        {
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;

            txtDescricao.Focus();
        }

        private void frmPesquisarFuncionarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        public void limparCampos()
        {
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;

            ltbPesquisar.Items.Clear();

            txtDescricao.Clear();
            txtDescricao.Enabled = false;
            txtDescricao.Focus();

            btnPesquisar.Enabled = false;
            btnLimpar.Enabled = false;
        }
        public void limparCamposPesquisar()
        {
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;

            txtDescricao.Clear();
            txtDescricao.Enabled = false;
            txtDescricao.Focus();

            btnPesquisar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                MessageBox.Show("Favor preencher o campo da descrição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
            }
            else
            {
                ltbPesquisar.Items.Clear();
                ltbPesquisar.Items.Add(txtDescricao.Text);
                limparCamposPesquisar();
            }
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void habilitarCampos()
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();

            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = true;
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = ltbPesquisar.SelectedItem.ToString();
            frmFuncionario abrir = new frmFuncionario(descricao);
            abrir.Show();
            this.Hide();
        }
    }
}
