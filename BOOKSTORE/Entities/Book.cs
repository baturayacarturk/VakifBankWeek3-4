﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BOOKSTORE.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        [JsonIgnore]    
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
