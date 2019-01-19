using AdapostAnimale.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdapostAnimale.Models
{
    public class Dog:IOwner
    {
        public int ID { get; set; }
        //[Required]
        [MinLength(5)]
        public string Nickname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public FurColor FurColor { get; set; }
        public string OwnerName { get; set; }
        [EmailAddress]
        public string OwnerEmail { get; set; }

        public Dog()
        {
        }

        public Dog(int id, string nickname, DateTime dateOfBirth, Gender gender, FurColor color, string ownerName, string ownerEmail)
        {
            this.ID = id;
            this.Nickname = nickname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.FurColor = color;
            this.OwnerName = ownerName;
            this.OwnerEmail = ownerEmail;
        }
    }
}