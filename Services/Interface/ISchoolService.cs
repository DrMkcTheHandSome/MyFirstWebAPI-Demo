using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
   public interface ISchoolService
    {
        SchoolDTO CreateSchool(SchoolDTO schoolDTO);
        SchoolDTO ReadSchool(Guid id);
        SchoolDTO UpdateSchool(SchoolDTO schoolDTO);
        void DeleteSchool(Guid id);
    }
}
