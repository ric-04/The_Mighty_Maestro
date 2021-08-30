using Mighty_Maestro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Questions
{
    public class QuestionDetail
    {
        [Display(Name = "Question Id")]
        public int QuestionId { get; set; }
        [Display(Name = "Question")]
        public string QuestionQuestion { get; set; }
        //[Display(Name ="Correct Choice")]

        //public string CorrectChoice { get; set; }
        //[Display(Name ="Choice One")]

        //public string ChoiceOne { get; set; }
        //[Display(Name = "Choice Two")]

        //public string ChoiceTwo { get; set; }
        //[Display(Name = "Choice Three")]

        //public string ChoiceThree { get; set; }
        [Display(Name = "Question Points")]
        public int QuestionPoints { get; set; }
        //[Display(Name = "Question Genre")]
        //public string QuestionGenre { get; set; }
        [Display(Name = "Question Venue")]
        public VenueName VenueName { get; set; }
        [Display(Name = "Genre Type")]
        public Genre GenreType { get; set; }
    }
}