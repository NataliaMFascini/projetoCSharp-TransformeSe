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
    public partial class frmFuncionario : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmFuncionario()
        {
            InitializeComponent();
            //executando desabilitar os campos
            desabilitarCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal voltar = new frmMenuPrincipal();
            voltar.Show();
            this.Hide();
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        //desabilitando os componentes

        public void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            mskCpf.Enabled = false;
            dtpNascimento.Enabled = false;
            mskCelular.Enabled = false;
            gpbSexo.Enabled = false;

            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            mskCep.Enabled = false;
            txtCidade.Enabled = false;
            txtComplemento.Enabled = false;
            txtEstado.Enabled = false;
            cbbUf.Enabled = false;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
        }
        //habilitar campos
        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            mskCpf.Enabled = true;
            dtpNascimento.Enabled = true;
            mskCelular.Enabled = true;
            gpbSexo.Enabled = true;

            txtLogradouro.Enabled = true;
            txtNumero.Enabled = true;
            mskCep.Enabled = true;
            txtCidade.Enabled = true;
            txtComplemento.Enabled = true;
            txtEstado.Enabled = true;
            cbbUf.Enabled = true;

            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = true;

            btnNovo.Enabled = false;

            txtNome.Focus();
        }
        //limpar campos
        public void limparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            mskCpf.Clear();
            dtpNascimento.Text = "";
            mskCelular.Clear();

            rdbFeminino.Checked = false;
            rdbMasculino.Checked = false;
            rdbNaoInformar.Checked = false;

            txtLogradouro.Clear();
            txtNumero.Clear();
            mskCep.Clear();
            txtCidade.Clear();
            txtComplemento.Clear();
            txtEstado.Clear();
            cbbUf.Items.Clear();

            txtNome.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //executando habilitarCampos
            habilitarCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //executando limparCampos
            limparCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //para focar no campo vazio, fazer um if para cada checagem
            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("") || mskCpf.Text.Equals("   .   .   -") || mskCelular.Text.Equals("     -") || txtLogradouro.Text.Equals("") || txtNumero.Text.Equals("") || txtComplemento.Text.Equals("") || txtCidade.Text.Equals("") || txtEstado.Text.Equals("") || mskCep.Text.Equals("     -") || cbbUf.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher os campos.", "Erro",MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Cadastro realizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                limparCampos() ;
                desabilitarCampos();
            }
        }
    }
}
