// Updated by XamlIntelliSenseFileGenerator 29/05/2020 19:46:07
#pragma checksum "..\..\ManutencaoTeste.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "65AA252963D1A90CC641B15A81B1A43B37A0896D52071E5873CECA802BB1424F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfTestApp;


namespace WpfTestApp
{


    /// <summary>
    /// ManutencaoTeste
    /// </summary>
    public partial class ManutencaoTeste : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfTestApp;component/manutencaoteste.xaml", System.UriKind.Relative);

#line 1 "..\..\ManutencaoTeste.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox textBoxCodigoEquipa;
        internal System.Windows.Controls.Button buttonNovo;
        internal System.Windows.Controls.TextBox textBoxCodigoNome;
        internal System.Windows.Controls.Button buttonGravar;
        internal System.Windows.Controls.TextBox textBoxNumeroJogadores;
        internal System.Windows.Controls.Button buttonEliminar;
        internal System.Windows.Controls.Button buttonSair;
    }
}
