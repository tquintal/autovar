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
    /// Interaction logic for UserControlPesquisa.xaml
    /// </summary>
    public partial class UserControlPesquisa : UserControl
    {
        public UserControlPesquisa()
        {
            InitializeComponent();

            Automovel automovel = new Automovel();
            automovel.IdAutomovel = 2;
            automovel.IdMarca = 3;
            this.DataContext = automovel;

            this.PreencherListaAutomoveis();
        }

        private void PreencherListaAutomoveis()
        {
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

    }
}
