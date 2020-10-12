using DomainModel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly MyFirstWebAPIDbContext _context;
        public SchoolRepository(MyFirstWebAPIDbContext myFirstWebAPIDbContext)
        {
            _context = myFirstWebAPIDbContext;
        }
        public School CreateSchool(School school)
        {
            var newSchool =  _context.Schools.Add(school).Entity;
            _context.SaveChanges();
            return newSchool;
        }

        public void DeleteSchool(School school)
        {
            _context.Schools.Remove(school);
            _context.SaveChanges();
        }

        public School ReadSchool(Guid id)
        {
            return _context.Schools.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public School UpdateSchool(School school)
        {
            var newSchool = _context.Schools.Update(school).Entity;
            _context.SaveChanges();
            return newSchool;
        }
    }
}
