using System;
using System.Collections.Generic;
using System.Text;
using BlackjackData.Models;

namespace BlackjackData
{
    public interface IBlackjackData
    {
        IEnumerable<PlayerSessionData> GetAll();
        IEnumerable<PlayerSessionData> GetBySessionId(string sessionId);
        void AddPlayerSessionInformation(PlayerSessionData newPlayerData);
        void UpdatePlayerSessionInformation(PlayerSessionData newPlayerData);
    }
}