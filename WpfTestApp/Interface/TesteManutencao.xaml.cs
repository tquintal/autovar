using System;
using CamadaNegocio;
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
using System.Windows.Shapes;

namespace Autovar
{
    /// <summary>
    /// Interaction logic for TesteManutencao.xaml
    /// </summary>
    public partial class TesteManutencao : Window
    {
        public TesteManutencao()
        {
            InitializeComponent();

            CamadaNegocio.Automovel automovel= new CamadaNegocio.Automovel();

            this.DataContext = automovel;//new CamadaNegocio.Automovel();
        }

        #region Métodos

        private void Novo()
        {
            CamadaNegocio.Automovel automovel = this.DataContext as CamadaNegocio.Automovel;
            if (automovel != null)
            {
                automovel.Novo();
                this.DataContext = automovel;
            }
        }

        private void Gravar()
        {
            CamadaNegocio.Automovel automovel = this.DataContext as CamadaNegocio.Automovel;

            // IMPORTANTE:
            if (automovel != null)
            {
                string mensagemErro = string.Empty;
                string caminhoErro = string.Empty;

                if (automovel.Gravar(ref mensagemErro, ref caminhoErro) == true)
                {
                    MessageBox.Show("Sucesso!");
                }
                else
                {
                    MessageBox.Show(string.Format("Erro! [{0}]", caminhoErro));
                }
                //this.DataContext = automovel;
            }
        }

        private void Eliminar()
        {
            CamadaNegocio.Automovel automovel = this.DataContext as CamadaNegocio.Automovel;

            // IMPORTANTE:
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
                //this.DataContext = automovel;
            }
        }

        private void Sair()
        {
            this.Close();
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

            CamadaNegocio.Automovel automovel = new Automovel();
            automovel.Ano = 2000;
            automovel.Combustivel = "Gasolina";
            automovel.Condicao = "Usado";
            automovel.IdMarca = 1;
            automovel.IdModelo = 1;
            automovel.IdAutomovel = 9;
            automovel.KMS = 100000;
            automovel.Preco = 1000;
            automovel.IdUtilizador = 123321;
            automovel.Portas = 5;
            automovel.MediaURL = "https://www.google.pt/";

            this.DataContext = automovel;

            //this.ComboBoxMarca.DataContext = this.MarcasLista;

            //foreach (var modelo of this.modelosLista){
            //    if (modelo = this.)
            //}

            //this.ComboBoxModelo.DataContext = this.ModelosLista;
        }


        private void buttonNovo_Click(object sender, RoutedEventArgs e)
        {
            this.Novo();
        }

        private void buttonGravar_Click(object sender, RoutedEventArgs e)
        {
            this.Gravar();
        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Eliminar();
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            this.Sair();
        }

        #endregion

    }
}
