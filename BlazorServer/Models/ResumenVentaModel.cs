namespace BlazorServer.Models
{
    public class ResumenVentaModel
    {
        public int Orden { get; set; }
        public string Descripcion { get; set; }
        public decimal Unidades { get; set; }
        public decimal Valor { get; set; }
    }
}
