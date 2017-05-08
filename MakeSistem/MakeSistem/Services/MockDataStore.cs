using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MakeSistem.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(MakeSistem.Services.MockDataStore))]
namespace MakeSistem.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			items = new List<Item>();
			var _items = new List<Item>
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "X-Burgue", Description="Pão, Carne, Queijo", Valor=12.00 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "X-Salada", Description="Pão, Carne, Queijo, salada", Valor=15.00 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "X-Bacon", Description="Pão, Carne, Queijo, Bacon", Valor=16.00 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "X-Tudo", Description="Pão, Carne, Queijo, salada, Bacon, Ovo", Valor=20.00 },
            };

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
