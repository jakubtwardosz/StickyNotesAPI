using System.ComponentModel.DataAnnotations;

namespace StickyNotesAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
        public ColorDetails Colors { get; set; }
        public PositionDetails Position { get; set; }
    }
}
