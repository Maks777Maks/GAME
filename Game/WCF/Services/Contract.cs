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

        public List<Move> MakeMove(Move move1, Move move2)

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


                        if (w[i].Name == move1.Name)
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





            if (tmp1 > tmp2)
            {

                if (tmp1 - tmp2 > 2)
                {
                    for (int i = tmp1; i < tmp2; i++)
                    {
                        moves_.Add(_moves[i]);

                    }
                }
                else
                {
                    moves_.Add(_moves[tmp1]);

                    moves_.Add(_moves[tmp2]);

                }
            }




            if (tmp1 < tmp2)
            {

                if (tmp2 - tmp1 > 2)
                {
                    for (int i = tmp2; i < tmp1; i++)
                    {
                        moves_.Add(_moves[i]);

                    }
                }
                else
                {
                    moves_.Add(_moves[tmp1]);

                    moves_.Add(_moves[tmp2]);

                }

            }

           
            return moves_;
            


        }






        public List<Move> ChekMove(Move moves)
        {

            Logger.Log(moves.Name);
           

            List<Move> list = new List<Move>();

            List<List<Move>> wayslist = new List<List<Move>>();

           

            Move thismove = new Move();

            string thismovecolor="";


            foreach (var way in ways.GetWays())
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

                

                    foreach (var way in ways.GetWays())
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
                        if(i>0)
                        if (v[i].Name == moves.Name)
                        {
                           
                            if (v[i - 1].Color == "Empty" && v[i - 1].Color != "" && v[i - 1] != null)
                            {
                               
                                list.Add(v[i - 1]);
                            }



                            if (v[i - 1].Color != v[i].Color && v[i - 1].Color != "Empty" &&  v[i - 2].Color == "Empty" )
                            {
                                
                                list.Add(v[i - 2]);
                            }




                            if (i + 2 <v.Count && v[i + 2].Color == "Empty" && v[i + 1].Color != "Empty" && v[i + 1].Color != v[i].Color && v[i + 2] != null)
                            {
                                list.Add(v[i + 2]);
                            }
                        }
                    }
                }



                //for (int j = 0; j < numbermove.Count; j++)
                //{
                //    foreach (var way in wayslist)
                //    {

                //        if (numbermove[j] < way.Count && numbermove[j] > 0)
                //        {

                //            tmp1 = numbermove[j];
                //            Logger.Log($"tmp1: {tmp1}");

                //            if (way[tmp1 - 1].Color == "Empty" && way[tmp1 - 1].Color != "" && way[tmp1 - 1] != null)
                //            {
                //                list.Add(way[tmp1 - 1]);
                //            }



                //            if (way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 2] != null && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 2].Name != "")
                //            {
                //                list.Add(way[tmp1 - 2]);
                //            }




                //            if (numbermove[j] + 2 < way.Count && way[tmp1 + 2].Color == "Empty" && way[tmp1 + 1].Color != "Empty" && way[tmp1 + 1].Color != thismove.Color && way[tmp1 + 2] != null)
                //            {
                //                list.Add(way[tmp1 + 2]);
                //            }

                //        }
                //    }
                //}






            }



            if (thismovecolor == "White")
            {


                foreach (var way in ways.GetWays())
                {

                    for (int _move = 0; _move < way.Count; _move++)
                    {
                        if (way[_move].Name == moves.Name)
                        {
                            

                            wayslist.Add(way);



                        }
                    }


                }

               


                foreach(var v in wayslist)
                {
                    for(int i=0;i<v.Count-1;i++)
                    {
                        
                        if(v[i].Name==moves.Name)
                        {
                           
                            if (v[i+1].Color == "Empty" && v[i + 1].Color != "" && v[i + 1] != null)
                            {
                                
                                list.Add(v[i + 1]);
                            }



                            if (v[i + 1].Color != thismove.Color && v[i + 1].Color != "Empty" && v[i + 2] != null && v[i + 2].Color == "Empty" && v[i + 2].Name != "")
                            {
                                list.Add(v[i + 2]);
                            }




                             if (i - 2 > 0 && v[i - 2].Color == "Empty" && v[i - 1].Color != "Empty" && v[i - 1].Color != thismove.Color && v[i - 2] != null)
                             {
                                    list.Add(v[i - 2]);
                             }



                        }


                    }


                }



               }






            //if (way[tmp1 + 1].Color != thismove.Color && way[tmp1 + 1].Color != "Empty" && way[tmp1 + 2] != null && way[tmp1 + 2].Color == "Empty" && way[tmp1 + 2].Name != "")
            //{
            //    list.Add(way[tmp1 + 2]);
            //}




            //if (numbermove[j] - 2 < way.Count && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 2] != null)
            //{
            //    list.Add(way[tmp1 - 2]);
            //}

            //foreach (var way in ways.GetWays())
            //{
            //    for (int _move = 0; _move < way.Count; _move++)
            //    {
            //        if (way[_move].Name == moves.Name)
            //        {
            //            Logger.Log($"way[_move].Name: {way[_move].Name}");
            //            wayslist.Add(way);

            //            thismove = way[_move];

            //            numbermove.Add(_move);

            //        }
            //    }
            //}







            //Logger.Log($"thismove color: {thismove.Color}");
            //Logger.Log($"thismove name: {thismove.Name}");
            //Logger.Log($"numbermove[1]: {numbermove[0]}      numbermove[2]: {numbermove[1]}");



            //if (thismove.Color == "Black")
            //{
            //    Logger.Log("thismove.Color==Black");
            //    for (int j = 0; j < numbermove.Count; j++)
            //    {
            //        foreach (var way in wayslist)
            //        {

            //            if (numbermove[j] < way.Count && numbermove[j] > 0)
            //            {

            //                tmp1 = numbermove[j];
            //                Logger.Log($"tmp1: {tmp1}");

            //                if (way[tmp1 - 1].Color == "Empty" && way[tmp1 - 1].Color != "" && way[tmp1 - 1] != null)
            //                {
            //                    list.Add(way[tmp1 - 1]);
            //                }



            //                if (way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 2] != null && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 2].Name != "")
            //                {
            //                    list.Add(way[tmp1 - 2]);
            //                }




            //                if (numbermove[j] + 2 < way.Count && way[tmp1 + 2].Color == "Empty" && way[tmp1 + 1].Color != "Empty" && way[tmp1 + 1].Color != thismove.Color && way[tmp1 + 2] != null)
            //                {
            //                    list.Add(way[tmp1 + 2]);
            //                }

            //            }
            //        }
            //    }
            //}

            //if (thismove.Color == "White")
            //{

            //    Logger.Log("thismove.Color==White");


            //    for (int j = numbermove.Count; j > 0; j--)
            //    {
            //        foreach (var way in wayslist)
            //        {

            //            if (numbermove[j] < way.Count - 1 && numbermove[j] > 0)
            //            {

            //                tmp1 = numbermove[j];


            //                if (way[tmp1 - 1].Color == "Empty" && way[tmp1 - 1].Color != "" && way[tmp1 - 1] != null)
            //                {
            //                    list.Add(way[tmp1 - 1]);
            //                }



            //                if (way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 2] != null && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 2].Name != "")
            //                {
            //                    list.Add(way[tmp1 - 2]);
            //                }




            //                if (numbermove[j] - 2 < way.Count && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 2] != null)
            //                {
            //                    list.Add(way[tmp1 - 2]);
            //                }

            //            }
            //        }
            //    }
            //}









            //    //for (int j = 0; j < numbermove.Count; j++)
            //    //{
            //    //    foreach (var way in wayslist)
            //    //    {

            //    //        if (numbermove[j] < way.Count && numbermove[j] >= 0)
            //    //        {

            //    //            tmp1 = numbermove[j];
            //    //            Logger.Log($"tmp1: {tmp1}");


            //    //            if (way[tmp1 + 1].Color == "Empty" && way[tmp1 + 1].Color != "" && way[tmp1 + 1] != null)
            //    //            {
            //    //                list.Add(way[tmp1 + 1]);
            //    //            }



            //    //            if (way[tmp1 + 1].Color != thismove.Color && way[tmp1 + 1].Color != "Empty" && way[tmp1 + 2] != null && way[tmp1 + 2].Color == "Empty" && way[tmp1 + 2].Name != "")
            //    //            {
            //    //                list.Add(way[tmp1 + 2]);
            //    //            }




            //    //            if (numbermove[j] - 2 >0 && way[tmp1 - 2].Color == "Empty" && way[tmp1 - 1].Color != "Empty" && way[tmp1 - 1].Color != thismove.Color && way[tmp1 - 2] != null)
            //    //            {
            //    //                list.Add(way[tmp1 - 2]);
            //    //            }

            //    //        }
            //    //    }
            //    //}

            //}



            return list;

        }



    }
}
