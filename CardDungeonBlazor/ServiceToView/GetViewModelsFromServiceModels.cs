using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.Models;
using Services.ServiceModels.CardsModels;
using Services.ServiceModels.ForumsModels;
using Services.ServiceModels.GameModels;
namespace CardDungeonBlazor.ServiceToView
    {
    public class GetViewModelsFromServiceModels
        {
        public List<CardTypeViewModel> GetCardTypeViewModels ( List<CardTypeServiceModel> serviceModels )
            {
            List<CardTypeViewModel> viewModels = new();
            foreach (CardTypeServiceModel serviceModel in serviceModels)
                {
                CardTypeViewModel viewModel = this.GetCardTypeViewModel(serviceModel);
                viewModels.Add(viewModel);
                }
            return viewModels;
            }
        public CardTypeViewModel GetCardTypeViewModel ( CardTypeServiceModel cardTypeServiceModel )
            {
            CardTypeViewModel viewModel = new()
                {
                Id = cardTypeServiceModel.Id,
                Name = cardTypeServiceModel.Name,
                };
            return viewModel;
            }
        public List<CardTypeServiceModel> GetCardTypeServiceModels ( List<CardTypeViewModel> cardTypeViewModels )
            {
            List<CardTypeServiceModel> cardTypeServiceModels = new();
            foreach (CardTypeViewModel cardTypeViewModel in cardTypeViewModels)
                {
                CardTypeServiceModel serviceModel = this.GetCardTypeServiceModel(cardTypeViewModel);
                cardTypeServiceModels.Add(serviceModel);
                }
            return cardTypeServiceModels;
            }
        public CardTypeServiceModel GetCardTypeServiceModel ( CardTypeViewModel cardTypeViewModel )
            {
            CardTypeServiceModel serviceModel = new()
                {
                Id = cardTypeViewModel.Id,
                Name = cardTypeViewModel.Name,
                };
            return serviceModel;
            }
        public AddCardsServiceModel GetAddCardsServiceModel ( AddCardFormModel formModel )
            {
            AddCardsServiceModel serviceModel = new()
                {
                CardTypeId = formModel.CardTypeId,
                CardTypes = this.GetCardTypeServiceModels(formModel.CardTypes),
                Cost = formModel.Cost,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Name = formModel.Name,
                Value = formModel.Value,
                };
            return serviceModel;
            }
        public AddDecksServiceModel GetAddDecksServiceModel ( AddDeckFormModel addDeckFormModel )
            {
            AddDecksServiceModel serviceModel = new()
                {
                Cards = this.GetAddCardsToDeckServiceModels(addDeckFormModel.Cards),
                DeckType = addDeckFormModel.DeckType,
                Description = addDeckFormModel.Description,
                Name = addDeckFormModel.Name,
                };
            return serviceModel;
            }
        public List<AddCardsToDeckServiceModel> GetAddCardsToDeckServiceModels ( List<AddCardsToDeckModel> addCardsToDeckModels )
            {
            List<AddCardsToDeckServiceModel> addCardsToDeckServiceModels = new();
            foreach (AddCardsToDeckModel addCardsToDeckModel in addCardsToDeckModels)
                {
                AddCardsToDeckServiceModel addCardsServiceModel = this.GetAddCardsToDeckServiceModel(addCardsToDeckModel);
                addCardsToDeckServiceModels.Add(addCardsServiceModel);
                }
            return addCardsToDeckServiceModels;
            }
        public AddCardsToDeckServiceModel GetAddCardsToDeckServiceModel ( AddCardsToDeckModel addCardsToDeckModel )
            {
            AddCardsToDeckServiceModel addCardsToDeckServiceModel = new()
                {
                Cards = this.GetCardAddedToTheDeckServiceModels(addCardsToDeckModel.Cards)
                };
            return addCardsToDeckServiceModel;
            }
        public List<CardAddedToTheDeckServiceModel> GetCardAddedToTheDeckServiceModels ( List<CardAddedToTheDeckViewModel> cardAddedToTheDeckViewModels )
            {
            List<CardAddedToTheDeckServiceModel> cardAddedToTheDeckServiceModels = new();
            foreach (CardAddedToTheDeckViewModel cardAddedToTheDeckViewModel in cardAddedToTheDeckViewModels)
                {
                CardAddedToTheDeckServiceModel cardAddedToTheDeckServiceModel = new()
                    {
                    Type = cardAddedToTheDeckViewModel.Type,
                    Cost = cardAddedToTheDeckViewModel.Cost,
                    Id = cardAddedToTheDeckViewModel.Id,
                    ImageUrl = cardAddedToTheDeckViewModel.ImageUrl,
                    Name = cardAddedToTheDeckViewModel.Name,
                    TimesAdded = cardAddedToTheDeckViewModel.TimesAdded,
                    Value = cardAddedToTheDeckViewModel.Value,
                    };
                cardAddedToTheDeckServiceModels.Add(cardAddedToTheDeckServiceModel);
                }
            return cardAddedToTheDeckServiceModels;
            }
        public AllCardsViewModel GetAllCardsViewModel ( AllCardsServiceModel allCardsServiceModel )
            {
            AllCardsViewModel allCardsViewModel = new()
                {
                Cards = this.GetCardViewModels(allCardsServiceModel.Cards)
                };
            return allCardsViewModel;
            }
        public List<CardViewModel> GetCardViewModels ( List<CardServiceModel> cardServiceModels )
            {
            List<CardViewModel> cardViewModels = new();
            foreach (CardServiceModel cardServiceModel in cardServiceModels)
                {
                CardViewModel cardViewModel = this.GetCardViewModel(cardServiceModel);
                cardViewModels.Add(cardViewModel);
                }
            return cardViewModels;
            }
        public CardViewModel GetCardViewModel ( CardServiceModel cardServiceModel )
            {
            CardViewModel cardViewModel = new()
                {
                Type = cardServiceModel.CardType,
                Cost = cardServiceModel.Cost,
                Id = cardServiceModel.Id,
                ImageUrl = cardServiceModel.ImageUrl,
                Name = cardServiceModel.Name,
                Offcet = cardServiceModel.Offcet,
                Value = cardServiceModel.Value,
                };
            return cardViewModel;
            }
        public AllDeckViewModel GetAllDeckViewModel ( AllDecksServiceModel allDecksServiceModel )
            {
            AllDeckViewModel allDeckViewModel = new();
            allDeckViewModel.Decks = this.GetDeckViewModels(allDecksServiceModel.Decks);
            return allDeckViewModel;
            }
        public List<DeckViewModel> GetDeckViewModels ( List<DeckServiceModel> deckServiceModels )
            {
            List<DeckViewModel> deckViewModels = new();
            foreach (DeckServiceModel deckServiceModel in deckServiceModels)
                {
                DeckViewModel deckViewModel = this.GetDeckViewModel(deckServiceModel);
                deckViewModels.Add(deckViewModel);
                }
            return deckViewModels;
            }
        public DeckViewModel GetDeckViewModel ( DeckServiceModel deckServiceModel )
            {
            DeckViewModel deckViewModel = new()
                {
                Cards = deckServiceModel.Cards,
                Id = deckServiceModel.Id,
                ImageUrl = deckServiceModel.ImageUrl,
                Name = deckServiceModel.Name,
                Type = deckServiceModel.Type,
                };
            return deckViewModel;
            }
        public FullCardViewModel GetFullCardViewModel ( FullCardServiceModel fullCardServiceModel )
            {
            FullCardViewModel fullCardViewModel = new()
                {
                Type = fullCardServiceModel.Type,
                Cost = fullCardServiceModel.Cost,
                CreatedOn = fullCardServiceModel.CreatedOn,
                Description = fullCardServiceModel.Description,
                Duration = fullCardServiceModel.Duration,
                ImageUrl = fullCardServiceModel.ImageUrl,
                Name = fullCardServiceModel.Name,
                Value = fullCardServiceModel.Value,
                };
            return fullCardViewModel;
            }
        public FullDeckViewModel GetFullDeckViewModel ( FullDeckServiceModel fullDeckServiceModel )
            {
            FullDeckViewModel fullDeckViewModel = new()
                {
                CreatedOn = fullDeckServiceModel.CreatedOn,
                Description = fullDeckServiceModel.Description,
                Name = fullDeckServiceModel.Name,
                NumberOfCards = fullDeckServiceModel.NumberOfCards,
                Type = fullDeckServiceModel.Type,
                };
            return fullDeckViewModel;
            }
        public AddCardFormModel GetAddCardFormModel ( AddCardsServiceModel addCardsServiceModel )
            {
            AddCardFormModel addCardFormModel = new()
                {
                CardTypeId = addCardsServiceModel.CardTypeId,
                CardTypes = this.GetCardTypeViewModels(addCardsServiceModel.CardTypes),
                Cost = addCardsServiceModel.Cost,
                Description = addCardsServiceModel.Description,
                ImageUrl = addCardsServiceModel.ImageUrl,
                Name = addCardsServiceModel.Name,
                Value = addCardsServiceModel.Value,
                };
            return addCardFormModel;
            }
        public AddDeckFormModel GetAddDeckFormModel ( AddDecksServiceModel addDecksServiceModel )
            {
            AddDeckFormModel addDeckFormModel = new()
                {
                Cards = this.GetAddCardsToDeckModels(addDecksServiceModel.Cards),
                DeckType = addDecksServiceModel.DeckType,
                Description = addDecksServiceModel.Description,
                Name = addDecksServiceModel.Name,
                };
            return addDeckFormModel;
            }
        public List<AddCardsToDeckModel> GetAddCardsToDeckModels ( List<AddCardsToDeckServiceModel> addCardsToDeckServiceModels )
            {
            List<AddCardsToDeckModel> addCardsToDeckModels = new();
            foreach (AddCardsToDeckServiceModel addCardsToDeckServiceModel in addCardsToDeckServiceModels)
                {
                AddCardsToDeckModel cardAddedToTheDeckServiceModels = this.GetAddCardsToDeckModel(addCardsToDeckServiceModel);
                addCardsToDeckModels.Add(cardAddedToTheDeckServiceModels);
                }
            return addCardsToDeckModels;
            }

        public AddCardsToDeckModel GetAddCardsToDeckModel ( AddCardsToDeckServiceModel addCardsToDeckServiceModel )
            {
            AddCardsToDeckModel addCardsToDeckModel = new();
            foreach (CardAddedToTheDeckServiceModel cardAddedToTheDeckServiceModel in addCardsToDeckServiceModel.Cards)
                {
                CardAddedToTheDeckViewModel cardAddedToTheDeckViewModel = this.GetCardAddedToTheDeckViewModel(cardAddedToTheDeckServiceModel);
                addCardsToDeckModel.Cards.Add(cardAddedToTheDeckViewModel);

                }
            return addCardsToDeckModel;
            }

        public CardAddedToTheDeckViewModel GetCardAddedToTheDeckViewModel ( CardAddedToTheDeckServiceModel cardAddedToTheDeckServiceModel )
            {
            CardAddedToTheDeckViewModel cardAddedToTheDeckViewModel = new()
                {
                Type = cardAddedToTheDeckServiceModel.Type,
                Cost = cardAddedToTheDeckServiceModel.Cost,
                Id = cardAddedToTheDeckServiceModel.Id,
                ImageUrl = cardAddedToTheDeckServiceModel.ImageUrl,
                Name = cardAddedToTheDeckServiceModel.Name,
                TimesAdded = cardAddedToTheDeckServiceModel.TimesAdded,
                Value = cardAddedToTheDeckServiceModel.Value,
                };
            return cardAddedToTheDeckViewModel;
            }
        public AddPostServiceModel GetAddPostServiceModel ( AddPostFormModel addPostServiceModel )
            {
            AddPostServiceModel addPostFormModel = new()
                {
                CategoryId = addPostServiceModel.CategoryId,
                Image = addPostServiceModel.Image,
                Likes = addPostServiceModel.Likes,
                TextContent = addPostServiceModel.TextContent,
                Title = addPostServiceModel.Title,
                UserId = addPostServiceModel.UserId,
                };
            return addPostFormModel;
            }
        public AllCategoriesViewModel GetAllCategoriesViewModel ( AllCategoriesServiceModel allCategoriesServiceModel )
            {
            AllCategoriesViewModel allCategoriesViewModel = new();
            allCategoriesViewModel.Categories = this.GetCategoryViewModels(allCategoriesServiceModel.Categories);
            return allCategoriesViewModel;
            }
        public List<CategoryViewModel> GetCategoryViewModels ( List<CategoryServiceModel> categoryServiceModels )
            {
            List<CategoryViewModel> categoryViewModels = new();
            foreach (CategoryServiceModel categoryServiceModel in categoryServiceModels)
                {
                CategoryViewModel categoryViewModel = this.GetCategoryViewModel(categoryServiceModel);
                categoryViewModels.Add(categoryViewModel);
                }
            return categoryViewModels;
            }
        public CategoryViewModel GetCategoryViewModel ( CategoryServiceModel categoryServiceModel )
            {
            CategoryViewModel categoryViewModel = new()
                {
                Description = categoryServiceModel.Description,
                Id = categoryServiceModel.Id,
                Name = categoryServiceModel.Name,
                PostsCount = categoryServiceModel.PostsCount,
                };
            return categoryViewModel;
            }
        public AllPostsViewModel GetAllPostsViewModel ( AllPostsServiceModel allPostsServiceModel )
            {
            AllPostsViewModel allPostsViewModel = new();
            allPostsViewModel.Posts = this.GetPostViewModels(allPostsServiceModel.Posts);
            return allPostsViewModel;
            }

        public List<PostViewModel> GetPostViewModels ( List<PostServiceModel> postServiceModels )
            {
            List<PostViewModel> postViewModels = new();
            foreach (PostServiceModel postServiceModel in postServiceModels)
                {
                PostViewModel postViewModel = this.GetPostViewModel(postServiceModel);
                postViewModels.Add(postViewModel);
                }
            return postViewModels;
            }

        public PostViewModel GetPostViewModel ( PostServiceModel postServiceModel )
            {
            PostViewModel postViewModel = new()
                {
                Id = postServiceModel.Id,
                Likes = postServiceModel.Likes,
                Title = postServiceModel.Title,
                };
            return postViewModel;
            }
        public AddCategoryFormModel GetAddCategoryFormModel ( AddCategoryServiceModel addCategoryServiceModel )
            {
            AddCategoryFormModel addCategoryFormModel = new()
                {
                Description = addCategoryServiceModel.Description,
                Name = addCategoryServiceModel.Name,
                };
            return addCategoryFormModel;
            }
        public AddCategoryServiceModel GetAddCategoryServiceModel ( AddCategoryFormModel addCategoryFormModel )
            {
            AddCategoryServiceModel addCategoryServiceModel = new()
                {
                Description = addCategoryFormModel.Description,
                Name = addCategoryFormModel.Name,
                };
            return addCategoryServiceModel;
            }
        public AddPostFormModel GetAddPostFormModel ( AddPostServiceModel addPostServiceModel )
            {
            AddPostFormModel addPostFormModel = new()
                {
                CategoryId = addPostServiceModel.CategoryId,
                Image = addPostServiceModel.Image,
                Likes = addPostServiceModel.Likes,
                TextContent = addPostServiceModel.TextContent,
                Title = addPostServiceModel.Title,
                UserId = addPostServiceModel.UserId,
                };
            return addPostFormModel;
            }
        public FullPostViewModel GetFullPostViewModel ( FullPostServiceModel fullPostServiceModel )
            {
            FullPostViewModel fullPostViewModel = new()
                {
                Comments = this.GetCommentViewModels(fullPostServiceModel.Comments),
                CreatedOn = fullPostServiceModel.CreatedOn,
                Username = fullPostServiceModel.Username,
                Image = fullPostServiceModel.Image,
                Likes = fullPostServiceModel.Likes,
                Text = fullPostServiceModel.Text,
                Title = fullPostServiceModel.Title,
                };
            return fullPostViewModel;
            }
        public List<CommentViewModel> GetCommentViewModels ( List<CommentServiceModel> commentServiceModels )
            {
            List<CommentViewModel> commentViewModels = new();
            foreach (CommentServiceModel commentServiceModel in commentServiceModels)
                {
                CommentViewModel commentViewModel = this.GetCommentViewModel(commentServiceModel);
                commentViewModels.Add(commentViewModel);
                }
            return commentViewModels;
            }
        public CommentViewModel GetCommentViewModel ( CommentServiceModel commentServiceModel )
            {
            CommentViewModel commentViewModel = new()
                {
                CreatedOn = commentServiceModel.CreatedOn,
                Image = commentServiceModel.Image,
                Likes = commentServiceModel.Likes,
                Text = commentServiceModel.Text,
                Username = commentServiceModel.Username,
                };
            return commentViewModel;
            }
        public CommentServiceModel GetCommentServiceModel ( CommentViewModel commentViewModel )
            {
            CommentServiceModel commentServiceModel = new()
                {
                CreatedOn = commentViewModel.CreatedOn,
                Image = commentViewModel.Image,
                Likes = commentViewModel.Likes,
                Text = commentViewModel.Text,
                Username = commentViewModel.Username,
                };
            return commentServiceModel;
            }
        public DecksViewModel GetDecksViewModel ( DecksServiceModel decksServiceModel )
            {
            DecksViewModel decksViewModel = new()
                {
                Cards = this.GetCardViewModels(decksServiceModel.Cards),
                };
            return decksViewModel;
            }
        public GameServiceModel GetGameServiceModel ( GameViewModel gameViewModel )
            {
            GameServiceModel gameServiceModel = new()
                {
                PlayerModel1 = this.GetPlayerServiceModel(gameViewModel.PlayerModel1),
                PlayerModel2 = this.GetPlayerServiceModel(gameViewModel.PlayerModel2),
                };
            return gameServiceModel;
            }
        public PlayerServiceModel GetPlayerServiceModel ( PlayerViewModel playerViewModel )
            {
            PlayerServiceModel playerServiceModel = new()
                {
                CardsInHeand = this.GetCardServiceModels(playerViewModel.CardsInHeand),
                Deck = this.GetDecksServiceModel(playerViewModel.Deck),
                Deffence = playerViewModel.Deffence,
                Energy = playerViewModel.Energy,
                Health = playerViewModel.Health,
                IsPoisoned = playerViewModel.IsPoisoned,
                Name = playerViewModel.Name,
                };
            return playerServiceModel;
            }
        public List<CardServiceModel> GetCardServiceModels ( List<CardViewModel> cardViewModels )
            {
            List<CardServiceModel> cardServiceModels = new();
            foreach (CardViewModel cardViewModel in cardViewModels)
                {
                CardServiceModel cardServiceModel = this.GetCardServiceModel(cardViewModel);
                cardServiceModels.Add(cardServiceModel);
                }
            return cardServiceModels;
            }
        public CardServiceModel GetCardServiceModel ( CardViewModel cardViewModel )
            {
            CardServiceModel cardServiceModel = new()
                {
                CardType = cardViewModel.Type,
                Cost = cardViewModel.Cost,
                Id = cardViewModel.Id,
                ImageUrl = cardViewModel.ImageUrl,
                Name = cardViewModel.Name,
                Offcet = cardViewModel.Offcet,
                Value = cardViewModel.Value,
                };
            return cardServiceModel;
            }
        public DecksServiceModel GetDecksServiceModel ( DecksViewModel decksViewModel )
            {
            DecksServiceModel decksServiceModel = new()
                {
                Cards = this.GetCardServiceModels(decksViewModel.Cards),
                };
            return decksServiceModel;
            }
        public GameViewModel GetGameViewModel ( GameServiceModel gameServiceModel )
            {
            GameViewModel gameViewModel = new()
                {
                PlayerModel1 = this.GetPlayerViewModel(gameServiceModel.PlayerModel1),
                PlayerModel2 = this.GetPlayerViewModel(gameServiceModel.PlayerModel2),
                };
            return gameViewModel;
            }
        public PlayerViewModel GetPlayerViewModel ( PlayerServiceModel playerServiceModel )
            {
            PlayerViewModel playerViewModel = new()
                {
                CardsInHeand = this.GetCardViewModels(playerServiceModel.CardsInHeand),
                Deck = this.GetDecksViewModel(playerServiceModel.Deck),
                Deffence = playerServiceModel.Deffence,
                Energy = playerServiceModel.Energy,
                Health = playerServiceModel.Health,
                IsPoisoned = playerServiceModel.IsPoisoned,
                Name = playerServiceModel.Name,
                };
            return playerViewModel;
            }
        }
    }
