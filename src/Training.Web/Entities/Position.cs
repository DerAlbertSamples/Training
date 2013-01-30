using System;

namespace Training.Web.Entities
{
    public class Position
    {
        public int Id { get;  set; }

        public Person Person { get; set; }

        public string Bezeichnung { get; set; }

        public DateTime Start { get; set; }

        public DateTime? Ende { get; set; }
    }
}