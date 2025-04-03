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

        //pode-se ter dois metodos construtores, contanto que os parametros sejam diferentes
        public frmFuncionario()
        {
            InitializeComponent();
            //executando desabilitar os campos
            desabilitarCampos();
        }
        public frmFuncionario(string descricao)
        {
            InitializeComponent();
            //executando desabilitar os campos
            desabilitarCampos();
            txtNome.Text = descricao;
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
            cbbUf.Text = "";

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
            if (txtNome.Text.Equals(""))
            {
                erroCadastro("Nome");
                txtNome.Focus();
            }
            else if (txtEmail.Text.Equals(""))
            {
                erroCadastro("E-mail");
                txtEmail.Focus();
            }
            else if (mskCpf.Text.Equals("   .   .   -"))
            {
                erroCadastro("CPF");
                mskCpf.Focus();
            }
            else if (mskCelular.Text.Equals("     -"))
            {
                erroCadastro("Celular");
                mskCelular.Focus();
            }
            else if (txtLogradouro.Text.Equals(""))
            {
                erroCadastro("Logadouro");
                txtLogradouro.Focus();
            }
            else if (mskCep.Text.Equals("     -"))
            {
                erroCadastro("CEP");
                mskCep.Focus();
            }
            else if (txtNumero.Text.Equals(""))
            {
                erroCadastro("Nº");
                txtNumero.Focus();
            }
            else if (txtComplemento.Text.Equals(""))
            {
                erroCadastro("Complemento");
                txtComplemento.Focus();
            }
            else if (txtCidade.Text.Equals(""))
            {
                erroCadastro("Cidade");
                txtCidade.Focus();
            }
            else if (txtEstado.Text.Equals(""))
            {
                erroCadastro("Estado");
                txtEstado.Focus();
            }
            else if (cbbUf.Text.Equals(""))
            {
                erroCadastro("UF");
                cbbUf.Focus();
            }
            else
            {
                MessageBox.Show("Cadastro realizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                limparCampos();
                desabilitarCampos();

                btnNovo.Enabled = true;
                btnNovo.Focus();
            }
        }

        private void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarFuncionarios abrir = new frmPesquisarFuncionarios();
            abrir.Show();
            this.Hide();
        }
    }
}
