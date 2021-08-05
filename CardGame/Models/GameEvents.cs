using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public enum GameEvents
    {
        StartGame,
        SelectCard,
        EndTurn,
        StartTurn,
        TookEffect,
        Died,
    }
}
