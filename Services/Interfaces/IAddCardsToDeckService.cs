using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServiceModels.CardsModels;

namespace Services.Interfaces
    {
    public interface IAddCardsToDeckService
        {
        AddCardsToDeckServiceModel GetAllCards ();

        void AddCardsToDeckWithId ( string cardId, string deckId );
        }
    }
