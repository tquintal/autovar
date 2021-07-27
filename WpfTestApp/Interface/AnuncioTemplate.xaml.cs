using Autovar.Interface;
using CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
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
    public partial class AnuncioTemplate : UserControl
    {
        public AnuncioTemplate()
        {
            InitializeComponent();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Automovel automovel = this.DataContext as Automovel;
            if(automovel != null)
            {
                JanelaAnuncioDetalhes anuncioDetalhes = new JanelaAnuncioDetalhes();
                anuncioDetalhes.DataContext = automovel;
                anuncioDetalhes.ShowDialog();
                anuncioDetalhes = null;
            }
        }
    }
}
