﻿using NamPX.API.Models.Domain;

namespace NamPX.API.Models.DTO
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        // Navigation properties

        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }

    }
}
