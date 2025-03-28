namespace FolhaPagamento
{
    partial class frmFluxoCaixa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDataFolha = new System.Windows.Forms.Label();
            this.dtpDataFolha = new System.Windows.Forms.DateTimePicker();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.ckbPlanoSaúde = new System.Windows.Forms.CheckBox();
            this.lblClube = new System.Windows.Forms.Label();
            this.cbbClube = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblFolha = new System.Windows.Forms.Label();
            this.lblImposto = new System.Windows.Forms.Label();
            this.lblLiquido = new System.Windows.Forms.Label();
            this.txtFolha = new System.Windows.Forms.TextBox();
            this.txtImposto = new System.Windows.Forms.TextBox();
            this.txtLiquido = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblPorcentagem = new System.Windows.Forms.Label();
            this.lblPlanoCusto = new System.Windows.Forms.Label();
            this.lblClubeCusto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDataFolha
            // 
            this.lblDataFolha.AutoSize = true;
            this.lblDataFolha.Location = new System.Drawing.Point(12, 9);
            this.lblDataFolha.Name = "lblDataFolha";
            this.lblDataFolha.Size = new System.Drawing.Size(74, 13);
            this.lblDataFolha.TabIndex = 0;
            this.lblDataFolha.Text = "Data da Folha";
            // 
            // dtpDataFolha
            // 
            this.dtpDataFolha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFolha.Location = new System.Drawing.Point(12, 25);
            this.dtpDataFolha.Name = "dtpDataFolha";
            this.dtpDataFolha.Size = new System.Drawing.Size(100, 20);
            this.dtpDataFolha.TabIndex = 7;
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Location = new System.Drawing.Point(12, 48);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(43, 13);
            this.lblSalario.TabIndex = 2;
            this.lblSalario.Text = "Salário*";
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(12, 64);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(100, 20);
            this.txtSalario.TabIndex = 1;
            this.txtSalario.TextChanged += new System.EventHandler(this.txtSalario_TextChanged);
            // 
            // ckbPlanoSaúde
            // 
            this.ckbPlanoSaúde.AutoSize = true;
            this.ckbPlanoSaúde.Location = new System.Drawing.Point(12, 90);
            this.ckbPlanoSaúde.Name = "ckbPlanoSaúde";
            this.ckbPlanoSaúde.Size = new System.Drawing.Size(102, 17);
            this.ckbPlanoSaúde.TabIndex = 3;
            this.ckbPlanoSaúde.Text = "Plano de Saúde";
            this.ckbPlanoSaúde.UseVisualStyleBackColor = true;
            this.ckbPlanoSaúde.CheckedChanged += new System.EventHandler(this.ckbPlanoSaúde_CheckedChanged);
            // 
            // lblClube
            // 
            this.lblClube.AutoSize = true;
            this.lblClube.Location = new System.Drawing.Point(12, 110);
            this.lblClube.Name = "lblClube";
            this.lblClube.Size = new System.Drawing.Size(78, 13);
            this.lblClube.TabIndex = 5;
            this.lblClube.Text = "Clube de Lazer";
            // 
            // cbbClube
            // 
            this.cbbClube.FormattingEnabled = true;
            this.cbbClube.Items.AddRange(new object[] {
            "",
            "Clube A",
            "Clube B",
            "Clube C"});
            this.cbbClube.Location = new System.Drawing.Point(12, 126);
            this.cbbClube.Name = "cbbClube";
            this.cbbClube.Size = new System.Drawing.Size(100, 21);
            this.cbbClube.TabIndex = 2;
            this.cbbClube.Text = "Selecione";
            this.cbbClube.SelectionChangeCommitted += new System.EventHandler(this.cbbClube_SelectionChangeCommitted);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(12, 153);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(305, 23);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "&Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblFolha
            // 
            this.lblFolha.AutoSize = true;
            this.lblFolha.Location = new System.Drawing.Point(171, 9);
            this.lblFolha.Name = "lblFolha";
            this.lblFolha.Size = new System.Drawing.Size(68, 13);
            this.lblFolha.TabIndex = 8;
            this.lblFolha.Text = "Salário Folha";
            // 
            // lblImposto
            // 
            this.lblImposto.AutoSize = true;
            this.lblImposto.Location = new System.Drawing.Point(171, 48);
            this.lblImposto.Name = "lblImposto";
            this.lblImposto.Size = new System.Drawing.Size(94, 13);
            this.lblImposto.TabIndex = 9;
            this.lblImposto.Text = "Imposto de Renda";
            // 
            // lblLiquido
            // 
            this.lblLiquido.AutoSize = true;
            this.lblLiquido.Location = new System.Drawing.Point(171, 87);
            this.lblLiquido.Name = "lblLiquido";
            this.lblLiquido.Size = new System.Drawing.Size(78, 13);
            this.lblLiquido.TabIndex = 10;
            this.lblLiquido.Text = "Salário Líquido";
            // 
            // txtFolha
            // 
            this.txtFolha.Enabled = false;
            this.txtFolha.Location = new System.Drawing.Point(171, 25);
            this.txtFolha.Name = "txtFolha";
            this.txtFolha.Size = new System.Drawing.Size(100, 20);
            this.txtFolha.TabIndex = 5;
            // 
            // txtImposto
            // 
            this.txtImposto.Enabled = false;
            this.txtImposto.Location = new System.Drawing.Point(171, 64);
            this.txtImposto.Name = "txtImposto";
            this.txtImposto.Size = new System.Drawing.Size(100, 20);
            this.txtImposto.TabIndex = 6;
            // 
            // txtLiquido
            // 
            this.txtLiquido.Enabled = false;
            this.txtLiquido.Location = new System.Drawing.Point(171, 103);
            this.txtLiquido.Name = "txtLiquido";
            this.txtLiquido.Size = new System.Drawing.Size(100, 20);
            this.txtLiquido.TabIndex = 7;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(12, 182);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(305, 23);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(12, 211);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(305, 23);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblPorcentagem
            // 
            this.lblPorcentagem.AutoSize = true;
            this.lblPorcentagem.Location = new System.Drawing.Point(277, 67);
            this.lblPorcentagem.Name = "lblPorcentagem";
            this.lblPorcentagem.Size = new System.Drawing.Size(21, 13);
            this.lblPorcentagem.TabIndex = 11;
            this.lblPorcentagem.Text = "0%";
            // 
            // lblPlanoCusto
            // 
            this.lblPlanoCusto.AutoSize = true;
            this.lblPlanoCusto.ForeColor = System.Drawing.Color.Red;
            this.lblPlanoCusto.Location = new System.Drawing.Point(120, 91);
            this.lblPlanoCusto.Name = "lblPlanoCusto";
            this.lblPlanoCusto.Size = new System.Drawing.Size(0, 13);
            this.lblPlanoCusto.TabIndex = 12;
            // 
            // lblClubeCusto
            // 
            this.lblClubeCusto.AutoSize = true;
            this.lblClubeCusto.ForeColor = System.Drawing.Color.Red;
            this.lblClubeCusto.Location = new System.Drawing.Point(120, 129);
            this.lblClubeCusto.Name = "lblClubeCusto";
            this.lblClubeCusto.Size = new System.Drawing.Size(0, 13);
            this.lblClubeCusto.TabIndex = 13;
            // 
            // frmFluxoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 243);
            this.Controls.Add(this.lblClubeCusto);
            this.Controls.Add(this.lblPlanoCusto);
            this.Controls.Add(this.lblPorcentagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.txtLiquido);
            this.Controls.Add(this.txtImposto);
            this.Controls.Add(this.txtFolha);
            this.Controls.Add(this.lblLiquido);
            this.Controls.Add(this.lblImposto);
            this.Controls.Add(this.lblFolha);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.cbbClube);
            this.Controls.Add(this.lblClube);
            this.Controls.Add(this.ckbPlanoSaúde);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.dtpDataFolha);
            this.Controls.Add(this.lblDataFolha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFluxoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folha de Pagamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataFolha;
        private System.Windows.Forms.DateTimePicker dtpDataFolha;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.CheckBox ckbPlanoSaúde;
        private System.Windows.Forms.Label lblClube;
        private System.Windows.Forms.ComboBox cbbClube;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblFolha;
        private System.Windows.Forms.Label lblImposto;
        private System.Windows.Forms.Label lblLiquido;
        private System.Windows.Forms.TextBox txtFolha;
        private System.Windows.Forms.TextBox txtImposto;
        private System.Windows.Forms.TextBox txtLiquido;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblPorcentagem;
        private System.Windows.Forms.Label lblPlanoCusto;
        private System.Windows.Forms.Label lblClubeCusto;
    }
}