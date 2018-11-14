using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Checkers_.Classes;
using UI_Checkers_.ServiceReference1;

namespace UI_Checkers_.Util
{
    public static class MapperUI
    {
        public static Move MoveUIToMove(MoveUI m)
        {
            Move move = new Move();
            move.Name = m.Name;
            move.Queen = m.Queen;
            move.goldWay = m.goldWay;
            move.doubleWay = m.doubleWay;
            move.Color = m.Color;
            move.Border = m.Border;

            return move;
        }

        public static MoveUI MoveToMoveUI(Move m)
        {
            MoveUI move = new MoveUI();
            move.Name = m.Name;
            move.Queen = m.Queen;
            move.goldWay = m.goldWay;
            move.doubleWay = m.doubleWay;
            move.Color = m.Color;
            move.Border = m.Border;

            return move;
        }

        public static PlayerUI PlayerFromDTO(PlayerDTO playerdto)
        {
            PlayerUI result = new PlayerUI();
            result.ID = playerdto.ID;
            result.NickName = playerdto.NickName;
            result.Password = playerdto.Password;
            result.Losing = playerdto.Losing;
            result.Victory = playerdto.Victory;
            result.Draw = playerdto.Draw;
            return result;
        }

        public static PlayerDTO PlayerForDTO(PlayerUI playerui)
        {
            PlayerDTO result = new PlayerDTO();
            result.ID = playerui.ID;
            result.NickName = playerui.NickName;
            result.Password = playerui.Password;
            result.Losing = playerui.Losing;
            result.Victory = playerui.Victory;
            result.Draw = playerui.Draw;
            return result;
        }

        //public static MoveUI PlayerForDTO(Move move)
        //{
        //    MoveUI result = new MoveUI();
        //    result.Name = move.Name;
        //    result.Color = move.Color;
        //    result.Queen = move.Queen;
        //    result.Border = move.Border;
        //    result.doubleWay = move.doubleWay;
        //    result.goldWay = move.goldWay;
        //    return result;
        //}

        //public static MoveUI PlayerForDTO(Move move)
        //{
        //    MoveUI result = new MoveUI();
        //    result.Name = move.Name;
        //    result.Color = move.Color;
        //    result.Queen = move.Queen;
        //    result.Border = move.Border;
        //    result.doubleWay = move.doubleWay;
        //    result.goldWay = move.goldWay;
        //    return result;
        //}
    }
}
