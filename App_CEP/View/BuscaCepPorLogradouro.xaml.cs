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
	public partial class BuscaCepPorLogradouro
	{
        public BuscaCepPorLogradouro()
		{
			InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
		{
			try
			{
				carregando.IsRunning = true;

				List<Ceps> arr_ceps = await DataService.GetCepsByLogradouro(txt_logradouro.Text);

				lst_ceps.ItemsSource = arr_ceps;
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