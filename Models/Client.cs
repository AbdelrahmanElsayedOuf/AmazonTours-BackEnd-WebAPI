using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : IEntity
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string FName { get; set; } = string.Empty;
        [StringLength(100)]
        public string LName { get; set; } = string.Empty;

        [StringLength(100)]
        public string IdentityImage { get; set; } = string.Empty;

        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CountdownEvent))]
        public Guid CountryId { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public City City { get; set; } = new();
        public Country Country { get; set; } = new();
        public List<Inquiry> Inquiries { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}
