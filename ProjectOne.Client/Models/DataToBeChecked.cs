using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOne.Client.Models
{
    public class DataToBeChecked
    {
        public int id { get; set; }
        public string ticketCode { get; set; }
        public DateTime dateCreated { get; set; }
        public string ticketType { get; set; }
        public bool duplicateFromExcelSheet { get; set; }
        public bool duplicateFromDb { get; set; }
    }
}