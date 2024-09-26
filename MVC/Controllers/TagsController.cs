using Business.Models;
using Business.Services;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: Tags
        public IActionResult Index()
        {
            List<TagModel> tagList = _tagService.Query().ToList();
            return View(tagList);
        }

        // GET: Tags/Details/5
        public IActionResult Details(int id)
        {
            TagModel tag = _tagService.Query().SingleOrDefault(t => t.Id == id);

            if (tag == null)
            {
                return View("_Error", "Tag not found!");
            }
           return View(tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TagModel tag)
        {
            if (ModelState.IsValid)
            {
                var result =_tagService.Add(tag);
                if (result.IsSuccessful)
                {
                    return RedirectToAction(nameof(Index));

                }
                ModelState.AddModelError("", result.Message);
            }
            return View();
        }

        // GET: Tags/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TagModel tag)
        {
            return View();
        }

        // GET: Tags/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
