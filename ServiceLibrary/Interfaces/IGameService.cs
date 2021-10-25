using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.GameModels;

namespace ServiceLibrary.Interfaces
    {
    public interface IGameService
        {

        GameServiceModel Game { get; set; }

        void LoadGame ( string playerName, string deckId, int enemyDeck, int draw, int health, int energy );

        void PlayCard ( string playerName, string cardId );

        Task EndTurn ();
        }
    }
