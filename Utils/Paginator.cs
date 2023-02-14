namespace AddressBookAPI.Utils
{
	public class Paginator
	{
		private readonly int _itemsToDisplay;
		private readonly List<Address> _resultList = new();
		private readonly int _numberOfPages;
		public Paginator(List<Address> resultList, int itemsToDisplay)
		{
			_resultList = resultList;
			_itemsToDisplay = itemsToDisplay;
			_numberOfPages = _resultList.Count / itemsToDisplay;
		}
		public IEnumerable<Address> GetPagesList()
		{
			IEnumerable<Address> addresses = _resultList.Take(_itemsToDisplay);
			return addresses;
		}
		public int GetPagesCount() { return _numberOfPages; }
	}
}
