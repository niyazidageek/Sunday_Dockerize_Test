using System;
using Core.Repository;
using Entities.Models;

namespace DataAccess.Abstract
{
    public interface IBookDal: IRepository<Book>
    {
    }
}
