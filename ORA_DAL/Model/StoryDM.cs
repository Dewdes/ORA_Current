using System;

namespace ORA_Data.Model
{
    public class StoryDM
    {
        public long StoryId { get; set; }

        public string StoryName { get; set; }

        public string StoryNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public long ClientId { get; set; }
    }
}