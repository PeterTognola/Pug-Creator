using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PugCreatorServer.Models
{
    [Table("Pugs")]
    public class Pug
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Coat Coat { get; set; }
    }

    [Table("PugCoat")]
    public class Coat
    {
        [Key]
        public Guid Id { get; set; }

        public string ColourCode { get; set; }

        public Coat()
        {
        }

        public Coat(Guid id, string colourCode)
        {
            Id = id;
            ColourCode = colourCode;
        }

        public Coat(string colourCode) : this(Guid.NewGuid(), colourCode)
        {
        }
    }
}