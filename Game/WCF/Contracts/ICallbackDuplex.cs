using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Util;

namespace WCF.Contracts
{
    public interface ICallbackDuplex
    {
        [OperationContract(IsOneWay = true)]
        void GetInfo(bool b);


        [OperationContract(IsOneWay = true)]
        void MakeMoveDuplex(List<Move> moves);

    }
}
