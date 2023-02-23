using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyList.Shared
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateMeasurment { get; set; }

        public DateTime DateMontage { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int Sum { get; set; }

        [MaxLength(50)]
        public string WorkersName { get; set; }
    }
}
