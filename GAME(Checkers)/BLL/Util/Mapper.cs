﻿using BLL.DTOModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Util
{
    public static class Mapper
    {
        public static Player PlayerFromDTO(PlayerDTO playerdto)
        {
            Player result = new Player();
            result.ID = playerdto.ID;
            result.NickName = playerdto.NickName;
            result.Password = playerdto.Password;
            result.Losing = playerdto.Losing;
            result.Victory = playerdto.Victory;
            result.Draw = playerdto.Draw;
            return result;
        }


    }
}
