using DreamJourneyAPI.Enums;

namespace DreamJourneyAPI.Data.Dtos.DreamDto
{
    public class UpdateDreamDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LifeArea LifeArea { get; set; }
        public StatusDream Status { get; set; }
        public int? UserId { get; set; }
    }
}
