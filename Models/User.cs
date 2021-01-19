using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual UserType IdType { get; set; }
    }
}
