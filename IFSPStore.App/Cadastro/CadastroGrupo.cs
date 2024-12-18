using IFSPSotore.Service.Services;
using IFSPSotore.Service.Validators;
using IFSPStore.App.Base;
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
    public partial class CadastroGrupo : CadastroBase
    {
        private readonly IBaseServices<Grupo> _grupoService;
        private List<Grupo>? grupos;

        public CadastroGrupo(IBaseServices<Grupo> grupoService)
        {
            _grupoService = grupoService;
            InitializeComponent();
        }

        private void PreencheObjeto(Grupo grupo)
        {
            grupo.Nome = txtNome.Text;
        }

        protected override void Salvar()
        {
            try
            {
                if (IsAlteracao)
                {
                    if (int.TryParse(txtId.Text, out var id))
                    {
                        var grupo = _grupoService.GetById<Grupo>(id);
                        PreencheObjeto(grupo);
                        grupo = _grupoService.Update<Grupo, Grupo, GrupoValidator>(grupo);
                    }
                }
                else
                {
                    var grupo = new Grupo();
                    PreencheObjeto(grupo);
                    _grupoService.Add<Grupo, Grupo, GrupoValidator>(grupo);

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
                _grupoService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            grupos = _grupoService.Get<Grupo>().ToList();
            dataGridViewConsulta.DataSource = grupos;
            dataGridViewConsulta.Columns["Nome"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            txtId.Text = linha?.Cells["Id"].Value.ToString();
            txtNome.Text = linha?.Cells["Nome"].Value.ToString();
        }
    }
}
