namespace IFSPStore.App.Base
{
    partial class CadastroBase
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
            components = new System.ComponentModel.Container();
            materialTabControl = new ReaLTaiizor.Controls.MaterialTabControl();
            tabPageCadastro = new TabPage();
            panel1 = new Panel();
            btnCancelar = new ReaLTaiizor.Controls.MaterialButton();
            btnSalvar = new ReaLTaiizor.Controls.MaterialButton();
            tabPageConsulta = new TabPage();
            dataGridViewConsulta = new DataGridView();
            btnExcluir = new ReaLTaiizor.Controls.MaterialButton();
            btnEditar = new ReaLTaiizor.Controls.MaterialButton();
            btnNovo = new ReaLTaiizor.Controls.MaterialButton();
            imageList = new ImageList(components);
            materialTabControl.SuspendLayout();
            tabPageCadastro.SuspendLayout();
            panel1.SuspendLayout();
            tabPageConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsulta).BeginInit();
            SuspendLayout();
            // 
            // materialTabControl
            // 
            materialTabControl.Controls.Add(tabPageCadastro);
            materialTabControl.Controls.Add(tabPageConsulta);
            materialTabControl.Depth = 0;
            materialTabControl.Dock = DockStyle.Fill;
            materialTabControl.ImageList = imageList;
            materialTabControl.Location = new Point(3, 85);
            materialTabControl.Margin = new Padding(3, 4, 3, 4);
            materialTabControl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabControl.Multiline = true;
            materialTabControl.Name = "materialTabControl";
            materialTabControl.SelectedIndex = 0;
            materialTabControl.Size = new Size(627, 602);
            materialTabControl.TabIndex = 1;
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(panel1);
            tabPageCadastro.ImageKey = "form.png";
            tabPageCadastro.Location = new Point(4, 29);
            tabPageCadastro.Margin = new Padding(3, 4, 3, 4);
            tabPageCadastro.Name = "tabPageCadastro";
            tabPageCadastro.Padding = new Padding(3, 4, 3, 4);
            tabPageCadastro.Size = new Size(619, 569);
            tabPageCadastro.TabIndex = 0;
            tabPageCadastro.Text = "Cadastro";
            tabPageCadastro.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 501);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 64);
            panel1.TabIndex = 10;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCancelar.Location = new Point(397, 20);
            btnCancelar.Margin = new Padding(5, 8, 5, 8);
            btnCancelar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(105, 36);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSalvar.Depth = 0;
            btnSalvar.HighEmphasis = true;
            btnSalvar.Icon = null;
            btnSalvar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnSalvar.Location = new Point(524, 20);
            btnSalvar.Margin = new Padding(5, 8, 5, 8);
            btnSalvar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.NoAccentTextColor = Color.Empty;
            btnSalvar.Size = new Size(85, 36);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "&Salvar";
            btnSalvar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSalvar.UseAccentColor = false;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // tabPageConsulta
            // 
            tabPageConsulta.Controls.Add(dataGridViewConsulta);
            tabPageConsulta.Controls.Add(btnExcluir);
            tabPageConsulta.Controls.Add(btnEditar);
            tabPageConsulta.Controls.Add(btnNovo);
            tabPageConsulta.ImageKey = "search.png";
            tabPageConsulta.Location = new Point(4, 29);
            tabPageConsulta.Margin = new Padding(3, 4, 3, 4);
            tabPageConsulta.Name = "tabPageConsulta";
            tabPageConsulta.Padding = new Padding(3, 4, 3, 4);
            tabPageConsulta.Size = new Size(619, 569);
            tabPageConsulta.TabIndex = 1;
            tabPageConsulta.Text = "Consulta";
            tabPageConsulta.UseVisualStyleBackColor = true;
            tabPageConsulta.Enter += tabPageConsulta_Enter;
            // 
            // dataGridViewConsulta
            // 
            dataGridViewConsulta.AllowUserToAddRows = false;
            dataGridViewConsulta.AllowUserToDeleteRows = false;
            dataGridViewConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConsulta.Location = new Point(7, 8);
            dataGridViewConsulta.Margin = new Padding(3, 4, 3, 4);
            dataGridViewConsulta.MultiSelect = false;
            dataGridViewConsulta.Name = "dataGridViewConsulta";
            dataGridViewConsulta.ReadOnly = true;
            dataGridViewConsulta.RowHeadersWidth = 51;
            dataGridViewConsulta.RowTemplate.Height = 25;
            dataGridViewConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewConsulta.Size = new Size(603, 476);
            dataGridViewConsulta.TabIndex = 4;
            dataGridViewConsulta.CellDoubleClick += dataGridViewConsulta_CellDoubleClick;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExcluir.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExcluir.Depth = 0;
            btnExcluir.HighEmphasis = true;
            btnExcluir.Icon = null;
            btnExcluir.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnExcluir.Location = new Point(521, 508);
            btnExcluir.Margin = new Padding(5, 8, 5, 8);
            btnExcluir.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.NoAccentTextColor = Color.Empty;
            btnExcluir.Size = new Size(89, 36);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "&Excluir";
            btnExcluir.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnExcluir.UseAccentColor = false;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditar.Depth = 0;
            btnEditar.HighEmphasis = true;
            btnEditar.Icon = null;
            btnEditar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnEditar.Location = new Point(420, 508);
            btnEditar.Margin = new Padding(5, 8, 5, 8);
            btnEditar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnEditar.Name = "btnEditar";
            btnEditar.NoAccentTextColor = Color.Empty;
            btnEditar.Size = new Size(81, 36);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "&Editar";
            btnEditar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditar.UseAccentColor = false;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNovo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNovo.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNovo.Depth = 0;
            btnNovo.HighEmphasis = true;
            btnNovo.Icon = null;
            btnNovo.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnNovo.Location = new Point(325, 508);
            btnNovo.Margin = new Padding(5, 8, 5, 8);
            btnNovo.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNovo.Name = "btnNovo";
            btnNovo.NoAccentTextColor = Color.Empty;
            btnNovo.Size = new Size(71, 36);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "&Novo";
            btnNovo.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNovo.UseAccentColor = false;
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // CadastroBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 691);
            Controls.Add(materialTabControl);
            DrawerTabControl = materialTabControl;
            Margin = new Padding(3, 4, 3, 4);
            Name = "CadastroBase";
            Padding = new Padding(3, 85, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadastroBase";
            materialTabControl.ResumeLayout(false);
            tabPageCadastro.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageConsulta.ResumeLayout(false);
            tabPageConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsulta).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList;
        protected TabPage tabPageCadastro;
        protected DataGridView dataGridViewConsulta;
        protected TabPage tabPageConsulta;
        private Panel panel1;
        public ReaLTaiizor.Controls.MaterialButton btnExcluir;
        public ReaLTaiizor.Controls.MaterialButton btnEditar;
        public ReaLTaiizor.Controls.MaterialButton btnNovo;
        public ReaLTaiizor.Controls.MaterialTabControl materialTabControl;
        public ReaLTaiizor.Controls.MaterialButton btnSalvar;
        public ReaLTaiizor.Controls.MaterialButton btnCancelar;
    }
}