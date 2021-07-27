using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CamadaNegocio;

namespace Autovar.Interface
{
    public partial class UCListaManutencao : UserControl
    {
        public UCListaManutencao()
        {
            InitializeComponent();
        }

        #region Métodos

        private void Gravar()
        {
            CamadaNegocio.Automovel automovel = this.DataContext as CamadaNegocio.Automovel;

            if (automovel != null)
            {
                string mensagemErro = string.Empty;
                string caminhoErro = string.Empty;

                if (automovel.Gravar(ref mensagemErro, ref caminhoErro) == true)
                {
                    MessageBox.Show(Properties.Resources.GRAVADOSUCESSO); // RESOURCE
                }
                else
                {
                    MessageBox.Show(string.Format("Erro! [{0}]", caminhoErro));
                }
            }
        }

        private void Eliminar()
        {
            CamadaNegocio.Automovel automovel = this.DataContext as CamadaNegocio.Automovel;

            if (automovel != null)
            {
                string mensagemErro = string.Empty;
                string caminhoErro = string.Empty;
                if (automovel.Eliminar(ref mensagemErro, ref caminhoErro) == true)
                {
                    MessageBox.Show("Sucesso!");
                }
                else
                {
                    MessageBox.Show(string.Format("Erro! [{0}]", caminhoErro));
                }
            }
        }

        #endregion

        #region Campos

        private CamadaNegocio.AutomovelCollection automoveisLista;
        private CamadaNegocio.MarcaCollection marcasLista;
        private CamadaNegocio.ModeloCollection modelosLista;

        #endregion

        #region Propriedades

        public CamadaNegocio.AutomovelCollection AutomoveisLista
        {
            get { return this.automoveisLista; }
            set { this.automoveisLista = value; }
        }

        public CamadaNegocio.MarcaCollection MarcasLista
        {
            get { return this.marcasLista; }
            set { this.marcasLista = value; }
        }

        public CamadaNegocio.ModeloCollection ModelosLista
        {
            get { return this.modelosLista; }
            set { this.modelosLista = value; }
        }

        #endregion

        #region Eventos

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MarcasLista = CamadaNegocio.Marca.ObterListaMarcas();

            this.ModelosLista = CamadaNegocio.Modelo.ObterListaModelos();

            this.ComboBoxMarcaIdMarca.ItemsSource = this.MarcasLista;

            this.ComboBoxModeloIdModelo.ItemsSource = this.ModelosLista;
        }

        private void buttonGravar_Click(object sender, RoutedEventArgs e)
        {
            this.Gravar();
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Eliminar();
        }

        #endregion

    }
}
