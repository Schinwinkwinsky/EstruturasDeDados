using EstruturasDeDados.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Caixa de Diálogo de Conteúdo está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace EstruturasDeDados.View
{
    public sealed partial class ListaContentDialog : ContentDialog
    {
        public TipoInsercao TipoInsercao { get; set; }
        public TipoOrdenacao TipoOrdenacao { get; set; }

        public ListaContentDialog()
        {
            this.InitializeComponent();

            InicializarRdioBtns();
        }

        //Inicializa os RadioButtons checados.
        private void InicializarRdioBtns()
        {
            NaoOrdenadaInsercao_RdioBtn.IsChecked = true;
            OrdenadaCrescente_RdioBtn.IsChecked = true;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            TipoInsercao = (bool)NaoOrdenadaInsercao_RdioBtn.IsChecked ? TipoInsercao.Nao_Ordenada : TipoInsercao.Ordenada;
            TipoOrdenacao = (bool)OrdenadaCrescente_RdioBtn.IsChecked ? TipoOrdenacao.Crescente : TipoOrdenacao.Decrescente;
        }

        //Se o NaoOrdenadaInsercao_RdioBtn estiver checado, os sub-botões de ordenação não devem estar ativos.
        private void NaoOrdenadaInsercao_RdioBtn_Checked(Object sender, RoutedEventArgs e)
        {
            OrdenadaCrescente_RdioBtn.IsEnabled = false;
            OrdenadaDecrescente_RdioBtn.IsEnabled = false;
        }

        //Se o NaoOrdenadaInsercao_RdioBtn estiver checado, os sub-botões de ordenação devem estar ativos.
        private void OrdenadaInsercao_RdioBtn_Checked(Object sender, RoutedEventArgs e)
        {
            OrdenadaCrescente_RdioBtn.IsEnabled = true;
            OrdenadaDecrescente_RdioBtn.IsEnabled = true;
        }
    }
}
