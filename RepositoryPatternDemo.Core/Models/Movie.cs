using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string StoryLine { get; set; }

        public int Year { get; set; }

        public byte[]? Poster { get; set; }

        public double Rate { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
