using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MakeSistem.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "Sobre Nós";

			OpenWebCommand = new Command(() => Device.OpenUri(new Uri("")));
		}

		/// <summary>
		/// Command to open browser to xamarin.com
		/// </summary>
		public ICommand OpenWebCommand { get; }
	}
}
