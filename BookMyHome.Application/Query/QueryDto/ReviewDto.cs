using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Query.QueryDto
{
    public record ReviewDto
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public DateOnly Date { get; set; }
    }
}
