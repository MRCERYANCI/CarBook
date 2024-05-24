using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepositories : IReviewRepository
    {
        private readonly CarBookContext _carBookContext;

        public ReviewRepositories(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<Review>> GetReviewByCarId(int CarId)
        {
            return await _carBookContext.Reviews.Where(x=>x.CarId == CarId).OrderByDescending(x=>x.ReviewDate).ToListAsync();
        }
    }
}
