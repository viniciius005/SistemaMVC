using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Entidades;
using View.Modelo;


namespace View
{
    public partial class CadTelefone : Form
    {
        public CadTelefone()
        {
            InitializeComponent();



        }
        // instaciando para objTabela Usar todos os componentes de UsuarioEnt
        UsuarioEnt objTabela = new UsuarioEnt();

        private void LimparCampos()
        {

            txtName.Text = "";
            txtTel.Text = "";
            txtName.Focus();

        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                ListaGrid();
                return;
            }
            try
            {
                LimparCampos();
                txtConsulta.Focus();
                objTabela.Nome = txtConsulta.Text;
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModelo().Consulta(objTabela);

                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar dados" + ex.Message);
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            objTabela.Nome = txtName.Text;
            objTabela.Telefone = txtTel.Text;

            int x = UsuarioModelo.Inserir(objTabela);
            if (x > 0)
            {
                MessageBox.Show(string.Format("Usuario {0} foi inserido!", txtName.Text));
                ListaGrid();
            }
            else
            {
                MessageBox.Show("Não inserido!");
            }
        }
        private void ListaGrid()
        {
            try
            {
                List<UsuarioEnt> Lista = new List<UsuarioEnt>();
                Lista = new UsuarioModelo().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = Lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CadTelefone_Load(object sender, EventArgs e)
        {
            ListaGrid();
        }

        private void grid_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtTel.Text = grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                objTabela.Id = Convert.ToInt32(txtid.Text);
                objTabela.Nome = Convert.ToString(txtName.Text);
                objTabela.Telefone = Convert.ToString(txtTel.Text);

                int x = UsuarioModelo.Editar(objTabela);

                if (x > 0)
                {
                    MessageBox.Show(string.Format("Usuario {0} foi editado!", txtName.Text));
                }
                else
                {
                    MessageBox.Show("Não alterado");
                }
                LimparCampos();
                ListaGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o registo? ", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Operação cancelada");
            }

            else {

                try
                {
                    objTabela.Id = Convert.ToInt32(txtid.Text);
                    objTabela.Nome = Convert.ToString(txtName.Text);
                    objTabela.Telefone = Convert.ToString(txtTel.Text);

                    int x = UsuarioModelo.Excluir(objTabela);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


                finally
                {
                    LimparCampos();
                    ListaGrid();
                    txtid.Clear();
                    txtName.Focus();
                }
            }

        }
    }
}



    

