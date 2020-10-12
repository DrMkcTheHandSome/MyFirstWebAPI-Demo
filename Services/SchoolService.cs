using DomainModel;
using DomainModel.Interface;
using DomainModel.Repository;
using Services.DTO;
using Services.Interface;
using System;

namespace Services
{
    public class SchoolService : ISchoolService
    {
        private readonly MyFirstWebAPIDbContext _myFirstWebAPIDbContext; 
        private readonly ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository,
            MyFirstWebAPIDbContext myFirstWebAPIDbContext)
        {
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
            _myFirstWebAPIDbContext = myFirstWebAPIDbContext ?? throw new ArgumentNullException(nameof(myFirstWebAPIDbContext));
        }
        public SchoolDTO CreateSchool(SchoolDTO schoolDTO)
        {
            var newSchool = new School() { 
            Id =  schoolDTO.Id,
            Name = schoolDTO.Name
            };

            var result = _schoolRepository.CreateSchool(newSchool);

            var newSchoolDTO = new SchoolDTO()
            {
                Id = result.Id,
                Name = result.Name
            };

            return newSchoolDTO;
        }

        public void DeleteSchool(Guid id)
        {
            var schoolEntity = _schoolRepository.ReadSchool(id);
            _schoolRepository.DeleteSchool(schoolEntity);
        }

        public SchoolDTO ReadSchool(Guid id)
        {
            var result = _schoolRepository.ReadSchool(id);
            return new SchoolDTO()
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public SchoolDTO UpdateSchool(SchoolDTO schoolDTO)
        {
            var newSchool = new School()
            {
                Id = schoolDTO.Id,
                Name = schoolDTO.Name
            };

            var result = _schoolRepository.UpdateSchool(newSchool);

            var newSchoolDTO = new SchoolDTO()
            {
                Id = result.Id,
                Name = result.Name
            };

            return newSchoolDTO;
        }
    }
}
