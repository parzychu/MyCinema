//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCinema
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seance
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public System.DateTime Date { get; set; }
        public string Time { get; set; }
        public int RoomId { get; set; }
    
        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
