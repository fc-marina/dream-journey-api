using DreamJourneyAPI.Enums;
using DreamJourneyAPI.Models;

namespace DreamJourneyAPI.Data.Dtos.DreamDto
{
    public class CreateDreamDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LifeArea LifeArea { get; set; }
        public StatusDream Status { get; set; }
        public int? UserId { get; set; }
    }
}
