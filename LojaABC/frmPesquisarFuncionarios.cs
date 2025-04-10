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
using MySql.Data.MySqlClient;

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
        //criando o metodo para pesquisar por codigo
        public void pesquisarPorCodigo(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome from tbFuncionarios where codFunc = @codFunc";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32).Value = codigo;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader(); //somente quando é o select
            DR.Read();

            ltbPesquisar.Items.Add(DR.GetString(0));

            Conexao.fecharConexao();
        }
        //pesquisar por nome
        public void pesquisarPorNome(string descricao)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome from tbFuncionarios where nome like '%" + descricao + "%';";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = descricao;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            while (DR.Read())
            {
                ltbPesquisar.Items.Add(DR.GetString(0));
            }

            Conexao.fecharConexao();
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
                if (rdbCodigo.Checked)
                {
                    //ltbPesquisar.Items.Clear();
                    pesquisarPorCodigo(Convert.ToInt32(txtDescricao.Text));
                    limparCamposPesquisar();
                }
                if (rdbNome.Checked)
                {
                    //ltbPesquisar.Items.Clear();
                    pesquisarPorNome(txtDescricao.Text);
                    limparCamposPesquisar();
                }
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
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmFuncionario abrir = new frmFuncionario();
            abrir.Show();
            this.Hide();
        }
    }
}
