﻿using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        List<PlayerDTO> GetPlayers();

        [OperationContract]
        PlayerDTO AddPlayer(PlayerDTO player);
    }
}