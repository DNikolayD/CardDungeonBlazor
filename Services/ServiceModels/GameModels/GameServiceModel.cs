namespace Services.ServiceModels.GameModels
    {
    public class GameServiceModel
        {
        public GameServiceModel ()
            {
            this.PlayerModel1 = new PlayerServiceModel();
            this.PlayerModel2 = new PlayerServiceModel();
            }

        public PlayerServiceModel PlayerModel1 { get; set; }

        public PlayerServiceModel PlayerModel2 { get; set; }
        }
    }
