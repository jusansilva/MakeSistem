namespace MakeSistem.Models
{
    public class Item : BaseDataObject
	{
		string text = string.Empty;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}

        int quantidade = 0;
        public int Quantidade
        {
            get { return quantidade; }
            set { SetProperty(ref quantidade, value); }
        }

        double valor = 0;
        public double Valor
        {
            get { return valor; }
            set { SetProperty(ref valor, value); }
        }
	}
}
