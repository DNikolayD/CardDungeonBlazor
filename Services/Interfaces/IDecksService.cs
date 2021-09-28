using System.Collections.Generic;
using Services.ServiceModels.CardsModels;

namespace Services.Interfaces
    {
    public interface IDecksService
        {
        void Add ( AddDecksServiceModel model );

        List<CardTypeServiceModel> GetCardTypeViewModels ();

        AllDecksServiceModel GetAll ();

        string GetId ( string name );

        AddDecksServiceModel GetDeck ( string id );

        void Delete ( string id );

        void Edit ( string id, AddDecksServiceModel model );

        FullDeckServiceModel GetFullDeckView ( string id );
        }
    }
