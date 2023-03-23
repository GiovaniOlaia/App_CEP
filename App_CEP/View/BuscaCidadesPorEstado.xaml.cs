using App_CEP.Model;
using App_CEP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_CEP.View
{
    public partial class BuscaCidadesPorEstado
    {
        public BuscaCidadesPorEstado()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(txt_cidade.Text);

                lst_cidades.ItemsSource = arr_cidades;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}