using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class AddressInformation
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? Country { get; set; }
        public string? DivisionState { get; set; }
        public string? District { get; set; }
        public string? ThanaSubDistrict { get; set; }
        public string? UnionMunicipality { get; set; }
        public string? PostOffice { get; set; }
        public string? PostCode { get; set; }
        public string? BlockSector { get; set; }
        public string? HouseVillage { get; set; }
        public string? RoadNumber { get; set; }
        public string? AddressType { get; set; } // Present / Permanent

        public string Country { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string Union { get; set; }
        public string PostOffice { get; set; }
        public string PostCode { get; set; }
        public string BlockSector { get; set; }
        public string HouseVillage { get; set; }
        public string RoadNumber { get; set; }
        public string AddressType { get; set; }

        public virtual Employee Employee { get; set; }
    }
}