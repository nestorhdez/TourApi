/*
    Nombre del tour
    Descripción corta del tour
    Observaciones, permitir html
    Url de una imagen del tour
    Fecha de creación
    Fecha de la última modificación
*/


namespace TourApi.Models
{
    public class Tour
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}