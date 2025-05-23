using GymDev.Shared.Data;
using static GymDev.Shared.Data.Notificacion;
namespace GymDev.Client.Servicios
{

    public class NotificacionServicio
    {
        public event Action? OnNotificacionesActualizadas;

        private List<Notificacion> _notificaciones = new();
        public async Task InicializarAsync()
        {
            
            _notificaciones = ObtenerMockNotificaciones();

            
        }
        public IReadOnlyList<Notificacion> ObtenerUltimas(int cantidad = 5)
        {
            return _notificaciones.OrderByDescending(n => n.CreateDate).Take(cantidad).ToList();
        }
        public IReadOnlyList<Notificacion> ObtenerTodas()
        {
            return _notificaciones.OrderByDescending(n => n.CreateDate).ToList();
        }

        public void AgregarNotificacion(Notificacion noti)
        {
            _notificaciones.Add(noti);
            OnNotificacionesActualizadas?.Invoke();
        }
        //metodo para actualizaciones auto
        public void MarcarComoLeida(int id)
        {
            var noti = _notificaciones.FirstOrDefault(n => n.Id == id);
            if (noti != null)
            {
                noti.Read = true;
                OnNotificacionesActualizadas?.Invoke();
            }
        }
        //public async Task AñadirNotiAsync(string title, string body, NotiType tipo)
        //{
        //    var n = new Notificacion
        //    {
        //        Title = title,
        //        Body = body,
        //        CreateDate = DateTime.Now,
        //        Read = false,
        //        Type = tipo
        //    };
        //}
        public bool HayNoLeidas() => _notificaciones.Any(n => !n.Read);

        private List<Notificacion> ObtenerMockNotificaciones()
        {
            return new()
               {
                   new Notificacion
                   {
                       Id = 1, 
                       Title = "Nueva Propuesta",
                       Body = "Se ha creado una nueva propuesta para el cliente Acme S.A.",
                       CreateDate = DateTime.Now.AddMinutes(-5),
                       Read = false,
                       Type = NotiType.Info

                   },
                   new Notificacion
                   {
                       Id = 2,  
                       Title = "Archivo Subido",
                       Body = "El archivo 'contrato_final.pdf' fue cargado exitosamente.",
                       CreateDate = DateTime.Now.AddMinutes(-15),
                       Read = false,
                       Type = NotiType.Success
                   },
                   new Notificacion
                   {
                       Id = 3, 
                       Title = "Aprobación Recibida",
                       Body = "La propuesta ID#293 fue aprobada por el cliente.",
                       CreateDate = DateTime.Now.AddHours(-1),
                       Read = true,
                       Type = NotiType.Warning

                   },
                   new Notificacion
                   {
                       Id = 4,
                       Title = "Error en el envío",
                       Body = "No se pudo enviar el correo de confirmación a soporte@empresa.com.",
                       CreateDate = DateTime.Now.AddHours(-2),
                       Read = false,
                       Type = NotiType.Error
                   },
                   new Notificacion
                   {
                       Id = 5,  
                       Title = "Meta Alcanzada",
                       Body = "Has cumplido tu objetivo mensual de propuestas enviadas.",
                       CreateDate = DateTime.Now.AddDays(-1),
                       Read = true

                   },
                   new Notificacion
                   {
                       Id = 6,
                       Title = "prueba 6",
                       Body = "Has cumplido tu objetivo mensual de propuestas enviadas.",
                       CreateDate = DateTime.Now.AddDays(-1),
                       Read = true
                   }
               };
        }
    }
}
