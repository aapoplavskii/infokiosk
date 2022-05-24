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
using DataAccess.Repositories;
using Core.Repositories;

namespace WebAPI.Controllers
{
    //[ApiController]
    [Route("api/v1/[controller]")]
    public class PageContainersController : ControllerBase
    {
        private readonly IPageContainerRepository _pageContainerRepository;
        private readonly IContentCarouselRepository _contentCarouselRepository;

        public PageContainersController(IPageContainerRepository pageContainerRepository, IContentCarouselRepository contentCarouselRepository)
        {
            _pageContainerRepository = pageContainerRepository;
            _contentCarouselRepository = contentCarouselRepository;

        }

        // GET: PageContainers
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            NotificationViewModelGeneric<List<PageContainerViewModel>> n = new()
            {
                Type = NotificationType.Success,
                Data = new List<PageContainerViewModel>()
            };
            foreach (var item in await _pageContainerRepository.GetAllAsync())
            {
                n.Data.Add(new PageContainerViewModel(item));
            }
            return Ok(n);
        }

        // GET: PageContainers/GetById/5
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            NotificationViewModelGeneric<PageContainerViewModel> n = new()
            {
                Type = NotificationType.Success,
            };
            var t = await _pageContainerRepository.GetById(id);
            n.Data = new PageContainerViewModel(t);
            return Ok(n);
        }

        // GET: PageContainers/GetByName/УЗИ
        //[HttpGet]
        //[Route("GetByName")]
        //public async Task<IActionResult> GetByName(string name)
        //{
        //    if (name == null)
        //    {
        //        return NotFound();
        //    }

        //    var pageContainer = await _context.PageContainers
        //        .FirstOrDefaultAsync(m => m.Name == name);
        //    if (pageContainer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(pageContainer);
        //}

        // POST: PageContainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(PageContainer pageContainer)
        {
            NotificationViewModelGeneric<List<PageContainer>> result = new()
            {
                Type = NotificationType.Error
            };

            if (!ModelState.IsValid)
            {
                result.Text = "Не правильная модель";
                return Ok(result);
            }
            try
            {
                await _pageContainerRepository.Create(pageContainer);
                result.Type = NotificationType.Success;
            }
            catch
            {
                result.Text = "Ошибка базы данных";
            }
            return Ok(result);
        }

        // POST: PageContainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(PageContainer pageContainer)
        {
            NotificationViewModelGeneric<List<PageContainer>> result = new()
            {
                Type = NotificationType.Error
            };
            if (ModelState.IsValid)
            {

                try
                {
                    await _pageContainerRepository.Update(pageContainer);
                    result.Type = NotificationType.Success;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (PageContainerExists(pageContainer.Id))
                    {
                        result.Type = NotificationType.Error;
                        result.Text = "Такой модели не в базе данных";
                        return Ok(result);
                    }
                    else
                    {
                        result.Type = NotificationType.Error;
                        result.Text = "Ошибка базы данных";
                    }
                }
                return Ok(result);
            }
            return Ok(result);
        }

        // POST: PageContainers/Delete/5
        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            NotificationViewModelGeneric<List<PageContainer>> result = new()
            {
                Type = NotificationType.Error
            };
            if (ModelState.IsValid)
            {

                try
                {
                    _pageContainerRepository.Delete(id);
                    result.Type = NotificationType.Success;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (PageContainerExists(id))
                    {
                        result.Type = NotificationType.Error;
                        result.Text = "Такой модели нет в базе данных";
                        return Ok(result);
                    }
                    else
                    {
                        result.Type = NotificationType.Error;
                        result.Text = "Ошибка базы данных";
                    }
                }
                return Ok(result);
            }
            return Ok(result);
        }

        private bool PageContainerExists(int id)
        {
            var check = _pageContainerRepository.GetById(id);
            return check == null;
        }
    }
}
