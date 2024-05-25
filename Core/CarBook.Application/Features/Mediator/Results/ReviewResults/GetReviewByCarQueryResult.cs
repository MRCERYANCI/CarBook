using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByCarQueryResult
    {
        public int CommentScore { get; set; }
        public int CommentCount { get; set; }
        public int PointPercentage { get; set; }
        public int TotalScore { get; set; }
       
    }
}
