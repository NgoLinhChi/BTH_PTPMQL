using FirstwebMVC.Data;
using FirstwebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
namespace FirstwebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context){
            _context = context;
        }
  public async Task<IActionResult> Index(int? page, int? PageSize)
    {
        ViewBag.PageSize = new List<SelectListItem>()
        {
            new SelectListItem() { Value = "3", Text = "3"},
            new SelectListItem() { Value = "5", Text = "5"},
            new SelectListItem() { Value = "7", Text = "7"},
            new SelectListItem() { Value = "10", Text = "10"},
        };
        int pagesize = (PageSize ?? 3);
        ViewBag.psize = pagesize;
        var model = _context.Employee.ToList().ToPagedList(page ?? 1, pagesize);
        return View(model);
    }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID, Age")] Employee employee){
            if(ModelState.IsValid){
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> Edit(string id){
            if(id == null || _context.Employee == null){
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if(employee == null){
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,[Bind("EmployeeID, Age")]  Employee employee){
            if(id != employee.EmployeeID){
                return NotFound();
            }
            if(ModelState.IsValid){
                try{
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException){
                    if(!EmployeeExists(employee.EmployeeID)){
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
 
            return View(employee);
        }
        public async Task<IActionResult> Delete(string id){
            if( id == null || _context.Employee == null){
                return NotFound();
            }
            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if(employee == null){
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id){
            if(_context.Employee == null){
                return Problem("Entity set 'ApplicationDbcontext.Employee' is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if(employee != null){
                _context.Employee.Remove(employee);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(string id){
            return (_context.Employee?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
