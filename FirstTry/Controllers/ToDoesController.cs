using FirstTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTry.Controllers
{
    public class ToDoesController : Controller
    {
        private readonly DataContext _context;

        public ToDoesController(DataContext context)
        {
            _context = context;
        }

        // GET: ToDoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDos.ToListAsync());
        }

        // GET: ToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDo toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDoes/Create
        public IActionResult Create()
        {
            ViewData["todoes"] = _context.ToDos.ToList();
            return View();
        }

        // POST: ToDoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                toDo.CreatedAt = DateTime.UtcNow;
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Task Created successfully";
                return RedirectToAction(nameof(Create));
            }
            return View(toDo);
        }

        // GET: ToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDo toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Date,Done,Id,CreatedAt,DeletedAt")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDoes/Delete/5
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Task Delete Failed";
                return RedirectToAction(nameof(Create));
            }

            ToDo toDo = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Task Deleted successfully";
            return RedirectToAction(nameof(Create));
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id && e.DeletedAt == null);
        }
    }
}
