﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BOOKSTORE.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; } =new List<Book>();       
    }
}
