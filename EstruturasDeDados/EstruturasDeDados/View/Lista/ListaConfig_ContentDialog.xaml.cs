using EstruturasDeDados.Model.Listas;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// O modelo de item de Caixa de Diálogo de Conteúdo está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace EstruturasDeDados.View.Lista
{
    public sealed partial class ListaConfig_ContentDialog : ContentDialog
    {
        public TipoInsercao TipoInsercao { get; set; }
        public TipoOrdenacao TipoOrdenacao { get; set; }

        public ListaConfig_ContentDialog()
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
