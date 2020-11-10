using System.Collections.Generic;
using System.Linq;
using ToysApi.Models;

namespace ToysDatabase
{
	public class ToysRepository : IRepository<Toy>
	{
		private readonly ToysContext _toysContext;
		public ToysRepository(ToysContext toysContext)
		{
			_toysContext = toysContext;
		}

		public Toy Get(int id)
		{
			return _toysContext.Toys.FirstOrDefault(x => x.Id.Equals(id));
		}

		public List<Toy> GetAll()
		{
			return _toysContext.Toys.ToList();
		}

		public void Add(Toy toy)
		{
			_toysContext.Add(toy);
			_toysContext.SaveChanges();
		}

		public void Update(Toy toy)
		{
			var selectedToy = _toysContext.Toys.First(x => x.Id == toy.Id);
			_toysContext.Entry(selectedToy).CurrentValues.SetValues(toy);
			_toysContext.Update(selectedToy);
			_toysContext.SaveChanges();
		}

		public void Delete(int id)
		{
			_toysContext.Remove(_toysContext.Toys.Find(id));
			_toysContext.SaveChanges();
		}
	}
}
