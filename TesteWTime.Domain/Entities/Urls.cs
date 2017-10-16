using System;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations; 
using TesteWTime.Resources.Resources;

namespace TesteWTime.Domain.Entities
{
    public class Urls
   {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = nameof(Language.ID), ResourceType = typeof(Language))]
        public Int64 UrlId { get; set; }
        [Required(ErrorMessageResourceName = nameof(Errors.FieldRequired), ErrorMessageResourceType = typeof(Errors))]
        [Display(Name = nameof(Language.Hits), ResourceType = typeof(Language))]
        public Int64 Hits { get; set; }
        [Required(ErrorMessageResourceName = nameof(Errors.FieldRequired), ErrorMessageResourceType = typeof(Errors))]
        [Display(Name = nameof(Language.Url), ResourceType = typeof(Language))]
        public String Url { get; set; }
        [Required(ErrorMessageResourceName = nameof(Errors.FieldRequired), ErrorMessageResourceType = typeof(Errors))]
        [Display(Name = nameof(Language.ShortUrl), ResourceType = typeof(Language))]
        public String ShortUrl { get; set; }

        #endregion
   }
}


