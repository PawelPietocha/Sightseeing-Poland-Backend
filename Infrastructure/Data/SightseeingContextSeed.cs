using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class SightseeingContextSeed
    {
        public static async Task SeedAsync(SightseeingContext context)
        {
            if (!context.Voivodeships.Any())
            {
                var voivodeshipsData = File.ReadAllText("../Infrastructure/Data/SeedData/voivodeships.json");
                var voivodeships = JsonSerializer.Deserialize<List<Voivodeship>>(voivodeshipsData);
                context.Voivodeships.AddRange(voivodeships);

            }

            if (!context.MountainsRanges.Any())
            {
                var mountainsRangesData = File.ReadAllText("../Infrastructure/Data/SeedData/mountainsRange.json");
                var mountainsRanges = JsonSerializer.Deserialize<List<MountainsRange>>(mountainsRangesData);
                context.MountainsRanges.AddRange(mountainsRanges);
            }

            if (!context.Mountains.Any())
            {
                var mountainsCrownData = File.ReadAllText("../Infrastructure/Data/SeedData/mountainsCrown.json");
                var mountainsCrown = JsonSerializer.Deserialize<List<Mountain>>(mountainsCrownData);
                context.Mountains.AddRange(mountainsCrown);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

        }

    }
}