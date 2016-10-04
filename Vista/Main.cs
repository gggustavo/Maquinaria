using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Main : Form
    {

        private readonly Controladora.MaquinaController _controller = new Controladora.MaquinaController();
        private Modelo.Maquina maquina = null;

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            maquinaBindingSource.DataSource = _controller.ObtenerMaquinas();

            base.OnLoad(e);
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            maquina = new Modelo.Maquina();
            EstadoEdicion();
        }

        private void EstadoEdicion()
        {
            aceptar.Enabled = true;
            cancelar.Enabled = true;

            agregar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Enabled = false;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                maquina.NroInventario = Convert.ToInt32(nroInventario.Text);
                maquina.Marca = marca.Text;
                maquina.Modelo = modelo.Text;
                maquina.Fallas = Convert.ToInt32(fallas.Text);
                maquina.Anio = anio.Value;

                maquina.CalcularEstado();
                if (maquina.IdMaquinaria == 0)
                    _controller.AgregarMaquina(maquina);
                else
                    _controller.ActualizarMaquina(maquina);

                MessageBox.Show("Se ejecuto correctamente");
                maquinaBindingSource.DataSource = _controller.ObtenerMaquinas();


                EstadoInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EstadoInicial()
        {
            aceptar.Enabled = false;
            cancelar.Enabled = false;

            agregar.Enabled = true;
            modificar.Enabled = true;
            eliminar.Enabled = true;

            nroInventario.Text = string.Empty;
            marca.Text = string.Empty;
            modelo.Text = string.Empty;
            fallas.Text = string.Empty;
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (maquinaBindingSource.Current == null) MessageBox.Show("Seleccione un elemento de la grilla");

            var maquina = (Modelo.Maquina)maquinaBindingSource.Current;

            _controller.EliminarMaquina(maquina);

            MessageBox.Show("Se ejecuto correctamente");
            maquinaBindingSource.DataSource = _controller.ObtenerMaquinas();

            EstadoInicial();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (maquinaBindingSource.Current == null) MessageBox.Show("Seleccione un elemento de la grilla");

            maquina = (Modelo.Maquina)maquinaBindingSource.Current;

            nroInventario.Text =  maquina.NroInventario.ToString();
            marca.Text = maquina.Marca;
            modelo.Text = maquina.Modelo;
            fallas.Text = maquina.Fallas.ToString();
            anio.Value = maquina.Anio;

            EstadoEdicion();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            if (maquinaBindingSource.Current == null) MessageBox.Show("Seleccione un elemento de la grilla");
            maquina = (Modelo.Maquina)maquinaBindingSource.Current;
            maquina.Fallas = 0;
            maquina.CalcularEstado();
            _controller.ActualizarMaquina(maquina);
            MessageBox.Show("Se ejecuto correctamente");
            maquinaBindingSource.DataSource = _controller.ObtenerMaquinas();
        }
    }
}
