using Services.ServiceModels.CardsModels;

namespace Services.Interfaces
    {
    public interface IAddCardsToDeckService
        {
        AddCardsToDeckServiceModel GetAllCards ();

        void AddCardsToDeckWithId ( string cardId, string deckId );
        }
    }
