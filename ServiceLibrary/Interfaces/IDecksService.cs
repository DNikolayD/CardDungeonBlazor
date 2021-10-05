using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CardModels;

namespace ServiceLibrary.Interfaces
    {
    public interface IDecksService
        {
        bool Add ( DeckServiceModel deckServiceModel );

        List<DeckServiceModel> Show ( string userName );

        bool Edit ( DeckServiceModel deckServiceModel );

        bool Delete ( string deckId );
        }
    }
