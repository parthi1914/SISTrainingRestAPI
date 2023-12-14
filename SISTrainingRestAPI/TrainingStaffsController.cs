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
    public class TrainingStaffsController : ControllerBase
    {
        private readonly SistrainingContext _context;

        public TrainingStaffsController(SistrainingContext context)
        {
            _context = context;
        }

        // GET: api/TrainingStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingStaff>>> GetTrainingStaffs()
        {
          if (_context.TrainingStaffs == null)
          {
              return NotFound();
          }

            var products = _context.TrainingStaffs
                            .FromSql($"EXECUTE dbo.GetSTrainingstaff")
                            .ToList();
            int staffid = 1;
            var products1 = _context.TrainingStaffs
                           .FromSql($"EXECUTE dbo.GetSTrainingstaffById {staffid}")
                           .ToList();
            staffid = 3;
            string StaffName = "Rinku";
            string Course = "Algos";
            string Email = "Rinku@gmail.com";
            _context.Database.ExecuteSql($"dbo.SaveStaffByparams @StaffId = {staffid},@StaffName= {StaffName},@Course = {Course},@Email = {Email}");


            return await _context.TrainingStaffs.ToListAsync();
        }

        // GET: api/TrainingStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingStaff>> GetTrainingStaff(long id)
        {
          if (_context.TrainingStaffs == null)
          {
              return NotFound();
          }
            var trainingStaff = await _context.TrainingStaffs.FindAsync(id);

            if (trainingStaff == null)
            {
                return NotFound();
            }

            return trainingStaff;
        }

        // PUT: api/TrainingStaffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingStaff(long id, TrainingStaff trainingStaff)
        {
            if (id != trainingStaff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(trainingStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingStaffExists(id))
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

        // POST: api/TrainingStaffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingStaff>> PostTrainingStaff(TrainingStaff trainingStaff)
        {
          if (_context.TrainingStaffs == null)
          {
              return Problem("Entity set 'SistrainingContext.TrainingStaffs'  is null.");
          }
            _context.TrainingStaffs.Add(trainingStaff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingStaffExists(trainingStaff.StaffId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainingStaff", new { id = trainingStaff.StaffId }, trainingStaff);
        }

        // DELETE: api/TrainingStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingStaff(long id)
        {
            if (_context.TrainingStaffs == null)
            {
                return NotFound();
            }
            var trainingStaff = await _context.TrainingStaffs.FindAsync(id);
            if (trainingStaff == null)
            {
                return NotFound();
            }

            _context.TrainingStaffs.Remove(trainingStaff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingStaffExists(long id)
        {
            return (_context.TrainingStaffs?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }


        // GET: api/SaveTrainingStudents
        [HttpPut("UpdateTrainingStaff")]
        public async Task<ActionResult<IEnumerable<TrainingStaff>>> UpdateTrainingStaff()
        {
           
            string Course = "New Update C#";
            int StaffId = 2;
            string StaffName = "Victor";


            var stdList = _context.Database.ExecuteSql($"dbo.UpdateTrainingStaff @Id={StaffId},@StaffName={StaffName},@course={Course}");
            return _context.TrainingStaffs;
        }


    }
}
