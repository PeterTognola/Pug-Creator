using System;

namespace PugCreator.Models
{
    public class PugViewModels
    {
    }

    public class Pug
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Coat Coat { get; set; }
    }

    public class Coat
    {
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

        public Coat(string colourCode) : this (Guid.NewGuid(), colourCode)
        {
        }
    }
}
