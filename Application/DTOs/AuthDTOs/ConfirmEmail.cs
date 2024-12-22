using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.AuthDTOs
{
    public class ConfirmEmail
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
