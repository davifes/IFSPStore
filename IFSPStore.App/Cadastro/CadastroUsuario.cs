using IFSPSotore.Service.Services;
using IFSPSotore.Service.Validators;
using IFSPStore.App.Base;
using IFSPStore.App.Models;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFSPStore.App.Cadastro
{
    public partial class CadastroUsuario : CadastroBase
    {
        private readonly IBaseServices<Usuario> _usuarioService;

        private List<UsuarioModel>? usuarios;
        public CadastroUsuario(IBaseServices<Usuario> usuarioService)
        {
            _usuarioService = usuarioService;
            InitializeComponent();
        }

        private void PreencheObjeto(Usuario usuario)
        {
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Ativo = chkAtivo.Checked;
        }

        protected override void Salvar()
        {
            try
            {
                if (IsAlteracao)
                {
                    if (int.TryParse(txtId.Text, out var id))
                    {
                        var usuario = _usuarioService.GetById<Usuario>(id);
                        PreencheObjeto(usuario);
                        usuario = _usuarioService.Update<Usuario, Usuario, UsuarioValidator>(usuario);
                    }
                }
                else
                {
                    var usuario = new Usuario();
                    PreencheObjeto(usuario);
                    _usuarioService.Add<Usuario, Usuario, UsuarioValidator>(usuario);

                }

                materialTabControl.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _usuarioService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            usuarios = _usuarioService.Get<UsuarioModel>().ToList();
            dataGridViewConsulta.DataSource = usuarios;
            dataGridViewConsulta.Columns["Senha"]!.Visible = false;
            dataGridViewConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            txtId.Text = linha?.Cells["Id"].Value.ToString();
            txtNome.Text = linha?.Cells["Nome"].Value.ToString();
            txtEmail.Text = linha?.Cells["Email"].Value.ToString();
            txtLogin.Text = linha?.Cells["Login"].Value.ToString();
            txtSenha.Text = linha?.Cells["Senha"].Value.ToString();
            chkAtivo.Checked = (bool)(linha?.Cells["Ativo"].Value ?? false);

            txtDataCadastro.Text = DateTime.TryParse(linha?.Cells["DataCadastro"].Value.ToString(), out var dataC)
                ? dataC.ToString("g")
                : "";

            txtDataLogin.Text = DateTime.TryParse(linha?.Cells["DataLogin"].Value.ToString(), out var dataL)
                ? dataL.ToString("g")
                : "";
        }
    }
}
