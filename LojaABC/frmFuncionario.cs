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
//importando a biblioteca do banco de dados(todas as janelas que usam o banco de dados devem importar)
using MySql.Data.MySqlClient;
using MosaicoSolutions.ViaCep;

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
            pesquisarPorNome(descricao);
            habilitarCampos_Pesquisar();
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
            txtBairro.Enabled = false;
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
            txtBairro.Enabled = true;
            cbbUf.Enabled = true;

            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = true;

            btnNovo.Enabled = false;

            txtNome.Focus();
        }
        public void habilitarCampos_Pesquisar()
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
            txtBairro.Enabled = true;
            cbbUf.Enabled = true;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
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
            txtBairro.Clear();
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

        //pesquisar por nome
        public void pesquisarPorNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome = @nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCodigo.Text = DR.GetInt32(0).ToString();
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            mskCpf.Text = DR.GetString(3);
            dtpNascimento.Value = DR.GetDateTime(4);
            mskCelular.Text = DR.GetString(5);

            string sexo = DR.GetString(6);
            if (sexo == "F")
            {
                rdbFeminino.Checked = true;
            }
            else if (sexo == "M")
            {
                rdbMasculino.Checked = true;
            }
            else if (sexo == "N")
            {
                rdbNaoInformar.Checked = true;
            }

            txtLogradouro.Text = DR.GetString(7);
            mskCep.Text = DR.GetString(8);
            txtNumero.Text = DR.GetString(9);
            txtComplemento.Text = DR.GetString(10);
            txtBairro.Text = DR.GetString(11);
            txtCidade.Text = DR.GetString(12);
            cbbUf.Text = DR.GetString(13);

            Conexao.fecharConexao();
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
            else if (txtBairro.Text.Equals(""))
            {
                erroCadastro("Estado");
                txtBairro.Focus();
            }
            else if (cbbUf.Text.Equals(""))
            {
                erroCadastro("UF");
                cbbUf.Focus();
            }
            else
            {
                if (cadastrarFuncionarios() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    limparCampos();
                    desabilitarCampos();

                    btnNovo.Enabled = true;
                    btnNovo.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar funcionário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        public int cadastrarFuncionarios()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbFuncionarios(nome, email, cpf, dataNasc, telCel, sexo, logradouro, cep, numero, complemento, bairro, cidade, uf) values (@nome, @email, @cpf, @dataNasc, @telCel, @sexo, @logradouro, @cep, @numero, @complemento, @bairro, @cidade, @uf);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@dataNasc", MySqlDbType.Date).Value = dtpNascimento.Value;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 10).Value = mskCelular.Text;
            if (rdbFeminino.Checked)
            {
                comm.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = "F";
            }
            if (rdbMasculino.Checked)
            {
                comm.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = "M";
            }
            if (rdbNaoInformar.Checked)
            {
                comm.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = "N";
            }
            comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCep.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 100).Value = txtComplemento.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;
            comm.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = cbbUf.Text;

            comm.Connection = Conexao.obterConexao();
            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
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
        public void buscaCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();

            try
            {
                var endereco = viaCEPService.ObterEndereco(cep);

                txtLogradouro.Text = endereco.Logradouro;
                txtComplemento.Text = endereco.Complemento;
                txtCidade.Text = endereco.Localidade;
                txtBairro.Text = endereco.Bairro;
                cbbUf.Text = endereco.UF;
            }
            catch (Exception)
            {
                MessageBox.Show("CEP inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                mskCep.Clear();
                mskCep.Focus();
            }
        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                buscaCEP(mskCep.Text);
                txtNumero.Focus();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
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
            else if (txtBairro.Text.Equals(""))
            {
                erroCadastro("Estado");
                txtBairro.Focus();
            }
            else if (cbbUf.Text.Equals(""))
            {
                erroCadastro("UF");
                cbbUf.Focus();
            }
            else
            {
                if (alterarFuncionario(Convert.ToInt32(txtCodigo.Text)) == 1)
                {
                    MessageBox.Show("Cadastro alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    limparCampos();
                    desabilitarCampos();

                    btnNovo.Enabled = true;
                    btnNovo.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao alterar o cadastro do funcionário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        //alterando registros do banco de dados
        public int alterarFuncionario(int codFunc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbFuncionarios set nome = @nome, email = @email, cpf = @cpf, dataNasc = @dataNasc, telCel = @telCel, sexo = @sexo, logradouro = @logradouro, cep = @cep, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, uf = @uf where codFunc = @codFunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@dataNasc", MySqlDbType.Date).Value = dtpNascimento.Value;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 10).Value = mskCelular.Text;
            if (rdbFeminino.Checked)
            {
                comm.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = "F";
            }
            if (rdbMasculino.Checked)
            {
                comm.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = "M";
            }
            if (rdbNaoInformar.Checked)
            {
                comm.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = "N";
            }
            comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCep.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 100).Value = txtComplemento.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;
            comm.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = cbbUf.Text;
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32).Value = codFunc;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }
        //excluir registros do banco de dados
        public int excluirFuncionario(int codFunc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbFuncionarios where codFunc = @codFunc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32).Value = codFunc;

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir o funcionário?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                excluirFuncionario(Convert.ToInt32(txtCodigo.Text));
                limparCampos();
            }
            else
            {

            }
        }
    }
}
