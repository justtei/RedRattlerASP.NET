using System;
using System.Collections.Generic;
using System.Linq;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public abstract class KeyValueStorage<TKey> where TKey : struct
	{
		private readonly List<KeyValuePair<TKey, object>> _items;

		public IEnumerable<KeyValuePair<TKey, object>> Items => _items;

		protected KeyValueStorage()
		{
			_items = new List<KeyValuePair<TKey, object>>();
		}

		public void AddValue(TKey key, object value)
		{
			if (value != null)
			{
				_items.Add(new KeyValuePair<TKey, object>(key, value));
			}
		}

		public TValue GetValue<TValue>(TKey key)
		{
			KeyValuePair<TKey, object> keyValuePair = _items.Find((KeyValuePair<TKey, object> x) => x.Key.Equals(key));
			if (keyValuePair.Value == null)
			{
				return default(TValue);
			}
			return (TValue)keyValuePair.Value;
		}

		public List<TValue> GetValues<TValue>(TKey key)
		{
			return (from pair in _items
					where pair.Key.Equals(key)
					select (TValue)pair.Value).ToList();
		}
	}
}