using System.Collections.Generic;

using GMTB.AI;

namespace GMTB
{
    public class AiManager
    {
        #region Data Members
        private static AiManager Instance = null;
        private List<IAI> AllAIs;
        private IPlayer Player;
        #endregion

        #region Constructor
        private AiManager()
        {
            List<IEntity> Entities = EntityManager.getInstance.Entities;
            AllAIs = new List<IAI>();
            for (int i = 0; i < Entities.Count; i++)
            {
                var asInterface = Entities[i] as IAI;
                if (asInterface != null)
                {
                    AllAIs.Add(asInterface);
                }
                if (Entities[i].UName == "Player")
                {
                    Player = Entities[i] as IPlayer;
                }
            }
        }
        public static AiManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new AiManager();
                return Instance;
            }
        }
        #endregion

        #region Methods
        public void Initialise()
        {
            
        }
        public void Update()
        {
            for (int i = 0; i < AllAIs.Count; i++)
            {
                AllAIs[i].PlayerPos = Player.Position;
                AllAIs[i].PlayerVisible = Player.Visible;
            }
        }
        #endregion
    }
}
