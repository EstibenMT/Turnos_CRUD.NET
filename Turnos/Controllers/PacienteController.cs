using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _Context;
        public PacienteController(TurnosContext Context)
        { 
            _Context = Context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _Context.Pacientes.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            { 
                return NotFound();
            }

            var paciente = await _Context.Pacientes.FirstOrDefaultAsync(p => p.IdPaciente==id);

            if (paciente == null)
            { 
                NotFound();
            }
            return View(paciente);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {   if (ModelState.IsValid)
            {
                _Context.Add(paciente);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paciente = await _Context.Pacientes.FindAsync(id);

            if (ModelState.IsValid)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _Context.Update(paciente);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            { 
                return NotFound();
            }
            var paciente = await _Context.Pacientes.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if (ModelState.IsValid)
            { 

            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleteconfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _Context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            _Context.Pacientes.Remove(paciente);
            await _Context.SaveChangesAsync();
            return View(nameof(Index));

        }

    }
}
