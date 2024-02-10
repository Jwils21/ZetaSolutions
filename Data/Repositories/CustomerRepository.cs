using DataObjects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using DataAccess.Repositories;

namespace Data;

public class CustomerRepository : BaseRepository
{
    public CustomerRepository() : base()
    {
    }

    public List<CustomerDO> GetAll()
    {
        var rtn =
            (from x in Database.Customer
                select new CustomerDO()
                {
                    CustomerID = x.CustomerId,
                    Name = x.Name
                }).ToList();
        return rtn;
    }

}


