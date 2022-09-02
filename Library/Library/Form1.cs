using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public struct years
    {
        public string dia;
        public int mes, anyo;
    }

    public struct Libros
    {
        public string titulo;
        public int edicion;
        public string genero;
        public string autor;
        public string pais;
        public years year;
    }

    public partial class Form1 : Form
    {
        // Declaracion del Array tipo estructura
        Libros[] Books = new Libros[100];

        // Variables de uso global 
        int indice = 0, iModificar;

        public Form1()
        {
            InitializeComponent();
        }

        // LIMPIA LOS TEXBOX
        void ClearTexBox()
        {
            txtTitulo.Clear();
            txtEdicion.Clear();
            cbGenero.Text = "";
            txtAutor.Clear();
            txtPais.Clear();
            txtDia.Clear();
        }

        // INSERTAR
        public void Registrar()
        {
            try
            {
                if (txtTitulo.Text != null && txtEdicion.Text != null && cbGenero.Text != null && txtAutor.Text != null && txtPais.Text != null && txtDia.Text != null)
                {
                    Books[indice].titulo = txtTitulo.Text;
                    Books[indice].edicion = int.Parse(txtEdicion.Text);
                    Books[indice].genero = cbGenero.Text;
                    Books[indice].autor = txtAutor.Text;
                    Books[indice].pais = txtPais.Text;
                    Books[indice].year.dia = txtDia.Text;
                    Books[indice].year.mes = int.Parse(txtDia.Text);
                    Books[indice].year.anyo = int.Parse(txtDia.Text);
                    indice++;
                }
                else
                {
                    MessageBox.Show("Debes llenar todos los campos!");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al registrar el libro ", e.Message);
            }
        }

        // MOSTRAR
        void MostrarRegistros()
        {
            try
            {
                string Lista = "";

                for (int i = 0; i < indice; i++)
                {
                    Lista = Lista + i + "-" +
                        Books[i].titulo + " " +
                        Books[i].edicion + " " +
                        Books[i].genero + " " +
                        Books[i].autor + " " +
                        Books[i].pais + " " +
                        Books[i].year + "\n";
                }
                RtbListaRegistros.Text = Lista;
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al cargar los datos ", e.Message);
            }
        }

        // BUSCAR
        void BuscarRegistro()
        {
            try
            {
                if (txtBuscar.Text != null)
                {
                    for (int i = 0; i < indice; i++)
                    {
                        if (Books[i].titulo == txtBuscar.Text)
                        {
                            txtTitulo.Text = Books[i].titulo;
                            txtEdicion.Text = Convert.ToString(Books[i].edicion);
                            cbGenero.SelectedText = Books[i].genero;
                            txtAutor.Text = Books[i].autor;
                            txtPais.Text = Books[i].pais;
                            txtDia.Text = Convert.ToString(Books[i].year);
                            iModificar = i;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El registro no existe.");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la busqueda del registro! " + e.Message);
            }
        }

        // EDITAR
        public void GuardarCambios()
        {
            try
            {
                if (txtTitulo.Text != null && txtEdicion.Text != null && cbGenero.Text != null && txtAutor.Text != null && txtPais.Text != null && txtDia.Text != null)
                {
                    Books[iModificar].titulo = txtTitulo.Text;
                    Books[iModificar].edicion = int.Parse(txtEdicion.Text);
                    Books[iModificar].genero = cbGenero.Text;
                    Books[iModificar].autor = txtAutor.Text;
                    Books[iModificar].pais = txtPais.Text;
                    Books[iModificar].year.dia = txtDia.Text;
                    Books[iModificar].year.mes = int.Parse(txtDia.Text);
                    Books[iModificar].year.anyo = int.Parse(txtDia.Text);
                }
                else
                {
                    MessageBox.Show("Debes llenar todos los campos!");
                }

                // MessageBox.Show("Indice/Id a modificar: " + iModificar); // Mostrar indice del registro a editar
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al modificar registro: " + e.Message);
            }
        }

        // INSERTAR
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
            MostrarRegistros();
            ClearTexBox();
        }

        // EDITAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
        }

        // BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarRegistro();
        }

        // LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearTexBox();
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = iModificar; i < indice; i++)
                {
                    Books[i].titulo = Books[i+1].titulo;
                    Books[i].edicion = Books[i+1].edicion;
                    Books[i].genero = Books[i+1].genero;
                    Books[i].autor = Books[i+1].autor;
                    Books[i].pais = Books[i+1].pais;
                    Books[i].year = Books[i+1].year;
                }
                indice--;

                ClearTexBox();
                MostrarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el registro: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {          
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            ClearTexBox();
            GuardarCambios();
            MostrarRegistros();
        } 
    }
}
