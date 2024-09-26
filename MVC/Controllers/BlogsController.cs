#nullable disable

using Business.Models;
using Business.Services;
using Core.Results.Bases;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;


        public BlogsController(IBlogService blogService, IUserService userService, ITagService tagService)
        {
            _blogService = blogService;
            _userService = userService;
            _tagService = tagService;
        }

        // GET: Blogs
        public IActionResult Index()
        {
            List<BlogModel> blogList = _blogService.Query().ToList();
            return View(blogList);
        }

        // GET: Blogs/Details/5
        public IActionResult Details(int id)
        {
            BlogModel blog = _blogService.Query().SingleOrDefault(b => b.Id == id);

            if(blog == null)
            {
                return View("_Error", "Blog not found!");
            }
            
            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.Query(), "Id" , "UserName");
            ViewData["Tags"] = new SelectList(_tagService.Query(), "Id", "Name");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                Result result = _blogService.Add(blog);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("",result.Message);
            }

            ViewData["UserId"] = new SelectList(_userService.Query(), "Id", "UserName");
            ViewData["Tags"] = new SelectList(_tagService.Query(), "Id", "Name");
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public IActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Blog blog)
        {
            return View();
        }

        // GET: Blogs/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
