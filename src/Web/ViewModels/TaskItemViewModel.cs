using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace TimetrackerWebApp.ViewModels
{
    public class TaskItemViewModel
    {


        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(CategoryEnum))]
        public CategoryEnum Category { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDateTime { get; set;}
        [Display(Name = "End Date")]
        public DateTime EndDateTime { get; set; }

        
    }


}
