using Autovar.Interface;
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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            atualizarPagina();
        }

        #region Eventos

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            this.OpenMenu(true);
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            this.OpenMenu(false);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            atualizarPagina();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            TesteManutencao testeManutencao = new TesteManutencao();
            testeManutencao.ShowDialog();
            testeManutencao = null;
        }

        private void MinimizarAPP_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            WindowSobre windowsobre = new WindowSobre();
            windowsobre.ShowDialog();
            windowsobre = null;
        }

        private void FecharAPP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        private void OpenMenu(bool open)
        {
            ButtonCloseMenu.Visibility = open ? Visibility.Visible : Visibility.Collapsed;
            ButtonOpenMenu.Visibility = open ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usercontrol = null;
            GridPrincipal.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemInicio":
                    usercontrol = new UserControlPaginaInicial();
                    GridPrincipal.Children.Add(usercontrol);
                    break;
                case "ItemManutencao":
                    usercontrol = new UserControlManutencao();
                    GridPrincipal.Children.Add(usercontrol);
                    break;
                case "ItemPesquisa":
                    usercontrol = new UserControlPesquisa();
                    GridPrincipal.Children.Add(usercontrol);
                    break;
                case "ItemDefinicoes":
                    usercontrol = new UserControlDefinicoes();
                    GridPrincipal.Children.Add(usercontrol);
                    break;
                case "ItemTeste":
                    GridPrincipal.Children.Clear();
                    break;
            }
        }

        private void atualizarPagina()
        {
            UserControl usercontrol = null;
            usercontrol = new UserControlPaginaInicial();
            GridPrincipal.Children.Add(usercontrol);
        }

    }
}
