using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MauiRfidSample.MVVM.Models;

namespace MauiRfidSample.MVVM.Views
{
    public partial class ExecucaoConferenciaPage : ContentPage
    {
        private Ordem _ordem;
        public ObservableCollection<string> EpcsNaoEsperadosList { get; set; }

        public ExecucaoConferenciaPage(Ordem ordem)
        {
            InitializeComponent();
            _ordem = ordem;
            EpcsNaoEsperadosList = new ObservableCollection<string>();
            BindingContext = this;
            CarregarDetalhesOrdem();
        }

        private void CarregarDetalhesOrdem()
        {
            OrdemNumero.Text = $"Ordem: {_ordem.Numero}";
            ClienteNome.Text = $"Cliente: {_ordem.Cliente.Nome}";
            Quantidade.Text = $"Quantidade: 0";
            Status.Text = $"Status: {_ordem.Status}";
        }

        private async void OnIniciarLeituraEPCsClicked(object sender, EventArgs e)
        {
            var epcsLidos = new List<string> { "EPC1", "EPC2", "EPC3" };
            // Simular a leitura de EPCs para testes
            await Task.Run(() =>
            {
                EpcsNaoEsperadosList.Clear();
                
                
                foreach (var epc in epcsLidos)
                {
                    if (!_ordem.Epcs.Contains(epc))
                    {
                        EpcsNaoEsperadosList.Add(epc);
                    }
                }
               
            });
            Quantidade.Text = $"Quantidade: {epcsLidos.Count}";
            if (EpcsNaoEsperadosList.Any())
            {
                Status.Text = $"Status: Falhou";
            }
            ContagemEPCs.IsVisible = true;
            
        }
    }
}
