using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto
    {
          public string Username { get; set; }

        //[Required]
        public string Password { get; set; }
        
    }
}