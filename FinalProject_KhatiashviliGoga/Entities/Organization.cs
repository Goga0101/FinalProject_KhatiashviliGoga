﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject_KhatiashviliGoga.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }

        [MaxLength(100),MinLength(2)]

        
        public string Name { get; set; }

        [MaxLength(200), MinLength(2)]

        public string Adress { get; set; }

        public Guid? ParentId { get; set; }
    }
}
