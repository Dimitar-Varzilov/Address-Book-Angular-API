namespace AddressBookAPI.Utils
{
	public class Paginator
	{
		private readonly int _itemsToDisplay;
		private readonly List<Address> _resultList = new();
		private readonly int _pages;
		public Paginator(List<Address> resultList, int itemsToDisplay)
		{
			_resultList = resultList;
			_itemsToDisplay = itemsToDisplay;
			_pages = _resultList.Count / itemsToDisplay;
		}
		public List<Address> GetPagesList()
		{
			List<Address> addresses = (List<Address>)_resultList.Take(_itemsToDisplay);

			return addresses;
		}
		public int GetPagesCount() { return _pages; }
	}
}
