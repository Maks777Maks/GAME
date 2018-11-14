using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Util
{
    public class Ways
    {

        public List<List<Move>> ways;






        //B8.Source = checkblack;
        //D8.Source = checkblack;
        //F8.Source = checkblack;
        //H8.Source = checkblack;
        //A7.Source = checkblack;
        //C7.Source = checkblack;
        //E7.Source = checkblack;
        //G7.Source = checkblack;
        //B6.Source = checkblack;
        //D6.Source = checkblack;
        //F6.Source = checkblack;
        //H6.Source = checkblack;


        //    A1.Source = checkwhite;
        //    C1.Source = checkwhite;
        //    E1.Source = checkwhite;
        //    G1.Source = checkwhite;
        //    B2.Source = checkwhite;
        //    D2.Source = checkwhite;
        //    F2.Source = checkwhite;
        //    H2.Source = checkwhite;
        //    A3.Source = checkwhite;
        //    C3.Source = checkwhite;
        //    E3.Source = checkwhite;
        //    G3.Source = checkwhite;

        public List<Move> GoldWay = new List<Move>() { new Move { Name = "a1", Color = "White" }, new Move { Name = "b2", Color = "White" }, new Move { Name = "c3", Color = "White" }, new Move { Name = "d4", Color = "Empty" }, new Move { Name = "e5", Color = "Empty" }, new Move { Name = "f6", Color = "Black" }, new Move { Name = "g7", Color = "Black" }, new Move { Name = "h8", Color = "Black" } };
        public List<Move> TripleWayA3F8 = new List<Move>() { new Move { Name = "a3", Color = "White" }, new Move { Name = "b4", Color = "Empty" }, new Move { Name = "c5", Color = "Empty" }, new Move { Name = "d6", Color = "Black" }, new Move { Name = "e7", Color = "Black" }, new Move { Name = "f8", Color = "Black" } };
        public List<Move> TripleWayC1H6 = new List<Move>() { new Move { Name = "c1", Color = "White" }, new Move { Name = "d2", Color = "White" }, new Move { Name = "e3", Color = "White" }, new Move { Name = "f4", Color = "Empty" }, new Move { Name = "g5", Color = "Empty" }, new Move { Name = "h6", Color = "Black" } };
        public List<Move> TripleWayH6F8 = new List<Move>() { new Move { Name = "h6", Color = "Black" }, new Move { Name = "g7", Color = "Black" }, new Move { Name = "f8", Color = "Black" } };
        public List<Move> TripleWayC1A3 = new List<Move>() { new Move { Name = "c1", Color = "White" }, new Move { Color = "White", Name = "B2" }, new Move { Name = "a3", Color = "White" } };
        public List<Move> DoubleWayH2B8 = new List<Move>() { new Move { Name = "h2", Color = "White" }, new Move { Name = "g3", Color = "White" }, new Move { Name = "f4", Color = "Empty" }, new Move { Name = "e5", Color = "Empty" }, new Move { Name = "d6", Color = "Black" }, new Move { Name = "c7", Color = "Black" }, new Move { Name = "f8", Color = "Black" } };
        public List<Move> DoubleWayG1A7 = new List<Move>() { new Move { Name = "g1", Color = "White" }, new Move { Name = "f2", Color = "White" }, new Move { Name = "e3", Color = "White" }, new Move { Name = "d4", Color = "Empty" }, new Move { Name = "c5", Color = "Empty" }, new Move { Name = "b6", Color = "Black" }, new Move { Name = "a7", Color = "Black" } };
        public List<Move> UltraWayA5D8 = new List<Move>() { new Move { Name = "a5", Color = "Empty" }, new Move { Name = "b6", Color = "Black" }, new Move { Name = "c7", Color = "Black" }, new Move { Name = "d8", Color = "Black" } };
        public List<Move> UltraWayH4D8 = new List<Move>() { new Move { Name = "h4", Color = "Empty" }, new Move { Name = "g5", Color = "Empty" }, new Move { Name = "f6", Color = "Black" }, new Move { Name = "e7", Color = "Black" }, new Move { Name = "d8", Color = "Black" } };
        public List<Move> UltraWayE1H4 = new List<Move>() { new Move { Name = "e1", Color = "White" }, new Move { Name = "f2", Color = "White" }, new Move { Name = "g3", Color = "White" }, new Move { Name = "h4", Color = "Empty" } };
        public List<Move> UltraWayE1A5 = new List<Move>() { new Move { Name = "e1", Color = "White" }, new Move { Name = "d2", Color = "White" }, new Move { Name = "c3", Color = "White" }, new Move { Name = "b4", Color = "Empty" }, new Move { Name = "a5", Color = "Empty" } };



        public List<List<Move>> GetWays()
        {
            ways = new List<List<Move>>() { GoldWay, TripleWayA3F8, TripleWayC1H6, TripleWayH6F8, TripleWayC1A3, DoubleWayH2B8, DoubleWayG1A7, UltraWayA5D8, UltraWayH4D8, UltraWayE1H4, UltraWayE1A5 };
            return ways;
        }


    }

}
