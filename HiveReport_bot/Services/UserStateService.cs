using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveReport_bot.Services;

public class UserStateService
{
    private readonly ConcurrentDictionary<long, bool> _userStates = new();

    public bool GetUserState(long chatId)
    {
        return _userStates.GetOrAdd(chatId, false);
    }

    public void SetUserState(long chatId, bool isWaiting)
    {
        _userStates[chatId] = isWaiting;
    }
}
