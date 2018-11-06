using BLL.Contracts;
using BLL.DTOModels;
using BLL.Util;
using DAL;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Contract : IContract
    {

        private readonly Context context;

        private  Player Player;



        public Contract()
        {
            context = new DAL.Context();
        }




        public PlayerDTO AddPlayer(PlayerDTO player)
        {
            PlayerDTO p=new PlayerDTO();
            Repository<Player> repository = new Repository<Player>();

            foreach(Player i in repository.GetAll())
            {
                if(i.NickName==player.NickName&&i.Password==player.Password)
                {
                    p = Mapper.PlayerDTOFromPlayer(i);
                    return p;
                }
            }


            repository.Create(Mapper.PlayerFromDTO(player));

            foreach (Player i in repository.GetAll())
            {
                if (i.NickName == player.NickName && i.Password == player.Password)
                {
                    p = Mapper.PlayerDTOFromPlayer(i);
                    return p;
                }
            }
            return p;
           
        }




       



        public List<PlayerDTO> GetPlayers()
        {
            Repository<Player> repository = new Repository<Player>();

            List<PlayerDTO> result = new List<PlayerDTO>();


            foreach (var item in repository.GetAll())
            {
                var p = new PlayerDTO { ID = item.ID, NickName=item.NickName,Draw=item.Draw,Losing=item.Losing,Password=item.Password,Victory=item.Victory};

                result.Add(p);
            }

            return result;

        }
    }
}
