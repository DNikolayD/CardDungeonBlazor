using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Interfaces
    {
    public interface IDecksService
        {
        DeckServiceModel Add ( DeckServiceModel deckServiceModel );

        List<DeckServiceModel> Show ( string userName );

        bool Edit ( DeckServiceModel deckServiceModel );

        bool Delete ( string deckId );

        UserServiceModel GetUserByName ( string name );

        DeckServiceModel ShowFull ( string deckId );

        }
    }
