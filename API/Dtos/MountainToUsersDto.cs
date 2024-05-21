public class MountainToUserDto {
        public DateTime DateOfVisit { get; set; }
        public int? TripTimeMinutes { get; set; }
        public int? TripTimeHours {get; set; }
        public string? StartPlace { get; set; }
        public string? EndPlace { get; set; }
        public int? TripLenghtInKm { get; set; }
        public int? ElevationGainInMeters { get; set; }
        public string UserId {get; set;}
        public int MountainId {get; set;}
}