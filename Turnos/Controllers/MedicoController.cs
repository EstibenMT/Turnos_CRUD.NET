using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class MedicoController : Controller
    {
        private readonly TurnosContext _context;

        public MedicoController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Medicos != null ? 
                          View(await _context.Medicos.ToListAsync()) :
                          Problem("Entity set 'TurnosContext.Medicos'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Where(m => m.IdMedico == id)
                .Include(me => me.MedicosEspecialidad)
                .ThenInclude(e => e.Especialidad)
                .FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }

            if (medico.MedicosEspecialidad == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidades, "IdEspecialidad", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,Nombre,Apellido,Direccion,Telefono,Email,HorarioAtencionDesde,HorarioAtencionHasta")] Medico medico, int IdEspecialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();

                var medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = medico.IdMedico;
                medicoEspecialidad.IdEspecialidad = IdEspecialidad;
                _context.Add(medicoEspecialidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.Where(m => m.IdMedico == id)
                .Include(me => me.MedicosEspecialidad).FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }


            if (medico.MedicosEspecialidad != null && medico.MedicosEspecialidad.Count > 0)
            {
                ViewData["ListaEspecialidades"] = new SelectList(
                    _context.Especialidades, "IdEspecialidad", "Descripcion", medico.MedicosEspecialidad.First().IdEspecialidad);
            }
            else
            {
                ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidades, "IdEspecialidad", "Descripcion");
            }

            return View(medico);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nombre,Apellido,Direccion,Telefono,Email,HorarioAtencionDesde,HorarioAtencionHasta")] Medico medico, int IdEspecialidad)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (medico != null)
                    {
                        _context.Update(medico);
                        await _context.SaveChangesAsync();
                    }
                    
                    var medicoEspecialidad = await _context.MedicoEspecialidades.FirstOrDefaultAsync(me => me.IdMedico == id);

                    if (medicoEspecialidad != null)
                    {
                        _context.Remove(medicoEspecialidad);
                        await _context.SaveChangesAsync();
                    }

                    if (ModelState.IsValid)
                    {
                        var newMedicoEspecialidad = new MedicoEspecialidad();
                        newMedicoEspecialidad.IdMedico = id;
                        newMedicoEspecialidad.IdEspecialidad = IdEspecialidad;
                        _context.Add(newMedicoEspecialidad);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
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
            return View(medico);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Where(m => m.IdMedico == id)
                .Include(me => me.MedicosEspecialidad)
                .ThenInclude(e => e.Especialidad)
                .FirstOrDefaultAsync();


            if (medico == null)
            {
                return NotFound();
            }

            if (medico.MedicosEspecialidad == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicoEspecialidad = await _context.MedicoEspecialidades.FirstOrDefaultAsync(me => me.IdMedico == id);
            if (medicoEspecialidad != null)
            {
                _context.Remove(medicoEspecialidad);
            }
            
            if (_context.Medicos == null)
            {
                return Problem("Entity set 'TurnosContext.Medicos'  is null.");
            }
            var medico = await _context.Medicos.FindAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
          return (_context.Medicos?.Any(e => e.IdMedico == id)).GetValueOrDefault();
        }

        public string TraerHorarioAtencionDesde(int idMedico)
        {
            var HorarioAtencionDesde = _context.Medicos.Where(m => m.IdMedico == idMedico).FirstOrDefault().HorarioAtencionDesde;
            return HorarioAtencionDesde.Hour + ":" + HorarioAtencionDesde.Minute;
            
        }

        public string TraerHorarioAtencionHasta(int idMedico)
        {
            var HorarioAtencionHasta = _context.Medicos.Where(m => m.IdMedico == idMedico).FirstOrDefault().HorarioAtencionHasta;
            return HorarioAtencionHasta.Hour + ":" + HorarioAtencionHasta.Minute;
        }
    }
}
