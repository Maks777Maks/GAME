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
    class Contract : IContract, ICallback, IMove
    {
        private readonly Context context;
        private Player Player;
        private static List<ICallbackDuplex> contracts = new List<ICallbackDuplex>();

       

        public void StartGame(PlayerDTO player)
        {
            ICallbackDuplex callback = OperationContext.Current.GetCallbackChannel<ICallbackDuplex>();
            contracts.Add(callback);
            Logger.Log("Player join");
            if (contracts.Count % 2 == 0)
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

        public List<Move> MakeMove(List<Move> moves)
        {
            throw new NotImplementedException();
        }

        public List<Move> ChekMove(Move moves)
        {
            // Move move = new Move();
            Logger.Log(moves.Name);
            List<int> numbermove=new List<int>();
            List<Move> list = new List<Move>();
            List<List<Move>> wayslist = new List<List<Move>>();
            int tmp1;
            Move thismove=new Move();

            Ways ways = new Ways();
            Logger.Log($"Count ways :  {ways.GetWays().Count().ToString()}");
            foreach (var way in ways.GetWays())
            {
                for (int  _move=0;_move<way.Count;_move++)
                {
                    if (way[_move].Name == moves.Name)
                    {
                        wayslist.Add(way);
                        if (thismove.Name == "")
                            thismove = way[_move];

                        numbermove.Add(_move);

                    }
                }
            }

            Logger.Log($"Count numbermove  {numbermove.Count}");


           
                for (int j = 0; j < numbermove.Count; j++)
                {
                foreach (var way in wayslist)
                {
                    Logger.Log($"numbermove: {numbermove[j]}");
                    if (numbermove[j] < way.Count&&numbermove[j]!=0)
                    {
                       
                           tmp1 = numbermove[j];
                        
                            Logger.Log($"Way[tmp1-1]:{way[tmp1 - 1].Name}");
                            if (way[tmp1 - 1].Color == "Empty" && way[tmp1 - 1].Color != ""&&way[tmp1 - 1]!=null)
                            {
                                Logger.Log($"way[tmp1-1] Name:  {way[tmp1 - 1].Name}");
                                list.Add(way[tmp1 - 1]);
                            }



                            if (way[tmp1 - 1].Color !=thismove.Color&&way[tmp1-1].Color!="Empty"&&way[tmp1 - 2] != null&&way[tmp1-2].Color=="Empty" &&way[tmp1-2].Name!="")

                            {
                                list.Add(way[tmp1 - 2]);
                            }



                        //if (way[tmp1 + 2].Color != moves.Color && way[tmp1 + 2].Name != "Empty" && way[tmp1 + 2] != null)
                        //{
                        //    list.Add(way[tmp1 + 2]);
                        //}

                    }
                }
             }
            
            Logger.Log($"Count list moves:  {list.Count().ToString()}");

            return list;
            
        }
    }
}
