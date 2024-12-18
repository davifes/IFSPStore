namespace IFSPStore.App.Cadastro
{
    partial class CadastroProduto
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
            txtNome = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtId = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtPreco = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtUnidadeVenda = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtDataCompra = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cboGrupo = new ReaLTaiizor.Controls.MaterialComboBox();
            tabPageCadastro.SuspendLayout();
            tabPageConsulta.SuspendLayout();
            materialTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(cboGrupo);
            tabPageCadastro.Controls.Add(txtDataCompra);
            tabPageCadastro.Controls.Add(txtUnidadeVenda);
            tabPageCadastro.Controls.Add(txtPreco);
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Controls.Add(txtNome);
            tabPageCadastro.Size = new Size(786, 328);
            tabPageCadastro.Controls.SetChildIndex(txtNome, 0);
            tabPageCadastro.Controls.SetChildIndex(txtId, 0);
            tabPageCadastro.Controls.SetChildIndex(txtPreco, 0);
            tabPageCadastro.Controls.SetChildIndex(txtUnidadeVenda, 0);
            tabPageCadastro.Controls.SetChildIndex(txtDataCompra, 0);
            tabPageCadastro.Controls.SetChildIndex(cboGrupo, 0);
            // 
            // materialTabControl
            // 
            materialTabControl.Size = new Size(794, 361);
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(691, 20);
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(564, 20);
            // 
            // txtNome
            // 
            txtNome.AnimateReadOnly = false;
            txtNome.AutoCompleteMode = AutoCompleteMode.None;
            txtNome.AutoCompleteSource = AutoCompleteSource.None;
            txtNome.BackgroundImageLayout = ImageLayout.None;
            txtNome.CharacterCasing = CharacterCasing.Normal;
            txtNome.Depth = 0;
            txtNome.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNome.HideSelection = true;
            txtNome.Hint = "Nome";
            txtNome.LeadingIcon = null;
            txtNome.Location = new Point(6, 7);
            txtNome.MaxLength = 32767;
            txtNome.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtNome.Name = "txtNome";
            txtNome.PasswordChar = '\0';
            txtNome.PrefixSuffixText = null;
            txtNome.ReadOnly = false;
            txtNome.RightToLeft = RightToLeft.No;
            txtNome.SelectedText = "";
            txtNome.SelectionLength = 0;
            txtNome.SelectionStart = 0;
            txtNome.ShortcutsEnabled = true;
            txtNome.Size = new Size(566, 48);
            txtNome.TabIndex = 11;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.AutoCompleteMode = AutoCompleteMode.None;
            txtId.AutoCompleteSource = AutoCompleteSource.None;
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "ID";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(578, 7);
            txtId.MaxLength = 32767;
            txtId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = false;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(201, 48);
            txtId.TabIndex = 12;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            // 
            // txtPreco
            // 
            txtPreco.AnimateReadOnly = false;
            txtPreco.AutoCompleteMode = AutoCompleteMode.None;
            txtPreco.AutoCompleteSource = AutoCompleteSource.None;
            txtPreco.BackgroundImageLayout = ImageLayout.None;
            txtPreco.CharacterCasing = CharacterCasing.Normal;
            txtPreco.Depth = 0;
            txtPreco.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPreco.HideSelection = true;
            txtPreco.Hint = "Preço";
            txtPreco.LeadingIcon = null;
            txtPreco.Location = new Point(6, 76);
            txtPreco.MaxLength = 32767;
            txtPreco.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPreco.Name = "txtPreco";
            txtPreco.PasswordChar = '\0';
            txtPreco.PrefixSuffixText = null;
            txtPreco.ReadOnly = false;
            txtPreco.RightToLeft = RightToLeft.No;
            txtPreco.SelectedText = "";
            txtPreco.SelectionLength = 0;
            txtPreco.SelectionStart = 0;
            txtPreco.ShortcutsEnabled = true;
            txtPreco.Size = new Size(312, 48);
            txtPreco.TabIndex = 13;
            txtPreco.TabStop = false;
            txtPreco.TextAlign = HorizontalAlignment.Left;
            txtPreco.TrailingIcon = null;
            txtPreco.UseSystemPasswordChar = false;
            // 
            // txtUnidadeVenda
            // 
            txtUnidadeVenda.AnimateReadOnly = false;
            txtUnidadeVenda.AutoCompleteMode = AutoCompleteMode.None;
            txtUnidadeVenda.AutoCompleteSource = AutoCompleteSource.None;
            txtUnidadeVenda.BackgroundImageLayout = ImageLayout.None;
            txtUnidadeVenda.CharacterCasing = CharacterCasing.Normal;
            txtUnidadeVenda.Depth = 0;
            txtUnidadeVenda.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUnidadeVenda.HideSelection = true;
            txtUnidadeVenda.Hint = "Unidade Venda";
            txtUnidadeVenda.LeadingIcon = null;
            txtUnidadeVenda.Location = new Point(324, 76);
            txtUnidadeVenda.MaxLength = 32767;
            txtUnidadeVenda.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtUnidadeVenda.Name = "txtUnidadeVenda";
            txtUnidadeVenda.PasswordChar = '\0';
            txtUnidadeVenda.PrefixSuffixText = null;
            txtUnidadeVenda.ReadOnly = false;
            txtUnidadeVenda.RightToLeft = RightToLeft.No;
            txtUnidadeVenda.SelectedText = "";
            txtUnidadeVenda.SelectionLength = 0;
            txtUnidadeVenda.SelectionStart = 0;
            txtUnidadeVenda.ShortcutsEnabled = true;
            txtUnidadeVenda.Size = new Size(201, 48);
            txtUnidadeVenda.TabIndex = 14;
            txtUnidadeVenda.TabStop = false;
            txtUnidadeVenda.TextAlign = HorizontalAlignment.Left;
            txtUnidadeVenda.TrailingIcon = null;
            txtUnidadeVenda.UseSystemPasswordChar = false;
            // 
            // txtDataCompra
            // 
            txtDataCompra.AnimateReadOnly = false;
            txtDataCompra.AutoCompleteMode = AutoCompleteMode.None;
            txtDataCompra.AutoCompleteSource = AutoCompleteSource.None;
            txtDataCompra.BackgroundImageLayout = ImageLayout.None;
            txtDataCompra.CharacterCasing = CharacterCasing.Normal;
            txtDataCompra.Depth = 0;
            txtDataCompra.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDataCompra.HideSelection = true;
            txtDataCompra.Hint = "Data Compra";
            txtDataCompra.LeadingIcon = null;
            txtDataCompra.Location = new Point(531, 76);
            txtDataCompra.MaxLength = 32767;
            txtDataCompra.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtDataCompra.Name = "txtDataCompra";
            txtDataCompra.PasswordChar = '\0';
            txtDataCompra.PrefixSuffixText = null;
            txtDataCompra.ReadOnly = false;
            txtDataCompra.RightToLeft = RightToLeft.No;
            txtDataCompra.SelectedText = "";
            txtDataCompra.SelectionLength = 0;
            txtDataCompra.SelectionStart = 0;
            txtDataCompra.ShortcutsEnabled = true;
            txtDataCompra.Size = new Size(252, 48);
            txtDataCompra.TabIndex = 15;
            txtDataCompra.TabStop = false;
            txtDataCompra.Text = "__/__/____";
            txtDataCompra.TextAlign = HorizontalAlignment.Left;
            txtDataCompra.TrailingIcon = null;
            txtDataCompra.UseSystemPasswordChar = false;
            // 
            // cboGrupo
            // 
            cboGrupo.AutoResize = false;
            cboGrupo.BackColor = Color.FromArgb(255, 255, 255);
            cboGrupo.Depth = 0;
            cboGrupo.DrawMode = DrawMode.OwnerDrawVariable;
            cboGrupo.DropDownHeight = 174;
            cboGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrupo.DropDownWidth = 121;
            cboGrupo.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboGrupo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboGrupo.FormattingEnabled = true;
            cboGrupo.Hint = "Grupo";
            cboGrupo.IntegralHeight = false;
            cboGrupo.ItemHeight = 43;
            cboGrupo.Location = new Point(6, 130);
            cboGrupo.MaxDropDownItems = 4;
            cboGrupo.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboGrupo.Name = "cboGrupo";
            cboGrupo.Size = new Size(773, 49);
            cboGrupo.StartIndex = 0;
            cboGrupo.TabIndex = 16;
            // 
            // CadastroProduto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Location = new Point(0, 0);
            Name = "CadastroProduto";
            Text = "Cadastro de Produto";
            tabPageCadastro.ResumeLayout(false);
            tabPageConsulta.ResumeLayout(false);
            tabPageConsulta.PerformLayout();
            materialTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialComboBox cboGrupo;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtDataCompra;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtUnidadeVenda;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtPreco;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtNome;
    }
}