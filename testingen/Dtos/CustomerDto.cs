using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using testingen.Models;

namespace testingen.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }

        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}

