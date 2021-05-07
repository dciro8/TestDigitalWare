namespace Ophelia.Console.Test.Model
{ 
    using System;

    public class PrestadorDTO
    {
        public Guid? Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Descripcion { get; set; }
        public Guid Estado { get; set; }
        public Guid? TipoDocumento { get; set; }
        public Guid PaisDTO { get; set; }
        public Guid Municipio { get; set; }
        public Guid Moneda { get; set; }
        public string RepresentanteLegal { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool ServicioOrdena { get; set; }
        public bool ServicioEjecuta { get; set; }
        public string Correo { get; set; }
        public Guid ManualProcedimientoMedicoPorDefecto { get; set; }


    }
}