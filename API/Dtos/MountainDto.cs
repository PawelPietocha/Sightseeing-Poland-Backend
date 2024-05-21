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
    }
}