using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }       
        public Decimal ActualPrice { get; set; }
        public decimal PurchasePrice { get; set; }       
        public Vehicle Vehicle{ get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public Users User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PurchaseType { get; set; }




    }
}
