﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourApi.Models;

namespace TourApi.Controllers
{
    #region TodoController
    [ApiController]
    [Route("[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly TourContext _context;

        public ToursController(TourContext context)
        {
            _context = context;
        }
        #endregion

        // GET: /Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTourItems()
        {
            return await _context.Tours.ToListAsync();
        }

        #region snippet_GetByID
        // GET: /Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTourItem(long id)
        {
            var todoItem = await _context.Tours.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        #endregion

        #region snippet_Create
        // POST: /Tours
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tourItem)
        {
            tourItem.CreatedAt = DateTime.Now;
            tourItem.LastModified = DateTime.Now;

            _context.Tours.Add(tourItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTourItem), new { id = tourItem.Id }, tourItem);
        }
        #endregion

        #region snippet_Update
        // PUT: api/Tours/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(long id, Tour tour)
        {
            if (id != tour.Id)
            {
                return BadRequest();
            }
            
            tour.LastModified = DateTime.Now;

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tour);
        }
        #endregion

        #region snippet_Delete
        // DELETE: /Tours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tour>> DeleteTour(long id)
        {
            var todoItem = await _context.Tours.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
        #endregion

        private bool TourExists(long id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}
