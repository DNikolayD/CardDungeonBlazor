using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using ServiceLibrary.Models.CardModels;

namespace ServiceLibrary.Interfaces
    {
    public interface ICardsService
        {
        bool Add ( CardServiceModel cardServiceModel );

        List<CardServiceModel> Show ( string userId );

        bool Edit ( CardServiceModel cardServiceModel );

        bool Delete ( string cardId );

        List<CardTypeServiceModel> ShowTypes ();

        CardServiceModel ShowFull ( string cardId );

        bool AddCardToDeck ( string cardId, string deckId );
        }
    }
