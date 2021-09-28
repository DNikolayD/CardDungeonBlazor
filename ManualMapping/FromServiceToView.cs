using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.Data.Models.Common;
using Services.ServiceModels.CardsModels;

namespace ManualMapping
    {
    public static class FromServiceToView
        {
        public static List<CardTypeViewModel> GetCardTypes ( List<CardTypeServiceModel> serviceModels )
            {
            List<CardTypeViewModel> viewModels = new();
            foreach (CardTypeServiceModel serviceModel in serviceModels)
                {
                CardTypeViewModel viewModel = GetCardType(serviceModel);
                viewModels.Add(viewModel);
                }
            return viewModels;
            }
        public static CardTypeViewModel GetCardType ( CardTypeServiceModel cardTypeServiceModel )
            {
            int id = cardTypeServiceModel.Id;
            string name = cardTypeServiceModel.Name;
            CardTypeViewModel viewModel = new()
                {
                Id = id,
                Name = name,
                };
            return viewModel;
            }
        public static AllCardsViewModel GetAllCards ( AllCardsServiceModel allCardsServiceModel )
            {
            AllCardsViewModel allCardsViewModel = new()
                {
                Cards = GetCards(allCardsServiceModel.Cards)
                };
            return allCardsViewModel;
            }
        public static List<CardViewModel> GetCards ( List<CardServiceModel> cardServiceModels )
            {
            List<CardViewModel> cardViewModels = new();
            foreach (CardServiceModel cardServiceModel in cardServiceModels)
                {
                CardViewModel cardViewModel = GetCard(cardServiceModel);
                cardViewModels.Add(cardViewModel);
                }
            return cardViewModels;
            }
        public static CardViewModel GetCard ( CardServiceModel cardServiceModel )
            {
            string id = cardServiceModel.Id;
            string name = cardServiceModel.Name;
            string imageUrl = cardServiceModel.ImageUrl;
            string type = cardServiceModel.CardType;
            int cost = cardServiceModel.Cost;
            int value = cardServiceModel.Value;
            int offcet = cardServiceModel.Offcet;
            bool isHidden = cardServiceModel.IsHidden;

            CardViewModel cardViewModel = new()
                {
                Id = id,
                Name = name,
                ImageUrl = imageUrl,
                Type = type,
                Cost = cost,
                Value = value,
                Offcet = offcet,
                IsHidden = isHidden,
                };

            return cardViewModel;
            }
        public static AllDeckViewModel GetAllDeck ( AllDecksServiceModel allDecksServiceModel )
            {
            AllDeckViewModel allDeckViewModel = new();
            allDeckViewModel.Decks = GetDecks(allDecksServiceModel.Decks);
            return allDeckViewModel;
            }
        public static List<DeckViewModel> GetDecks ( List<DeckServiceModel> deckServiceModels )
            {
            List<DeckViewModel> deckViewModels = new();
            foreach (DeckServiceModel deckServiceModel in deckServiceModels)
                {
                DeckViewModel deckViewModel = GetDeck(deckServiceModel);
                deckViewModels.Add(deckViewModel);
                }
            return deckViewModels;
            }
        public static DeckViewModel GetDeck ( DeckServiceModel deckServiceModel )
            {
            string id = deckServiceModel.Id;
            string name = deckServiceModel.Name;
            string imageUrl = deckServiceModel.ImageUrl;
            string type = deckServiceModel.Type;
            int cards = deckServiceModel.Cards;

            DeckViewModel deckViewModel = new()
                {
                Id = id,
                Name = name,
                ImageUrl = imageUrl,
                Type = type,
                Cards = cards,
                };
            return deckViewModel;
            }
        public static FullCardViewModel GetFullCard ( FullCardServiceModel fullCardServiceModel )
            {
            string name = fullCardServiceModel.Name;
            string description = fullCardServiceModel.Description;
            string type = fullCardServiceModel.Type;
            int value = fullCardServiceModel.Value;
            int cost = fullCardServiceModel.Cost;
            int duration = fullCardServiceModel.Duration;
            string imageUrl = fullCardServiceModel.ImageUrl;
            string createdOn = fullCardServiceModel.CreatedOn;

            FullCardViewModel fullCardViewModel = new()
                {
                Name = name,
                Description = description,
                Type = type,
                Value = value,
                Cost = cost,
                Duration = duration,
                ImageUrl = imageUrl,
                CreatedOn = createdOn,
                };
            return fullCardViewModel;
            }
        public static FullDeckViewModel GetFullDeck ( FullDeckServiceModel fullDeckServiceModel )
            {
            string name = fullDeckServiceModel.Name;
            string description = fullDeckServiceModel.Description;
            string type = fullDeckServiceModel.Type;
            string createdOn = fullDeckServiceModel.CreatedOn;
            int numberOfCards = fullDeckServiceModel.NumberOfCards;

            FullDeckViewModel fullDeckViewModel = new()
                {
                Name = name,
                Description = description,
                Type = type,
                CreatedOn = createdOn,
                NumberOfCards = numberOfCards,
                };
            return fullDeckViewModel;
            }
        public static AddCardFormModel GetAddCard ( AddCardsServiceModel addCardsServiceModel )
            {
            string name = addCardsServiceModel.Name;
            string description = addCardsServiceModel.Description;
            string imageUrl = addCardsServiceModel.ImageUrl;
            int cardTypeId = addCardsServiceModel.CardTypeId;
            List<CardTypeViewModel> cardTypes = GetCardTypes(addCardsServiceModel.CardTypes);
            int value = addCardsServiceModel.Value;
            int cost = addCardsServiceModel.Cost;

            AddCardFormModel addCardFormModel = new()
                {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                CardTypeId = cardTypeId,
                CardTypes = cardTypes,
                Value = value,
                Cost = cost,
                };
            return addCardFormModel;
            }
        public static AddDeckFormModel GetAddDeckFormModel ( AddDecksServiceModel addDecksServiceModel )
            {
            string name = addDecksServiceModel.Name;
            string description = addDecksServiceModel.Description;
            DeckType deckType = addDecksServiceModel.DeckType;
            List<AddCardsToDeckModel> cards = GetAddCardsToDeck(addDecksServiceModel.Cards);

            AddDeckFormModel addDeckFormModel = new()
                {
                Name = name,
                Description = description,
                DeckType = deckType,
                Cards = cards,
                };
            return addDeckFormModel;
            }
        public static List<AddCardsToDeckModel> GetAddCardsToDeck ( List<AddCardsToDeckServiceModel> addCardsToDeckServiceModels )
            {
            List<AddCardsToDeckModel> addCardsToDeckModels = new();
            foreach (AddCardsToDeckServiceModel addCardsToDeckServiceModel in addCardsToDeckServiceModels)
                {
                AddCardsToDeckModel cardAddedToTheDeckServiceModels = GetAddCardsToDeck(addCardsToDeckServiceModel);
                addCardsToDeckModels.Add(cardAddedToTheDeckServiceModels);
                }
            return addCardsToDeckModels;
            }

        public static AddCardsToDeckModel GetAddCardsToDeck ( AddCardsToDeckServiceModel addCardsToDeckServiceModel )
            {
            AddCardsToDeckModel addCardsToDeckModel = new();
            foreach (CardAddedToTheDeckServiceModel cardAddedToTheDeckServiceModel in addCardsToDeckServiceModel.Cards)
                {
                CardAddedToTheDeckViewModel cardAddedToTheDeckViewModel = GetCardAddedToTheDeck(cardAddedToTheDeckServiceModel);
                addCardsToDeckModel.Cards.Add(cardAddedToTheDeckViewModel);

                }
            return addCardsToDeckModel;
            }

        public static CardAddedToTheDeckViewModel GetCardAddedToTheDeck ( CardAddedToTheDeckServiceModel cardAddedToTheDeckServiceModel )
            {
            string id = cardAddedToTheDeckServiceModel.Id;
            string name = cardAddedToTheDeckServiceModel.Name;
            string imageUrl = cardAddedToTheDeckServiceModel.ImageUrl;
            string type = cardAddedToTheDeckServiceModel.Type;
            int value = cardAddedToTheDeckServiceModel.Value;
            int timesAdded = cardAddedToTheDeckServiceModel.TimesAdded;
            int cost = cardAddedToTheDeckServiceModel.Cost;

            CardAddedToTheDeckViewModel cardAddedToTheDeckViewModel = new()
                {
                Id = id,
                Name = name,
                ImageUrl = imageUrl,
                Type = type,
                Value = value,
                TimesAdded = timesAdded,
                Cost = cost,
                };
            return cardAddedToTheDeckViewModel;
            }
        }
    }
