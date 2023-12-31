//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Book_Reading_Event_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Event
    {
        [Required]
        [DisplayName("Event ID")]
        public int EventID { get; set; }
        
        [Required]
        public string Title { get; set; }
        [DisplayName("Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
        [DisplayName("Start Time")]
        [Required]
        [DataType(DataType.Time)]
        public System.TimeSpan StartTime { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        [Required]
        [Range(0, 4, ErrorMessage = "Duration should be between 0 and 4 only")]
        public int Duration { get; set; }
      
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum Length is 50 characters")]
        public string Description { get; set; }
        [DisplayName("Other Details")]
        [MaxLength(500, ErrorMessage = "Maximum Length is 500 characters")]
        public string OtherDetails { get; set; }
        [DisplayName("Invite Count")]
        [Required]
        public int InviteCount { get; set; }
        [DisplayName("User ID")]
        [Required]
        public int UserID { get; set; }
        [DisplayName("Public")]
        [Required]
        public bool isPublic { get; set; }
        [DisplayName("User Full Name")]
        [Required]
        public string UserFullName { get; set; }
    }
}
