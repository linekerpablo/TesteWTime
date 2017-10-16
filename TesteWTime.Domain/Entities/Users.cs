using System;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations; 
using TesteWTime.Resources.Resources;

namespace TesteWTime.Domain.Entities
{
    public class Users
   {
        #region Properties


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = nameof(Language.ID), ResourceType = typeof(Language))]
        public Int64 UserId { get; set; }
        [Required(ErrorMessageResourceName = nameof(Errors.FieldRequired), ErrorMessageResourceType = typeof(Errors))]
        [Display(Name = nameof(Language.Name), ResourceType = typeof(Language))]
        public String Name { get; set; }

        #endregion
   }
}


