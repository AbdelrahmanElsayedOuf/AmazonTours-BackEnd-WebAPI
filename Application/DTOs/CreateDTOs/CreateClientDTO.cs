using Models.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.CreateDTOs
{
    public class CreateClientDTO
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public Gender Gender { get; set; }
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
    }
}
