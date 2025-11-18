using System.Text.Json.Serialization;

namespace RegalLogoIntegration.Models
{
    
    public class CLCARD
    {
        public int LOGICALREF { get; set; }
        public short ACTIVE { get; set; }
        public short CARDTYPE { get; set; }
        public string CODE { get; set; }
        public string DEFINITION_ { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public string POSTCODE { get; set; }
        public string TELNRS1 { get; set;}
        public string TELNRS2 { get;set;}
        public string FAXNR { get; set; }
        public string TAXNR { get; set; }
        public string TAXOFFICE { get;}
        public string INCHARGE { get; set; }
       

    }
}
