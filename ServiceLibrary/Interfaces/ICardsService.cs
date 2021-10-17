using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Interfaces
    {
    public interface ICardsService
        {
        bool Add ( CardServiceModel cardServiceModel );

        List<CardServiceModel> Show ( string userName );

        bool Edit ( CardServiceModel cardServiceModel );

        bool Delete ( string cardId );

        List<CardTypeServiceModel> ShowTypes ();

        CardServiceModel ShowFull ( string cardId );

        bool AddCardToDeck ( string cardId, string deckId );

        bool RemoveCardFromDeck ( string cardId, string deckId );

        public UserServiceModel GetUserByName ( string name );

        List<CardServiceModel> ShowCardsInTheDeck ( string deckId );
        }
    }
