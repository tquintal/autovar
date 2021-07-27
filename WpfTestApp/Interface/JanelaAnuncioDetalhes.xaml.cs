using System;
using CamadaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.AccessControl;
using System.ComponentModel;

namespace Autovar.Interface
{
    public partial class JanelaAnuncioDetalhes : Window
    {
        public JanelaAnuncioDetalhes()
        {
            InitializeComponent();
        }

        #region Eventos

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        #endregion

    }
}
