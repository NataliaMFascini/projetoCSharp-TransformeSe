using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolhaPagamento
{
    public partial class frmFluxoCaixa : Form
    {
        double salario = 0;
        double planoSaude = 200;
        double clube = 0;
        double liquido = 0;
        double imposto = 0;
        double porcentagem = 0;

        public frmFluxoCaixa()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                salario = Convert.ToDouble(txtSalario.Text);

                if (ckbPlanoSaúde.Checked)
                {
                    salario -= planoSaude;
                }

                salario -= clube;

                if (salario >= 4664.68)
                {
                    porcentagem = 27.5;
                    imposto = salario * 27.5 / 100;
                }
                else if (salario <= 4664.67 && salario >= 3751.06)
                {
                    porcentagem = 22.5;
                    imposto = salario * 22.5 / 100;
                }
                else if (salario <= 3751.05 && salario >= 2826.66)
                {
                    porcentagem = 15;
                    imposto = salario * 15 / 100;
                }
                else if (salario <= 2826.65 && salario >= 2259.21)
                {
                    porcentagem = 7.5;
                    imposto = salario * 7.5 / 100;
                }
                else
                {
                    porcentagem = 0;
                    imposto = 0;
                }

                liquido = salario - imposto;

                txtImposto.Text = "R$ " + imposto.ToString();

                lblPorcentagem.Text = porcentagem.ToString() + "%";

                txtLiquido.Text = "R$ " + liquido.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Favor inserir um salário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void limparCampos()
        {
            txtSalario.Clear();
            ckbPlanoSaúde.Checked = false;
            cbbClube.Text = "";
            txtFolha.Clear();
            txtImposto.Clear();
            txtLiquido.Clear();
            lblClubeCusto.Text = "";
            lblPorcentagem.Text = "0%";

            txtSalario.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {
            txtFolha.Text = "R$ " + txtSalario.Text;
        }

        private void ckbPlanoSaúde_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPlanoSaúde.Checked)
            {
                lblPlanoCusto.Text = "-R$" + planoSaude;
            }
            else
            {
                lblPlanoCusto.Text = "";
            }
        }

        private void cbbClube_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbbClube.SelectedIndex == 0)
            {
                clube = 0;
                lblClubeCusto.Text = "";
            }
            if (cbbClube.SelectedIndex == 1)
            {
                clube = 100;

                lblClubeCusto.Text = "-R$" + clube;
            }
            if (cbbClube.SelectedIndex == 2)
            {
                clube = 50;

                lblClubeCusto.Text = "-R$" + clube;
            }
            if (cbbClube.SelectedIndex == 3)
            {
                clube = 30;

                lblClubeCusto.Text = "-R$" + clube;
            }
        }
    }
}
