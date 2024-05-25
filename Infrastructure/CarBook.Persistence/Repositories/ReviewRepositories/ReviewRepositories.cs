using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Application.ViewModel;
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

        public List<GetReviewByCarViewModel> GetReviewByCar(int CarId)
        {
            var TotalComment = (int)_carBookContext.Reviews.Count(x => x.CarId == CarId);

            List<GetReviewByCarViewModel> getReviewByCarViewModels = new List<GetReviewByCarViewModel>();
            using (var command = _carBookContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select RaytingValue,Count(*),((100*Count(*))/ "+ TotalComment + "),Sum(RaytingValue) From Reviews Where CarId = '"+CarId+ "' group by RaytingValue order by RaytingValue desc";
                command.CommandType = System.Data.CommandType.Text;
                _carBookContext.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetReviewByCarViewModel getReviewByCarViewModel = new GetReviewByCarViewModel()
                        {
                            CommentScore = Convert.ToInt32(reader[0]),
                            CommentCount = Convert.ToInt32(reader[1]),
                            PointPercentage = Convert.ToInt32(reader[2]),
                            TotalScore = Convert.ToInt32(reader[3])
                        };
                        getReviewByCarViewModels.Add(getReviewByCarViewModel);
                    }
                }
                _carBookContext.Database.CloseConnection();
                return getReviewByCarViewModels;
            }
        }

        public async Task<List<Review>> GetReviewByCarId(int CarId)
        {
            return await _carBookContext.Reviews.Where(x=>x.CarId == CarId).OrderByDescending(x=>x.ReviewDate).ToListAsync();
        }
    }
}
