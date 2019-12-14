using System;
using System.Collections.Generic;
using System.Linq;
using BlackjackData;
using BlackjackData.Models;

//Any interactions with the database
namespace DatabaseServices
{
    public class BlackjackDataService : IBlackjackData
    {
        private readonly PlayerContext _playerContext;

        public BlackjackDataService(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        public IEnumerable<PlayerSessionData> GetAll()
        {
            return _playerContext.PlayerSessionInformation;
        }

        public IEnumerable<PlayerSessionData> GetBySessionId(string sessionId)
        {
            return _playerContext.PlayerSessionInformation.Where(pInfo => pInfo.SessionId == sessionId);
        }

        public void AddPlayerSessionInformation(PlayerSessionData newPlayerData)
        {
            _playerContext.Add(newPlayerData);
            _playerContext.SaveChanges();
        }

        public void UpdatePlayerSessionInformation(PlayerSessionData newPlayerData)
        {
            var entity = _playerContext.PlayerSessionInformation.FirstOrDefault(pInfo => pInfo.SessionId == newPlayerData.SessionId && pInfo.PlayerId==newPlayerData.PlayerId);

            if (entity != null)
            {
                // Make changes on entity
                entity.Score = newPlayerData.Score;
                entity.PlayerCards = newPlayerData.PlayerCards;

                // Update entity in DbSet
                _playerContext.PlayerSessionInformation.Update(entity);

                // Save changes in database
                _playerContext.SaveChanges();
            }
        }
    }
}
