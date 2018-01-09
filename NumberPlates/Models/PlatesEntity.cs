using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumberPlates.Models
{
    public class LocalGovernment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class SpecialNumber
    {   
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
    }

    public class PlateNumber
    {
        [Key]
        public int Id { get; set; }
        public string LGA { get; set; }
        public int Number { get; set; }

        public string Letter { get; set; }

        public string FullNumber()
        {
            return LGA + Number.ToString().PadLeft(3, '0') + Letter;
        }
    }
}