using System;

namespace HerreraSierraVargasAppApuntes2.Models
{
    public class Note
    {
        public string Filename { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}