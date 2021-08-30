using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Data
{
    public class Question
    {   [Key]
        public int QuestionId { get; set; }
        public Guid OwnerId { get; set; }

        public string QuestionQuestion { get; set; }
        //public string CorrectChoice { get; set; }
        //public string ChoiceOne { get; set; }
        //public string ChoiceTwo { get; set; }
        //public string ChoiceThree { get; set; }
        public int QuestionPoints { get; set; }
        //public bool HasAnswer { get; set; } = false;

        //public string QuestionGenre { get; set; }
        public Genre GenreType { get; set; }
        //[ForeignKey(nameof(Venue))]
        //public int VenueId { get; set; }
        //public virtual Venue Venue { get; set; }
        public VenueName VenueName { get; set; }

        public Question()
        {

        }
    }
}