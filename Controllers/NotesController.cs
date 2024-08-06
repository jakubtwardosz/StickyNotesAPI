using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StickyNotesApi.Data;
using StickyNotesAPI.Models;

namespace StickyNotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;

        public NotesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedData()
        {
            if (_context.Notes.Any())
            {
                return BadRequest("Database already seeded.");
            }

            var notes = new List<Note>
            {
                new Note
                {
                    Body = "Note #1",
                    Colors = new ColorDetails
                    {
                        Id = "color-purple",
                        ColorHeader = "#FED0FD",
                        ColorBody = "#FEE5FD",
                        ColorText = "#18181A"
                    },
                    Position = new PositionDetails
                    {
                        X = 163,
                        Y = 273
                    }
                },
                new Note
                {
                    Body = "Note #2",
                    Colors = new ColorDetails
                    {
                        Id = "color-green",
                        ColorHeader = "#AFDA9F",
                        ColorBody = "#BCDEAF",
                        ColorText = "#18181A"
                    },
                    Position = new PositionDetails
                    {
                        X = 505,
                        Y = 10
                    }
                },
                new Note
                {
                    Body = "Note #3",
                    Colors = new ColorDetails
                    {
                        Id = "color-blue",
                        ColorHeader = "#9BD1DE",
                        ColorBody = "#A6DCE9",
                        ColorText = "#18181A"
                    },
                    Position = new PositionDetails
                    {
                        X = 305,
                        Y = 110
                    }
                }
            };

            _context.Notes.AddRange(notes);
            await _context.SaveChangesAsync();

            return Ok("Data seeded successfully.");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

    }
}
