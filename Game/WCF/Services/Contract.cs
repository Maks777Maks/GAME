using DAL;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Contracts;
using WCF.DTOModels;
using WCF.Util;

namespace WCF.Services
{
    class Contract : IContract, ICallback
    {
        private readonly Context context;
        private Player Player;
        private static List<ICallbackDuplex> contracts = new List<ICallbackDuplex>();

        public void StartGame(PlayerDTO player)
        {
            ICallbackDuplex callback = OperationContext.Current.GetCallbackChannel<ICallbackDuplex>();
            contracts.Add(callback);
            if (contracts.Count == 2)
            {
                Random rand = new Random();
                int a = rand.Next(100);
                int b = rand.Next(100);
                if (a < b)
                {
                    contracts[0].GetInfo(true);
                    contracts[1].GetInfo(false);
                }
                else
                {
                    contracts[0].GetInfo(false);
                    contracts[1].GetInfo(true);
                }
                contracts.Clear();
            }
        }



        public Contract()
        {
            context = new DAL.Context();
        }

        public PlayerDTO AddPlayer(string a, string b)
        {
            PlayerDTO p = new PlayerDTO();
            Repository<Player> repository = new Repository<Player>(context);

            foreach (Player i in repository.GetAll())
            {
                if (i.NickName == a && i.Password == b)
                {
                    p = Mapper.PlayerDTOFromPlayer(i);
                    return p;
                }
            }

            p = new PlayerDTO { NickName = a, Password = b };
            repository.Create(Mapper.PlayerFromDTO(p));

            foreach (Player i in repository.GetAll())
            {
                if (i.NickName == a && i.Password == b)
                {
                    p = Mapper.PlayerDTOFromPlayer(i);
                    return p;
                }
            }
            return p;

        }

        public List<PlayerDTO> GetPlayers()
        {
            Repository<Player> repository = new Repository<Player>(context);

            List<PlayerDTO> result = new List<PlayerDTO>();


            foreach (var item in repository.GetAll())
            {
                var p = new PlayerDTO { ID = item.ID, NickName = item.NickName, Draw = item.Draw, Losing = item.Losing, Password = item.Password, Victory = item.Victory };

                result.Add(p);
            }

            return result;
        
        }
    }
}
