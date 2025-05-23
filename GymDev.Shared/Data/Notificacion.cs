using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDev.Shared.Data
{
    [Table("Notificacion")]
    public class Notificacion
    {
        public enum eCategory { Informativo = 0, Propuesta = 1 }
      
        public enum eAction
        {
            Informativo = 0,
            PropuestaRevisorAgregado = 201,
            PropuestaColaboradorAgregado = 202,
            PropuestaRevisorEliminado = 203,
            PropuestaColaboradorEliminado = 204,
            PropuestaEstatusActualizado = 205
        }
        public enum NotiType
        {
            Info,
            Warning,
            Error,
            Success
        }
        public NotiType Type { get; set; }
        public int Id { get; set; }

        [Key]
        [Required]
   
        public string UserId { get; set; } = null!;

        public eCategory Category { get; set; }

       public String IconClass => Type switch
    
            { 

                NotiType.Info => "fa-regular fa-circle-user ",
                NotiType.Warning => "fa-regular fa-image",
                NotiType.Error => "fa-regular fa-file",
   
                NotiType.Success => "fa-regular fa-thumbs-up text-success",
                _ => "fa-regular fa-bell"
            };
        
        public eAction ActionId { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Body { get; set; }


        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool Read { get; set; }

    }
}
