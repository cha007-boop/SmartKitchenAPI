namespace KitchenLib
{
    public class Grocery
    {
		private int _barcode;
		private string _name;
		
		public int Barcode
		{
			get { return _barcode; }
			set { _barcode = value; }
		}
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}
