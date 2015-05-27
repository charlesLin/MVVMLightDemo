using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;

namespace Models
{
	public class OrderDetail : ObservableObject 
	{
		public int Id { get; set; }


		/// <summary>
		/// The <see cref="ProductName" /> property's name.
		/// </summary>
		public const string ProductNamePropertyName = "ProductName";

		private string _productname = null;

		/// <summary>
		/// Sets and gets the ProductName property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string ProductName
		{
			get
			{
				return _productname;
			}
			set
			{

				if (Set(() => ProductName, ref _productname, value))
					IsDirty = true;
			}
		}

		/// <summary>
		/// The <see cref="Amount" /> property's name.
		/// </summary>
		public const string AmountPropertyName = "Amount";

		private int _amount = 0;

		/// <summary>
		/// Sets and gets the Amount property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int Amount
		{
			get
			{
				return _amount;
			}
			set
			{

				if (Set(() => Amount, ref _amount, value))
					IsDirty = true;
			}
		}


		/// <summary>
		/// The <see cref="Quantity" /> property's name.
		/// </summary>
		public const string QuantityPropertyName = "Quantity";

		private int _quantity = 0;

		/// <summary>
		/// Sets and gets the Quantity property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				if (Set(() => Quantity, ref _quantity, value))
					IsDirty = true;
			}
		}

		/// <summary>
		/// The <see cref="IsDirty" /> property's name.
		/// </summary>
		public const string IsDirtyPropertyName = "IsDirty";

		private bool _isDirty = false;

		[NotMapped]
		public bool IsDirty
		{
			get
			{
				return _isDirty;
			}
			set
			{
				Set(() => IsDirty, ref _isDirty, value);
			}
		}

	}
}