using BLL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
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

        public List<Move> GoldWay = new List<Move>() { new Move {Name="A1",Color="White"},new Move {Name="B2",Color="White"},new Move {Name="C3",Color="White"}, new Move { Name = "D4", Color = "Empty" }, new Move {Name="E5",Color="Empty"},new Move {Name="F6",Color="Black"},new Move {Name="G7",Color="Black"},new Move {Name="H8",Color="Black"}};
        public List<Move> TripleWayA3F8 = new List<Move>() { new Move {Name="A3",Color="White"},new Move {Name="B4",Color="Empty"},new Move {Name="C5",Color="Empty"},new Move {Name="D6",Color="Black"},new Move {Name="E7",Color="Black"},new Move {Name="F8",Color="Black"}};
        public List<Move> TripleWayC1H6 = new List<Move>() { new Move {Name="C1",Color="White"},new Move {Name="D2",Color="White"},new Move {Name="E3",Color="White"},new Move {Name="F4",Color="Empty"},new Move {Name="G5",Color="Empty"},new Move {Name="H6",Color="Black"}};
        public List<Move> TripleWayH6F8 = new List<Move>() { new Move { Name = "H6", Color = "Black" }, new Move { Name = "G7", Color = "Black" }, new Move { Name = "F8", Color = "Black" } };
        public List<Move> TripleWayC1A3 = new List<Move>() { new Move { Name = "C1", Color = "White" }, new Move { Color = "White", Name = "B2" }, new Move { Name = "A3", Color = "White" } };
        public List<Move> DoubleWayH2B8 = new List<Move>() { new Move { Name = "H2", Color = "White" }, new Move { Name = "G3", Color = "White" }, new Move { Name = "F4", Color = "Empty" }, new Move { Name = "E5", Color = "Empty" }, new Move { Name = "D6", Color = "Black" }, new Move { Name = "C7", Color = "Black" }, new Move { Name = "F8", Color = "Black" } };
        public List<Move> DoubleWayG1A7 = new List<Move>() { new Move { Name = "G1", Color = "White" }, new Move { Name = "F2", Color = "White" }, new Move { Name = "E3", Color = "White" }, new Move { Name = "D4", Color = "Empty" }, new Move { Name = "C5", Color = "Empty" }, new Move { Name = "B6", Color = "Black" }, new Move { Name = "A7", Color = "Black" } };
        public List<Move> UltraWayA5D8 = new List<Move>() { new Move { Name = "A5", Color = "Empty" }, new Move { Name = "B6", Color = "Black" }, new Move { Name = "C7", Color = "Black" }, new Move { Name = "D8", Color = "Black" } };
        public List<Move> UltraWayH4D8 = new List<Move>() { new Move { Name = "H4", Color = "Empty" }, new Move { Name = "G5", Color = "Empty" }, new Move { Name = "F6", Color = "Black" }, new Move { Name = "E7", Color = "Black" }, new Move { Name = "D8", Color = "Black" } };
        public List<Move> UltraWayE1H4 = new List<Move>() { new Move { Name = "E1", Color = "White" }, new Move { Name = "F2", Color = "White" }, new Move { Name = "G3", Color = "White" }, new Move { Name = "H4", Color = "Empty" } };
        public List<Move> UltraWayE1A5 = new List<Move>() { new Move { Name = "E1", Color = "White" }, new Move { Name = "D2", Color = "White" }, new Move { Name = "C3", Color = "White" }, new Move { Name = "B4", Color = "Empty" }, new Move { Name = "A5", Color = "Empty" } };



        public List<List<Move>> GetWays()
        {
            ways = new List<List<Move>>() { GoldWay, TripleWayA3F8, TripleWayC1H6, TripleWayH6F8, TripleWayC1A3, DoubleWayH2B8, DoubleWayG1A7, UltraWayA5D8, UltraWayH4D8, UltraWayE1H4, UltraWayE1A5};
            return ways;
        }

    }
}
