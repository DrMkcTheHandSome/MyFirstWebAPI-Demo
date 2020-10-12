using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interface
{
   public interface ISchoolRepository
    {
        School CreateSchool(School school);
        School ReadSchool(Guid id);
        School UpdateSchool(School school);
        void DeleteSchool(School school);
    }
}
