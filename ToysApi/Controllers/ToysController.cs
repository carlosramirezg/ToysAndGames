using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToysApi.Models;
using ToysDatabase;

namespace ToysApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToysController : Controller
	{
		private IRepository<Toy> _repository; 
		public ToysController(IRepository<Toy> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IEnumerable<Toy> Get()
		{
			return _repository.GetAll();
		}

		[HttpGet]
		[Route("{id}")]
		public Toy GetById(int id)
		{
			return _repository.Get(id);
		}

		[HttpPost]
		public void Post(Toy toy)
		{
			_repository.Add(toy);
		}

		[HttpPut]
		public void Put(Toy toy)
		{
			_repository.Update(toy);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_repository.Delete(id);
		}
	}
}
