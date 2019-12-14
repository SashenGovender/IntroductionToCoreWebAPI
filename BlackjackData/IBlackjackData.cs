using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackData
{
    public interface IBlackjackData
    {
        IEnumerable<PlayerSessionData> GetAll();
        IEnumerable<PlayerSessionData> GetBySessionId(int sessionId);
        void AddPlayerSessionInformation(PlayerSessionData newPlayerData);
        void UpdatePlayerSessionInformation(PlayerSessionData newPlayerData);
    }
}