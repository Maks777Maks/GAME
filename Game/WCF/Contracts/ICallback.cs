using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.DTOModels;

namespace WCF.Contracts
{
    [ServiceContract(CallbackContract = typeof(ICallbackDuplex))]
    public interface ICallback
    {
        
        [OperationContract]
        void StartGame(PlayerDTO player);
    }
}
