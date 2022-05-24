using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Domain;
using DataAccess.Data;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class ContentCarouselsController : Controller
    {
        private readonly DataContext _context;
        private readonly IContentCarouselRepository _contentCarouselRepository;

        public ContentCarouselsController(DataContext context, IContentCarouselRepository contentCarouselRepository)
        {
            _context = context;
            _contentCarouselRepository = contentCarouselRepository;
        }

        // GET: ContentCarousels
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            NotificationViewModelGeneric<List<ContentCarouselsViewModel>> n = new()
            {
                Type = NotificationType.Success,
                Data = new List<ContentCarouselsViewModel>()
            };
            foreach (var item in await _contentCarouselRepository.GetAllAsync())
            {
                n.Data.Add(new ContentCarouselsViewModel(item));
            }
            return Ok(n);
        }


        // POST: ContentCarousels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(List<IFormFile> files, int id)
        {
            if (id == 0 || !files.Any())
            {
                return Ok(new NotificationViewModelGeneric<ContentCarouselsViewModel> ()
                {
                    Type = NotificationType.Error
                });
            }
            var contentCarousel =new ContentCarousel() { PageContainerId = id };
            foreach (var file in files)
            {
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                    contentCarousel.Content = binaryReader.ReadBytes((int)file.Length);
                await _contentCarouselRepository.Create(contentCarousel);
            }
            return Ok();
        }

        // POST: ContentCarousels/Delete/5
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            NotificationViewModelGeneric<PageContainerViewModel> n = new()
            {
                Type = NotificationType.Error,
            };
            try
            {
                await _contentCarouselRepository.Delete(id);
                n.Type = NotificationType.Success;
            }
            catch (DbUpdateConcurrencyException e)
            {
                n.Text = $" {e.Message} ;\nID = {id}";
            }
            return Ok(n);
        }



        #region На удаление

        // GET: ContentCarousels/Details/5
        //[HttpGet]
        //[Route("GetById")]
        //public async Task<IActionResult> GetById(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contentCarousel = await _context.ContentCarousels
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (contentCarousel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contentCarousel);
        //}

        // POST: ContentCarousels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[Route("Update")]
        //public async Task<IActionResult> Update(ContentCarousel contentCarousel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(contentCarousel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ContentCarouselExists(contentCarousel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(contentCarousel);
        //}

        //private bool ContentCarouselExists(int id)
        //{
        //    return _context.ContentCarousels.Any(e => e.Id == id);
        //}
        #endregion
    }
}
