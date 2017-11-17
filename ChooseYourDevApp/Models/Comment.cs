using System;
using System.Collections.Generic;

namespace ChooseYourDevApp.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public int Dev_Id { get; set; }

        //public virtual ICollection<Dev> Dev_Id { get; set; }
    }
}
