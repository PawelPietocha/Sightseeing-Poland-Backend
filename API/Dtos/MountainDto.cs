using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MountainDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public string ImagePath { get; set; }
        public string Voivodeship { get; set; }
        public int VoivodeshipId { get; set; }
        public string MountainsRange { get; set; }
        public int MountainsRangeId { get; set; }
        public bool Visited { get; set; }
        public DateTime? DateOfVisit { get; set; }
        public int? TripTimeInMinutes { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
        public int? TripLenghtInKm { get; set; }
        public int? ElevationGainInMeters { get; set; }
    }
}