using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Models;
using Services.ServiceModels.CardsModels;
using Services.ServiceModels.GameModels;

namespace Services.Interfaces
    {
    public interface IGameService
        {
        Task<GameServiceModel> PlayCard ( string cardId, string playerName, GameServiceModel game );

        DecksServiceModel GetDeck ( string playerName, string id );

        List<CardServiceModel> GetCardsInHand ();

        Task EndTurn ();
        }
    }
