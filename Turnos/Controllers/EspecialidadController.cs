using Microsoft.AspNetCore.Mvc;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Especialidades.ToList());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidades.Find(id);

            if(especialidad == null)
            {
                return NotFound();
                           
            }
            return View(especialidad);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Descripccion")] Especialidad especialidad)
        {
            if (id != especialidad.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);   
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = _context.Especialidades.FirstOrDefault(e => e.Id == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var especialidad = _context.Especialidades.Find(id);

            if (especialidad != null)
            {
                _context.Especialidades.Remove(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(especialidad);
        }
    }
}
