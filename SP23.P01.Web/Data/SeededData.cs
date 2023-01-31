using System;
using Microsoft.EntityFrameworkCore;

namespace SP23.P01.Web.Data
{
	public class SeededData
	{
        public static void Initialize(IServiceProvider services)
        {
            var context = services.GetRequiredService<DataContext>();
            context.Database.Migrate();

            AddTrainStations(context);
        }

        private static void AddTrainStations(DataContext context)
        {
            var trainStations = context.Set<TrainStation>();
            if (trainStations.Any())
            {
                return;
            }

            trainStations.Add(new TrainStation
            {
                Name = "Houma Train Station",
                Address = "824 Houma Lane"
            });
            trainStations.Add(new TrainStation
            {
                Name = "Denham Station",
                Address = "987 Springs Ave"
            });
            trainStations.Add(new TrainStation
            {
                Name = "Walker Waypoint",
                Address = "456 N Walker Blvd"
            });
            context.SaveChanges();
        }
    }
}

