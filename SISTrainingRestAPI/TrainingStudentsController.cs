using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTrainingRestAPI.Models;

namespace SISTrainingRestAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingStudentsController : ControllerBase
    {
        private readonly SistrainingContext _context;

        public TrainingStudentsController(SistrainingContext context)
        {
            _context = context;
        }


        // GET: api/TrainingStudents
        [HttpGet("GetTrainingStudentsByProcedure")]
        public async Task<ActionResult<IEnumerable<TrainingStudent>>> GetTrainingStudentsByProcedure()
        {
            if (_context.TrainingStudents == null)
            {
                return NotFound();
            }
            var stdList =   _context.TrainingStudents.FromSql($"EXECUTE dbo.GetTrainingStudents").ToList();

            return stdList;
        }


        // GET: api/TrainingStudents
        [HttpGet("GetTrainingStudentsByProcedureParam")]
        public async Task<ActionResult<IEnumerable<TrainingStudent>>> GetTrainingStudentsByProcedureParam()
        {
            if (_context.TrainingStudents == null)
            {
                return NotFound();
            }

            int StdId = 1;
            var stdList = _context.TrainingStudents.FromSql($"EXECUTE dbo.GetTrainingStudentsByParam {StdId}").ToList();

            return stdList;
        }


        // GET: api/SaveTrainingStudents
        [HttpPost("SaveTrainingStudents")]
        public async Task<ActionResult<IEnumerable<TrainingStudent>>> SaveTrainingStudents()
        {
            if (_context.TrainingStudents == null)
            {
                return NotFound();
            }
            string Name = "Akil";
            int StaffId = 1;

           
            var stdList = _context.Database.ExecuteSql($"dbo.SaveTrainingStudents @Name={Name},@StaffId={StaffId}");
            return _context.TrainingStudents;
        }


     




        // GET: api/TrainingStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingStudent>>> GetTrainingStudents()
        {
          if (_context.TrainingStudents == null)
          {
              return NotFound();
          }
            return await _context.TrainingStudents.ToListAsync();
        }

        // GET: api/TrainingStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingStudent>> GetTrainingStudent(long id)
        {
          if (_context.TrainingStudents == null)
          {
              return NotFound();
          }
            var trainingStudent = await _context.TrainingStudents.FindAsync(id);

            if (trainingStudent == null)
            {
                return NotFound();
            }

            return trainingStudent;
        }

        // PUT: api/TrainingStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingStudent(long id, TrainingStudent trainingStudent)
        {
            if (id != trainingStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrainingStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingStudent>> PostTrainingStudent(TrainingStudent trainingStudent)
        {
          if (_context.TrainingStudents == null)
          {
              return Problem("Entity set 'SistrainingContext.TrainingStudents'  is null.");
          }
            _context.TrainingStudents.Add(trainingStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingStudent", new { id = trainingStudent.Id }, trainingStudent);
        }

        // DELETE: api/TrainingStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingStudent(long id)
        {
            if (_context.TrainingStudents == null)
            {
                return NotFound();
            }
            var trainingStudent = await _context.TrainingStudents.FindAsync(id);
            if (trainingStudent == null)
            {
                return NotFound();
            }

            _context.TrainingStudents.Remove(trainingStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingStudentExists(long id)
        {
            return (_context.TrainingStudents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
