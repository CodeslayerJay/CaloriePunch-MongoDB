using CaloriePunch.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Services
{
    public class DataService
    {
        private readonly IDataContext _db;

        public DataService(IDataContext dataContext)
        {
            _db = dataContext;
        }

    }
}
