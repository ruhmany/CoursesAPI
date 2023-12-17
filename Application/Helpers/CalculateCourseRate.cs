using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class CalculateCourseRate
    {
        public static float ClacRate(IEnumerable<Rating> ratings)
        {
            float sum = ratings.Sum(r => r.RatingValue);
            return ratings.Count() > 0 ? sum/ratings.Count() : 1;
        }
    }
}
