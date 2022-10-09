﻿using System;
using System.ComponentModel.DataAnnotations;

namespace testingen.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }

}

