using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using aspnetcoreapp.Helpers;

namespace aspnetcoreapp.Models
{
    public class DroneLog : EntityLog
    {
        public static int GroupId = 1;
        [Column(TypeName = "varchar(255)")] public string Name { get; set; }
        [Column(TypeName = "varchar(255)")] public string RegionName { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        [Column(TypeName = "varchar(255)")] public string RegionId { get; set; }

        public static DroneLog[] GetSeederData()
        {
            var droneSeeder = new List<DroneLog>();
            var rand = new Random();
            for (var i = 0; i < 40; i++)
            {
                var ranDay = rand.Next(1, 3);
                var ranHour = rand.Next(1, 18);
                var ranMinute = rand.Next(1, 50);
                var apiType = Utility.GetRandomApiType();
                var entityId = rand.Next(1, 11);
                string projectType = Models.ProjectType.GetRandomProjectType();
                var droneLog = new DroneLog()
                {
                    RegionId = MonitorRegionLog.GetRandomEntityId(),
                    EntityLogPrimaryKeyId = i + 1,
                    EntityId = DroneLog.GetRandomEntityId(),
                    Latitude = rand.Next(10, 50),
                    Longitude = rand.Next(10, 50),
                    AuthorId = UserLog.GetRandomEntityId(),
                    Type = apiType,
                    ProjectType = projectType,
                    RegionName = "MonitorRegion " + MonitorRegionLog.GetRandomEntityId(),
                    Description = "Drone " + apiType.GetDescription(),
                    Name = "Drone " + entityId,
                    Timestamp = new DateTime(2020, 12, ranDay, ranHour, ranMinute, 0)
                };
                droneSeeder.Add(droneLog);
            }

            return droneSeeder.ToArray();
        }

        public static string GetRandomEntityId()
        {
            var rand = new Random();
            return rand.Next(1, 11).ToString();
        }
    }

    public class DroneLogResponse : EntityLogDTO
    {
        public string Name { get; set; }
        public string RegionName { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string RegionId { get; set; }
    }

    public class DroneLogRequest
    {
        public string Name { get; set; }
        public string RegionName { get; set; }
        public string ProjectType { get; set; }
        public string AuthorId { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string EntityId { get; set; }
        public string Description { get; set; }
        public string RegionId { get; set; }
    }
}