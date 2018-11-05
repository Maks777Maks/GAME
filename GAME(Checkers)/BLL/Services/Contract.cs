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




        public void AddPlayer(PlayerDTO player)
        {
            Repository<Player> repository = new Repository<Player>();

            repository.Create(Mapper.PlayerFromDTO(player));
           
        }




        public void DeletePlayer(PlayerDTO player)
        {
            Repository<Player> repository = new Repository<Player>();

            repository.Delete(Mapper.PlayerFromDTO(player));
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
