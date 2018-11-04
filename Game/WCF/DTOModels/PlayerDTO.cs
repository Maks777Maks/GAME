using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.DTOModels
{
    [DataContract]
    public class PlayerDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NickName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Victory { get; set; }
        [DataMember]
        public int Draw { get; set; }
        [DataMember]
        public int Losing { get; set; }
    }
}
