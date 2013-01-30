using System;

namespace Training.Web.Entities
{
    public class Dokument
    {
        public int Id { get; private set; }
        public string ContentType { get; set; }
        public string Filename { get; set; }
        public byte[] Bytes { get; set; }
    }
}