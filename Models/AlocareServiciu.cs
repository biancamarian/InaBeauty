namespace InaBeauty.Models
{
    public class AlocareServiciu
    {
        public int MembruID { get; set; }
        public int ServiciuID { get; set; }
        public Membru Membru { get; set; }
        public Serviciu Serviciu { get; set; }


    }
}