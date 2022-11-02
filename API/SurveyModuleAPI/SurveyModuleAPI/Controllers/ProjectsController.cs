using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyModule.Data;
using SurveyModule.Models;

namespace SurveyModuleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly SurveyModuleContext _context;
        private readonly sp_textprocedure _contextprocedure;

        public ProjectsController(SurveyModuleContext context, sp_textprocedure contextprocedure)
        {
            _context = context;
            _contextprocedure = contextprocedure;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProject>>> GetTblProjects()
        {
            return await _context.TblProjects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProject>> GetTblProject(int id)
        {
            var tblProject = await _context.TblProjects.FindAsync(id);

            if (tblProject == null)
            {
                return NotFound();
            }

            return tblProject;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProject(int id, TblProject tblProject)
        {
            if (id != tblProject.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProjectExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProject>> PostTblProject(TblProject tblProject)
        {
            _context.TblProjects.Add(tblProject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblProjectExists(tblProject.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblProject", new { id = tblProject.Id }, tblProject);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProject(int id)
        {
            var tblProject = await _context.TblProjects.FindAsync(id);
            if (tblProject == null)
            {
                return NotFound();
            }

            _context.TblProjects.Remove(tblProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProjectExists(int id)
        {
            return _context.TblProjects.Any(e => e.Id == id);
        }

        //Loading related Questionairs for Project
        [HttpGet("GetQuestionnairsfromProjectId")]
        public async Task<TblProject?> GetQuestionnairsfromProjectId(int? project_id)
        {
            return await _context.TblProjects
                .Include(p => p.TblQuestionnaires)
                .Where(p => p.Id == project_id)
                .FirstOrDefaultAsync();
        }

        //Calling View
        [HttpGet("GetActiveProjectsView")]
        public async Task<IEnumerable<ViewProjectlist>> GetActiveProjectsView()
        {
            return await _context.ViewProjectlists.ToListAsync();
        }

        //Calling SP
        [HttpGet("sp_test")]
        public async Task<IEnumerable<TblProject>> GetCustOrderHistory(string projectname)
        {
            return await _contextprocedure.sp_project_name
                .FromSqlRaw("call sp_test({0})", projectname)
                .ToListAsync();
        }
    }
}
