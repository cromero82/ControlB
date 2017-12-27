namespace Model.BL
{
    public partial class SegPermisos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegPermisos() { }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int Estado { get; set; }
        public int Estregistro { get; set; }
    }
}
