using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServiceModels.CardsModels;

namespace Services.Interfaces
    {
    public interface ICardsService
        {
        void Add ( AddCardsServiceModel model );
        List<CardTypeServiceModel> GetCardTypeViewModels ();

        AllCardsServiceModel GetAllCards ();

        void Delete ( string id );

        FullCardServiceModel GetFullCardView ( string id );

        AddCardsServiceModel GetEditFomModel ( string id );

        void Edit ( string id, AddCardsServiceModel cardModel );
        }
    }
