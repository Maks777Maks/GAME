using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Contracts;
using WCF.Util;

namespace WCF.Contracts
{
    [ServiceContract]
    public interface IMove
    {
        [OperationContract]
        void MakeMove(Move move1, Move move2);


        [OperationContract]
        List<Move> ChekMove(Move move);


    }
}
