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
    public class QuestionnaireOptionsController : ControllerBase
    {
        private readonly SurveyModuleContext _context;

        public QuestionnaireOptionsController(SurveyModuleContext context)
        {
            _context = context;
        }

        // GET: api/QuestionnaireOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblQuestionnaireOption>>> GetTblQuestionnaireOptions()
        {
            return await _context.TblQuestionnaireOptions.ToListAsync();
        }

        // GET: api/QuestionnaireOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblQuestionnaireOption>> GetTblQuestionnaireOption(int id)
        {
            var tblQuestionnaireOption = await _context.TblQuestionnaireOptions.FindAsync(id);

            if (tblQuestionnaireOption == null)
            {
                return NotFound();
            }

            return tblQuestionnaireOption;
        }

        // PUT: api/QuestionnaireOptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuestionnaireOption(int id, TblQuestionnaireOption tblQuestionnaireOption)
        {
            if (id != tblQuestionnaireOption.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblQuestionnaireOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionnaireOptionExists(id))
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

        // POST: api/QuestionnaireOptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblQuestionnaireOption>> PostTblQuestionnaireOption(TblQuestionnaireOption tblQuestionnaireOption)
        {
            _context.TblQuestionnaireOptions.Add(tblQuestionnaireOption);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblQuestionnaireOptionExists(tblQuestionnaireOption.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblQuestionnaireOption", new { id = tblQuestionnaireOption.Id }, tblQuestionnaireOption);
        }

        // DELETE: api/QuestionnaireOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblQuestionnaireOption(int id)
        {
            var tblQuestionnaireOption = await _context.TblQuestionnaireOptions.FindAsync(id);
            if (tblQuestionnaireOption == null)
            {
                return NotFound();
            }

            _context.TblQuestionnaireOptions.Remove(tblQuestionnaireOption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblQuestionnaireOptionExists(int id)
        {
            return _context.TblQuestionnaireOptions.Any(e => e.Id == id);
        }
    }
}
