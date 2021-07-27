using CamadaNegocio;
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

namespace Autovar
{
    /// <summary>
    /// Interaction logic for UserControlPaginaInicial.xaml
    /// </summary>
    public partial class UserControlPaginaInicial : UserControl
    {
        public UserControlPaginaInicial()
        {
            InitializeComponent();

            //Automovel automovel = new Automovel();
            //automovel.IdAutomovel = 2;
            //automovel.IdMarca = 3;
            //this.DataContext = automovel;

            this.PreencherListaAutomoveis();

        }

        private void PreencherListaAutomoveis()
        {

            this.listaAutomoveisWP.Children.Clear();

            AutomovelCollection automoveis = Automovel.ObterListaAutomoveis();
            if (automoveis != null)
            {
                foreach (Automovel automovel in automoveis)
                {
                    AnuncioTemplate anuncioTemplate = new AnuncioTemplate();
                    anuncioTemplate.DataContext = automovel;
                    this.listaAutomoveisWP.Children.Add(anuncioTemplate);
                }
            }

        }

        #region Campos
        
        private CamadaNegocio.AutomovelCollection automoveis; 

        #endregion

        #region Propriedades

        public CamadaNegocio.AutomovelCollection Automoveis
        {
            get { return this.automoveis; }
            set { this.automoveis = value; }
        } 

        #endregion

        #region Eventos

        private void textBoxFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textoFiltro = this.textBoxFiltro.Text;

            CamadaNegocio.AutomovelCollection automoveisFiltrados = new CamadaNegocio.AutomovelCollection();

            automoveisFiltrados = automoveisFiltrados.Filtrar(textoFiltro);

            this.listaAutomoveisWP.DataContext = automoveisFiltrados;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Automoveis = CamadaNegocio.Automovel.ObterListaAutomoveis();

            //this.listaAutomoveisWP.DataContext = this.Automoveis;
        }

        #endregion

    }
}
