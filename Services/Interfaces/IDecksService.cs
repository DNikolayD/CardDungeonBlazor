using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        void Edit ( string id, AddDecksServiceModel model );

        FullDeckServiceModel GetFullDeckView ( string id );
        }
    }
