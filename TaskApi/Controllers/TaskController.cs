using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using System.Linq;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;

            if (_context.TaskItems.Count() == 0)
            {
                _context.TaskItems.Add(new TaskItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult GetById(long id)
        {
            var item = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TaskItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTask", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TaskItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var Task = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (Task == null)
            {
                return NotFound();
            }

            Task.IsComplete = item.IsComplete;
            Task.Name = item.Name;

            _context.TaskItems.Update(Task);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Task = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (Task == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(Task);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}