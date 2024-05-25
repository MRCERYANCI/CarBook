using CarBook.Application.ViewModel;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewByCarId(int CarId);
        List<GetReviewByCarViewModel> GetReviewByCar(int CarId);
    }
}
