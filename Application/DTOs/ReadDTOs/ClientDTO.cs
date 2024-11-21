using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.ReadDTOs
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public string CityName {  get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }

    }
}
