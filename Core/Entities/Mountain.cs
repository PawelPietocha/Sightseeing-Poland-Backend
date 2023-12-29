namespace Core.Entities
{
    public class Mountain: BaseEntity
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string ImagePath { get; set; }
        public Voivodeship Voivodeship { get; set; }
        public int VoivodeshipId { get; set; }
        public MountainsRange MountainsRange { get; set; }
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