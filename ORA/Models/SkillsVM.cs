using System.Collections.Generic;

namespace ORA.Models
{
    public class SkillsVM
    {
        public int SkillsId { get; set; }

        public int ResumeId { get; set; }

        public int SkillLibraryId { get; set; }

        public int SkillProficiency { get; set; }

        public SkillLibraryVM SkillLibrary {get; set;}

        public List<SkillLibraryVM> SkillLibraryList { get; set; }
    }
}