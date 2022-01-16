using RealEstate.API.Contexts;
using RealEstate.API.Entities;
using RealEstate.API.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.API.Repositories.Implementations
{
    public class UserTypeRepository : GenericRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(RealEstateContext context) : base(context)
        {
        }
    }
}
