using DAL;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Contracts;
using WCF.DTOModels;


namespace WCF.Services
{
    class Contract : IContract
    {
        private readonly Context context;

        

        List<PlayerDTO> IContract.GetPlayers()
        {
            Repository<Player> repository = new Repository<Player>(context);
            List<PlayerDTO> result = new List<PlayerDTO>();

            foreach (var item in repository.GetAll())
            {
                var p = new PlayerDTO { ID = item.ID, Draw = item.Draw, Losing = item.Losing, NickName = item.NickName, Password = item.Password, Victory = item.Victory};
                result.Add(p);
            }
            return result;
        }
    }
}
