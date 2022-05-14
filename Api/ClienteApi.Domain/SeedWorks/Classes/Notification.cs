using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClienteApi.Domain.SeedWorks.Classes
{
    public class Notification
    {
        [Key]
        public int CodeNumber { get; set;}
        public string Message { get; set; }
        public string Description { get; set; }

        public bool Active { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }

        [NotMapped]
        public List<Notification> Notifications { get; set; }

        public Notification()
        {

        }
        public Notification(string message)
        {
            Message = message;
        }
        public Notification(int codeNumber, string description, string message,bool mock = false)
        {
            CodeNumber = codeNumber;
            Message = message;
            Description = description;
            if (mock)
            {
                CreateAt = DateTime.Now;
                CreateBy = "system";
            }
            
            Active = true;
        }



    }
}
