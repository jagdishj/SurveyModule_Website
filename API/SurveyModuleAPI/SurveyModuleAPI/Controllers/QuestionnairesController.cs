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
    public class QuestionnairesController : ControllerBase
    {
        private readonly SurveyModuleContext _context;

        public QuestionnairesController(SurveyModuleContext context)
        {
            _context = context;
        }

        // GET: api/Questionnaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuestionnaire>>> GetTblQuestionnaires()
        {
            return await _context.TblQuestionnaires.ToListAsync();
        }

        // GET: api/Questionnaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuestionnaire>> GetTblQuestionnaire(int id)
        {
            var tblQuestionnaire = await _context.TblQuestionnaires.FindAsync(id);

            if (tblQuestionnaire == null)
            {
                return NotFound();
            }

            return tblQuestionnaire;
        }

        // PUT: api/Questionnaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuestionnaire(int id, TblQuestionnaire tblQuestionnaire)
        {
            if (id != tblQuestionnaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblQuestionnaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionnaireExists(id))
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

        // POST: api/Questionnaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblQuestionnaire>> PostTblQuestionnaire(TblQuestionnaire tblQuestionnaire)
        {
            _context.TblQuestionnaires.Add(tblQuestionnaire);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblQuestionnaireExists(tblQuestionnaire.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblQuestionnaire", new { id = tblQuestionnaire.Id }, tblQuestionnaire);
        }

        // DELETE: api/Questionnaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblQuestionnaire(int id)
        {
            var tblQuestionnaire = await _context.TblQuestionnaires.FindAsync(id);
            if (tblQuestionnaire == null)
            {
                return NotFound();
            }

            _context.TblQuestionnaires.Remove(tblQuestionnaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblQuestionnaireExists(int id)
        {
            return _context.TblQuestionnaires.Any(e => e.Id == id);
        }
    }
}
