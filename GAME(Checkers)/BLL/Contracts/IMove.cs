using BLL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    [ServiceContract]
   public  interface IMove
    {
        [OperationContract]
        List<Move> MakeMove(List<Move>moves);


        [OperationContract]
        List<Move> ChekMove(Move move);

        
    }
}
