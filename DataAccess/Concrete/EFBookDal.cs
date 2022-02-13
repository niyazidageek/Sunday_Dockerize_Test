using System;
using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;

namespace DataAccess.Concrete
{
    public class EFBookDal: EFRepositoryBase<Book, AppDbContext>, IBookDal
    {
        public EFBookDal(AppDbContext context) : base(context)
        {
        }
    }
}
