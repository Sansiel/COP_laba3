using System;
using System.Runtime.Serialization;

namespace ProdDAL.ViewModels
{
    [DataContract]
    public class ProductViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductUnit { get; set; }

        [DataMember]
        public int ProductAmount { get; set; }

        [DataMember]
        public DateTime ProductData { get; set; }
    }
}
