using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Author { get; set; } = "";

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? CoverImageUrl { get; set; }

        public string? Publisher { get; set; }

        public int? PublishedYear { get; set; }

        public string? Language { get; set; }

        public string CategoryName { get; set; } = "";
    }
}