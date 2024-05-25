using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DtoLayer.Dtos.ReviewDtos
{
    public class ResultReviewByCarDto
    {
        public int CommentScore { get; set; }
        public int CommentCount { get; set; }
        public int PointPercentage { get; set; }
        public int TotalScore { get; set; }
    }
}
