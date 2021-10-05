using System.Collections.Generic;
using System.Threading.Tasks;
using CardGame;
using Services.ServiceModels.CardsModels;
using Services.ServiceModels.GameModels;

namespace Services.Interfaces
    {
    public interface IGameService
        {
        Task<GameServiceModel> PlayCard ( string cardId, string playerName,);

        DecksServiceModel GetDeck ( string playerName, string id );

        Task<List<CardServiceModel>> GetCardsInHand ();

        public GameServiceModel GameServiceModel { get; set; }
        public EnemyScript Enemy { get; set; }

        Task EndTurn ();
        }
    }
