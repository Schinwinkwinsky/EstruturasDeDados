using EstruturasDeDados.Model;
using EstruturasDeDados.Model.Listas;
using System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace EstruturasDeDados.View.Lista
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class ListaPagina : Page
    {
        public TipoInsercao TipoInsercao { get; set; }
        public TipoOrdenacao TipoOrdenacao { get; set; }
        public ListaComCalda Lista { get; set; }

        public ListaPagina()
        {
            this.InitializeComponent();

            Inicializar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }

        //Inicializa a Lista e alguns elementos visuais.
        private async void Inicializar()
        {
            var dialog = new ListaContentDialog();
            await dialog.ShowAsync();

            TipoInsercao = dialog.TipoInsercao;

            if (TipoInsercao == TipoInsercao.Ordenada)
            {
                TipoOrdenacao = dialog.TipoOrdenacao;

                if (TipoOrdenacao == TipoOrdenacao.Crescente)
                {
                    Lista = new ListaOrdenadaCrescenteComCalda();
                    Titulo_TextBlock.Text = "Lista Ordenada Crescente";
                }
                else
                {
                    Lista = new ListaOrdenadaDecrescenteComCalda();
                    Titulo_TextBlock.Text = "Lista Ordenada Decrescente";
                }

                PosicaoInserir_TextBox.IsEnabled = false;

                //Põe o cursor em ValorInserir_TextBox.
                ValorInserir_TextBox.Focus(FocusState.Programmatic);
            }
            else
            {
                Lista = new ListaNaoOrdenadaComCalda();
                Titulo_TextBlock.Text = "Lista Não Ordenada";

                //Põe o cursor em PosicaoInserir_TextBox.
                PosicaoInserir_TextBox.Focus(FocusState.Programmatic);
            }


        }

        private void Hamburguer_Btn_Click(Object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void Home_Btn_Click(Object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PaginaInicial));
        }

        private async void Info_Btn_ClickAsync(Object sender, RoutedEventArgs e)
        {
            await new InfoContentDialog().ShowAsync();
        }

        private void PosicaoRemover_TextBox_GotFocus(Object sender, RoutedEventArgs e)
        {
            ValorRemover_TextBox.Text = "";
        }

        private void ValorRemover_TextBox_GotFocus(Object sender, RoutedEventArgs e)
        {
            PosicaoRemover_TextBox.Text = "";
        }

        private void PosicaoInserir_TextBox_KeyDown(Object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Inserir_Btn_ClickAsync(sender, e);

                PosicaoInserir_TextBox.Focus(FocusState.Programmatic);

                e.Handled = true;
            }
        }

        private void ValorInserir_TextBox_KeyDown(Object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Inserir_Btn_ClickAsync(sender, e);

                if (PosicaoInserir_TextBox.IsEnabled)
                {
                    PosicaoInserir_TextBox.Focus(FocusState.Programmatic);
                }
                else
                {
                    ValorInserir_TextBox.Focus(FocusState.Programmatic);
                }

                e.Handled = true;
            }
        }

        private void PosicaoRemover_TextBox_KeyDown(Object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Remover_Btn_ClickAsync(sender, e);

                PosicaoRemover_TextBox.Focus(FocusState.Programmatic);

                e.Handled = true;
            }
        }

        private void ValorRemover_TextBox_KeyDown(Object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Remover_Btn_ClickAsync(sender, e);

                ValorRemover_TextBox.Focus(FocusState.Programmatic);

                e.Handled = true;
            }
        }

        private async void Inserir_Btn_ClickAsync(Object sender, RoutedEventArgs e)
        {
            uint posicao;
            int valor;

            if (PosicaoInserir_TextBox.IsEnabled)
            {
                try
                {
                    posicao = uint.Parse(PosicaoInserir_TextBox.Text);
                    valor = int.Parse(ValorInserir_TextBox.Text);

                    Lista.InserirNo(new No(valor), posicao);

                    DesenharLista();
                }
                catch (FormatException)
                {
                    await new MessageDialog("Posição ou Valor inválido!").ShowAsync();
                }
                catch (OverflowException)
                {
                    await new MessageDialog("Posição inválida!").ShowAsync();
                }
                catch (IndexOutOfRangeException exception)
                {
                    await new MessageDialog(exception.Message).ShowAsync();
                }
            }
            else
            {
                try
                {
                    valor = int.Parse(ValorInserir_TextBox.Text);

                    Lista.InserirNo(new No(valor));

                    DesenharLista();
                }
                catch (FormatException)
                {
                    await new MessageDialog("Valor inválido!").ShowAsync();
                }
            }

            PosicaoInserir_TextBox.Text = "";
            ValorInserir_TextBox.Text = "";
        }

        private async void Remover_Btn_ClickAsync(Object sender, RoutedEventArgs e)
        {
            uint posicao;
            int valor;

            try
            {
                if (PosicaoRemover_TextBox.Text != "")
                {
                    posicao = uint.Parse(PosicaoRemover_TextBox.Text);

                    Lista.RemoverNoDaPosicao(posicao);
                }
                else
                {
                    valor = int.Parse(ValorRemover_TextBox.Text);

                    Lista.RemoverNoPorValor(valor);
                }

                DesenharLista();
            }
            catch (FormatException)
            {
                await new MessageDialog("Informe a Posição ou o Valor a ser removido!").ShowAsync();
            }
            catch (OverflowException)
            {
                await new MessageDialog("Posição inválida!").ShowAsync();
            }
            catch (IndexOutOfRangeException exception)
            {
                await new MessageDialog(exception.Message).ShowAsync();
            }
            catch (ArgumentException exception)
            {
                await new MessageDialog(exception.Message).ShowAsync();
            }

            PosicaoRemover_TextBox.Text = "";
            ValorRemover_TextBox.Text = "";
        }

        //Desenha a Lista no Canvas.
        private void DesenharLista()
        {
            //Limpa o Canvas.
            canvas.Children.Clear();

            if (!Lista.Vazia())
            {
                //Distância Esquerda de cada Nó.
                int distanciaEsquerda = 30;

                //Desenha a Cabeça no Canvas.
                var aux = Lista.Cabeca;
                DesenharNo(aux, distanciaEsquerda, 30);

                //Prepara a Distância para o próximo Nó.
                distanciaEsquerda += 120;

                while (aux.ProximoNo != null)
                {
                    aux = aux.ProximoNo;
                    DesenharNo(aux, distanciaEsquerda, 30);
                    distanciaEsquerda += 120;
                }
            }            
        }

        //Desenha um Nó no Canvas.
        private void DesenharNo(No no, int distanciaEsquerda, int distanciaSuperior)
        {
            Canvas c = new Canvas();
            c.Height = 80;
            c.Width = 80;

            Ellipse e = new Ellipse();
            e.Height = 80;
            e.Width = 80;
            e.Fill = new SolidColorBrush(Colors.Aqua);

            TextBlock t = new TextBlock();
            t.Text = no.Valor.ToString();
            t.Width = 80;
            t.TextAlignment = TextAlignment.Center;
            Canvas.SetTop(t, 28);

            c.Children.Add(e);
            c.Children.Add(t);

            Canvas.SetLeft(c, distanciaEsquerda);
            Canvas.SetTop(c, distanciaSuperior);

            canvas.Children.Add(c);
        }
    }
}

