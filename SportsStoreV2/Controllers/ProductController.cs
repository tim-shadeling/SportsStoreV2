﻿using Microsoft.AspNetCore.Mvc;
using SportsStoreV2.Models;

namespace SportsStoreV2.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository repository;
		public int PageSize = 4;
		public ProductController(IProductRepository repository)
		{
			this.repository = repository;
		}
		public ViewResult List(int productPage = 1)
			=> View(repository.Products
				.OrderBy(p => p.ProductID)
				.Skip((productPage - 1) * PageSize)
				.Take(PageSize));
	}
}
