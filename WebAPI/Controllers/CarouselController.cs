using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Domain;
using DataAccess.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CarouselController : Controller
    {
        private readonly DataContext _context;
        
        public CarouselController(DataContext context)
        {
            _context = context;
        }

       // GET: Carousels
       //[HttpGet]
       //[Route("List")]
       // public async Task<IActionResult> List()
       // {
       //     NotificationViewModelGeneric<List<Carousel>> result = new()
       //     {
       //         Type = NotificationType.Success
       //     };
       //     result.Data = await _context.Carousels.ToListAsync();
       //     return Ok(result);
       // }

       // GET: Carousels/GetById/5
       // [HttpGet]
       // [Route("GetById")]
       // public async Task<IActionResult> GetById(int? id)
       // {
       //     if (id == null)
       //     {
       //         return NotFound();
       //     }

       //     var carousel = await _context.Carousels
       //         .FirstOrDefaultAsync(m => m.Id == id);
       //     if (carousel == null)
       //     {
       //         return NotFound();
       //     }

       //     return Ok(carousel);
       // }

       // GET: Carousels/GetByName/5
       // [HttpGet]
       // [Route("GetByName")]
       // public async Task<IActionResult> GetByName(string name)
       // {
       //     if (name == null)
       //     {
       //         return NotFound();
       //     }

       //     var carousel = await _context.Carousels
       //         .FirstOrDefaultAsync(m => m.Name == name);
       //     if (carousel == null)
       //     {
       //         return NotFound();
       //     }

       //     return Ok(carousel);
       // }

       // POST: Carousels/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       //[HttpPost]
       // [ValidateAntiForgeryToken]
       // [Route("Create")]
       // public async Task<IActionResult> Create(Carousel carousel)
       // {
       //     NotificationViewModelGeneric<List<PageContainer>> result = new()
       //     {
       //         Type = NotificationType.Error
       //     };
       //     if (ModelState.IsValid)
       //     {
       //         _context.Add(carousel);
       //         await _context.SaveChangesAsync();
       //         result.Type = NotificationType.Success;
       //         return Ok(result);
       //     }
       //     return Ok(result);
       // }

       // POST: Carousels/Edit/5
       //  To protect from overposting attacks, enable the specific properties you want to bind to.
       //  For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       // [HttpPut]
       // [ValidateAntiForgeryToken]
       // [Route("Update")]
       // public async Task<IActionResult> Update(Carousel carousel)
       // {
       //     NotificationViewModelGeneric<List<PageContainer>> result = new()
       //     {
       //         Type = NotificationType.Error
       //     };
       //     if (ModelState.IsValid)
       //     {
       //         try
       //         {
       //             _context.Update(carousel);
       //             result.Type = NotificationType.Success;
       //             await _context.SaveChangesAsync();
       //         }
       //         catch (DbUpdateConcurrencyException)
       //         {
       //             if (!CarouselExists(carousel.Id))
       //             {
       //                 result.Text = "Карусель не найдена";
       //             }
       //             else
       //             {
       //                 throw;
       //             }
       //         }
       //     }
       //     return Ok(carousel);
       // }

       // POST: Carousels/Delete/5
       // [HttpDelete]
       // [ValidateAntiForgeryToken]
       // [Route("Delete")]
       // public async Task<IActionResult> Delete(int id)
       // {
       //     var carousel = await _context.Carousels.FindAsync(id);
       //     _context.Carousels.Remove(carousel);
       //     await _context.SaveChangesAsync();
       //     return RedirectToAction(nameof(Index));
       // }

       // private bool CarouselExists(int id)
       // {
       //     return _context.Carousels.Any(e => e.Id == id);
       // }
    }
}
