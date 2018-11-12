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
        Ways ways = new Ways();


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




        public List<Move> ChekMove(Move moves)
        {
            // Move move = new Move();
            Logger.Log(moves.Name);
            List<int> numbermove = new List<int>();
            List<Move> list = new List<Move>();
            List<List<Move>> wayslist = new List<List<Move>>();
            int tmp1;
            Move thismove = new Move();


            Logger.Log($"Count ways :  {ways.GetWays().Count().ToString()}");
            foreach (var way in ways.GetWays())
            {
                for (int _move = 0; _move < way.Count; _move++)
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
                    if (numbermove[j] < way.Count && numbermove[j] > 0)
                    {

                        tmp1 = numbermove[j];

                        Logger.Log($"Way[tmp1-1]:{way[tmp1 - 1].Name}");
                        if (way[tmp1 - 1].Color == "Empty" && way[tmp1 - 1].Color != "" && way[tmp1 - 1] != null)
                        {
                            Logger.Log($"way[tmp1-1] Name:  {way[tmp1 - 1].Name}");
                            list.Add(way[tmp1 - 1]);
                        }



                        if (way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 2] != null && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 2].Name != "")

                        {
                            list.Add(way[tmp1 - 2]);
                        }




                        if (numbermove[j] + 2 < way.Count && way[tmp1 + 2].Color == "Empty" && way[tmp1 + 1].Color != "Empty" && way[tmp1 + 1].Color != thismove.Color && way[tmp1 + 2] != null)
                        {
                            list.Add(way[tmp1 + 2]);
                        }

                    }
                }
            }

            Logger.Log($"Count list moves:  {list.Count().ToString()}");

            return list;

        }




        public List<Move> MakeMove(Move move1,Move move2)
        {
            int tmp1 = 1000;
            int tmp2 = 1000;
            bool tmp = true;
            bool t=false;
            List<Move> _moves = new List<Move>();
            List<Move> moves_ = new List<Move>();
            List<List<Move>> _ways = ways.GetWays();



            foreach (var w in _ways)
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].Name == move1.Name)
                    {
                        
                        Logger.Log($"w[i].Name:  {w[i].Name}");
                        Logger.Log($" w[i].Color:  {w[i].Color}");

                        w[i].Color = move2.Color;
                       
                        Logger.Log($" Set w[i].Color:  {w[i].Color}");
                        tmp1 = i;
                        tmp = false;
                    }

                    if (w[i].Name == move2.Name)
                    {
                        //Logger.Log($"w[i].Name:  {w[i].Name}");
                        //Logger.Log($" w[i].Color:  {w[i].Color}");

                        w[i].Color = move1.Color;
                        //Logger.Log($"w[i].Name:  {w[i].Name}");
                        //Logger.Log($" Set w[i].Color:  {w[i].Color}");
                        tmp2 = i;
                        tmp = true;
                    }

                    if (tmp1!=1000&&tmp2!=1000)
                    {
                        Logger.Log($"tmp1: {tmp1}   tmp2: {tmp2}");
                        _moves = w;
                        //tmp = false;
                        tmp = false;
                        t = true;
                        break;
                    }


                }

                if (t == true)
                    break;

               
            }

            //Logger.Log($"tmp1: {tmp1}  tmp2: {tmp2}  movescount: {_moves.Count}");
            //Logger.Log($"!!!  moves[tmp1]: {_moves[tmp1].Name}   moves[tmp2]: {_moves[tmp2].Name}");


            if (tmp1 > tmp2)
            {
                Logger.Log("tmp1>tmp2");
                if (tmp1 - tmp2 > 2)
                {
                    for (int i = tmp1; i < tmp2; i++)
                    {
                        moves_.Add(_moves[i]);

                        Logger.Log(_moves[i].Name);
                    }
                }
                else
                {
                    moves_.Add(_moves[tmp1]);
                    moves_.Add(_moves[tmp2]);
                    Logger.Log($"!!!  moves[tmp1]: {_moves[tmp1].Name}   moves[tmp2]: {_moves[tmp2].Name}");
                }
            }
             if(tmp1<tmp2)
            {

                
                Logger.Log("tmp1<tmp2");

                if (tmp2 - tmp1 > 2)
                {
                    for (int i = tmp2; i < tmp1; i++)
                    {
                        moves_.Add(_moves[i]);

                        Logger.Log(_moves[i].Name);
                    }
                }
                else
                {
                    moves_.Add(_moves[tmp1]);
                    moves_.Add(_moves[tmp2]);
                    Logger.Log($"!!!  moves[tmp1]: {_moves[tmp1].Name}   moves[tmp2]: {_moves[tmp2].Name}");
                }

            }



            return moves_;


        }





        


    }
}
