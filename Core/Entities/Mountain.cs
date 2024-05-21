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
    }
}