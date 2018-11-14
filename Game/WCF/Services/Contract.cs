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
        static List<List<Move>> _ways;

        private static List<PlayerDTO> Players = new List<PlayerDTO>();

        public void StartGame(PlayerDTO player)
        {
            ICallbackDuplex callback = OperationContext.Current.GetCallbackChannel<ICallbackDuplex>();
            contracts.Add(callback);
            Players.Add(player);
            _ways = new List<List<Move>>();
            Logger.Log("Player join");
            if (contracts.Count % 2 == 0)
            {
                Random rand = new Random();
                int a = rand.Next(100);
                int b = rand.Next(100);
                if (a < b)
                {
                    contracts[0].GetInfo(true, Players[0]);
                    contracts[1].GetInfo(false, Players[1]);
                }
                else
                {
                    contracts[0].GetInfo(false, Players[0]);
                    contracts[1].GetInfo(true, Players[1]);
                }
                //contracts.Clear();
                //Players.Clear();
                _ways = ways.GetWays();
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

        public void MakeMove(Move move1, Move move2)

        {

            int tmp1 = 1000;

            int tmp2 = 1000;



            List<Move> _moves = new List<Move>();

            List<Move> moves_ = new List<Move>();


            foreach (var w in _ways)
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].Name == move1.Name)
                    {
                        move1.Color = w[i].Color;

                    }
                }
            }

            if (move1.Color != "")
            {


                foreach (var w in _ways)

                {

                    for (int i = 0; i < w.Count; i++)
                    {
                        if (w[i].Name == move1.Name)
                        {
                            move1.Color = w[i].Color;

                        }


                        if (w[i].Name == move2.Name)
                        {
                            move2.Color = w[i].Color;

                        }

                    }
                }


                foreach (var w in _ways)

                {

                    Logger.Log($"tmp1:  {tmp1}    tmp2:  {tmp2}");
                    if (tmp1 == 1000 || tmp2 == 1000)

                    {
                        for (int i = 0; i < w.Count; i++)

                        {


                            if (w[i].Name == move1.Name && w[i].Color != "")
                            {

                                w[i].Color = move2.Color;

                                tmp1 = i;



                            }


                            if (w[i].Name == move2.Name)
                            {

                                w[i].Color = move1.Color;

                                tmp2 = i;


                            }


                            _moves = w;
                        }
                    }
                    else
                        break;



                    if (tmp1 == 1000 || tmp2 == 1000)
                    {
                        tmp1 = 1000;
                        tmp2 = 1000;
                    }

                }

                if (tmp1 != 1000 && tmp2 != 1000)

                {
                    if (tmp2 > tmp1)
                    {
                        for (int i = 0; i < _moves.Count; i++)
                        {
                            if (i <= tmp2 && i >= tmp1)
                            {
                                moves_.Add(_moves[i]);
                            }
                        }
                    }


                    if (tmp1 > tmp2)
                    {
                        for (int i = 0; i < _moves.Count; i++)
                        {
                            if (i <= tmp1 && i >= tmp2)
                            {
                                moves_.Add(_moves[i]);
                            }
                        }
                    }
                }

            }



            

            contracts[0].MakeMoveDuplex(moves_);
            contracts[1].MakeMoveDuplex(moves_);     
            

            //////////
            //List<Move> tmp = new List<Move>();
            //Move m1 = new Move();
            //Move m2 = new Move();
            //m1.Name = "c3";
            //m1.Color = "none";
            //m2.Name = "b4";
            //m2.Color = "white";
            //tmp.Add(m1);
            //tmp.Add(m2);
            //contracts[0].MakeMoveDuplex(tmp);
            //contracts[1].MakeMoveDuplex(tmp);           
        }






        public List<Move> ChekMove(Move moves)
        {
            Logger.Log(moves.Name);


            List<Move> list = new List<Move>();

            List<List<Move>> wayslist = new List<List<Move>>();



            Move thismove = new Move();

            string thismovecolor = "";


            foreach (var way in _ways)
            {
                if (thismovecolor == "")
                {
                    for (int _move = 0; _move < way.Count; _move++)
                    {
                        if (way[_move].Name == moves.Name)
                        {
                            thismovecolor = way[_move].Color;

                            break;

                        }
                    }
                }
                else
                    break;

            }





            if (thismovecolor == "Black")
            {



                foreach (var way in _ways)
                {

                    for (int _move = 0; _move < way.Count; _move++)
                    {
                        if (way[_move].Name == moves.Name)
                        {

                            wayslist.Add(way);


                        }
                    }


                }




                foreach (var v in wayslist)
                {
                    for (int i = 0; i < v.Count; i++)
                    {
                        if (i > 0)
                            if (v[i].Name == moves.Name)
                            {

                                if (v[i - 1].Color == "Empty" && v[i - 1].Color != "" && v[i - 1] != null)
                                {

                                    list.Add(v[i - 1]);
                                }


                                if(i>1)
                                {
                                    if (v[i - 1].Color != v[i].Color && v[i - 1].Color != "Empty" && v[i - 2].Color == "Empty")
                                    {

                                        list.Add(v[i - 2]);
                                    }
                                }
                                if(i!= v.Count-1)
                                {
                                    if (i + 2 < v.Count && v[i + 2].Color == "Empty" && v[i + 1].Color != "Empty" && v[i + 1].Color != v[i].Color && v[i + 2] != null)
                                    {
                                        list.Add(v[i + 2]);
                                    }
                                }
                                
                            }
                    }
                }









            }



            if (thismovecolor == "White")
            {


                foreach (var way in _ways)
                {

                    for (int _move = 0; _move < way.Count; _move++)
                    {
                        if (way[_move].Name == moves.Name)
                        {


                            wayslist.Add(way);



                        }
                    }


                }




                foreach (var v in wayslist)
                {
                    for (int i = 0; i < v.Count - 1; i++)
                    {

                        if (v[i].Name == moves.Name)
                        {

                            if (v[i + 1].Color == "Empty" && v[i + 1].Color != "" && v[i + 1] != null)
                            {

                                list.Add(v[i + 1]);
                            }


                            if (i != v.Count - 1)
                            {
                                if (v[i + 1].Color != v[i].Color && v[i + 1].Color != "Empty" && v[i + 2].Color == "Empty")
                                {
                                    list.Add(v[i + 2]);
                                }
                            }



                            if (i - 2 > 0 && v[i - 2].Color == "Empty" && v[i - 1].Color != "Empty" && v[i - 1].Color != thismove.Color && v[i - 2] != null)
                            {
                                list.Add(v[i - 2]);
                            }



                        }


                    }


                }


            }

            return list;


            //List<Move> m = new List<Move>();
            //Move m1 = new Move();
            //Move m2 = new Move();
            //if(moves.Name=="c3")
            //{
            //    m1.Name = "b4";
            //    m2.Name = "d4";
            //    m.Add(m1);
            //    m.Add(m2);
            //    return m;
            //}
            //else if(moves.Name == "f6")
            //{
            //    m1.Name = "g5";
            //    m2.Name = "e5";
            //    m.Add(m1);
            //    m.Add(m2);
            //    return m;
            //}
            //return m;

        }
    }
}
