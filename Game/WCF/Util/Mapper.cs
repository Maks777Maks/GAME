using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.DTOModels;

namespace WCF.Util
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


        public static PlayerDTO PlayerDTOFromPlayer(Player player)
        {
            PlayerDTO result = new PlayerDTO();
            result.ID = player.ID;
            result.NickName = player.NickName;
            result.Password = player.Password;
            result.Losing = player.Losing;
            result.Victory = player.Victory;
            result.Draw = player.Draw;
            return result;
        }


    }
}

