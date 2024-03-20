using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AmazonLite.Models;
using AmazonLite.Models.ViewModels;

namespace AmazonLite.Controllers;

public class HomeController : Controller
{
    private IBookInterface _repo;

    public HomeController(IBookInterface temp)
    {
        _repo = temp;
    }

    public IActionResult Index(int pageNum)
    {
        int pageSize = 10;
        var stuff = new BookListViewModel
        {
            Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        };
        
        return View(stuff);
    }
    
}