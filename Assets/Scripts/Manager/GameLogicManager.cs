using System;
using System.Collections.Generic;
// 우리가 강화버튼을 누르면 요청은 가고 게임 로직매니저가 그걸 결국엔 처리하지만 그거에 대한 데이터의 변경과 관여는 모델과 뷰 모델을 통해서 이루어지고 관여 그 자체는 따로 요청 하지는 않는다 알아서.......
// 게임 로직 매니저는 하나여야만 함
// 모델을 수정했을 때 그와 관련된 모든 뷰 모델한테 알려야 한다
// 
public class Player
{
    public Player(int userId, string name)
    {
        UserId = userId;
        Name = name;
        Level = 0;
    }

    public int UserId { get; private set; }
    public string Name { get; private set; }
    public int Level { get; set; }
}

public class GameLogicManager
{
    private static GameLogicManager _instance = null;
    private int _curSelectedPlayerId = 0;

    private static Dictionary<int, Player> _playerDic = new Dictionary<int, Player>();
    private Action<int, int> _levelUpCallback;

    public static GameLogicManager Inst
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameLogicManager();
                TempInitPlayerList();
            }
            return _instance;
        }
    }

    public static void TempInitPlayerList()
    {
        _playerDic.Add(1, new Player(1, "죠스바"));
        _playerDic.Add(2, new Player(2, "쌍쌍바"));
        _playerDic.Add(3, new Player(3, "바밤바"));
    }

    public void RegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback += levelupCallback;
    }

    public void UnRegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback -= levelupCallback;
    }

    public void RequestLevelUp()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }
    public void RequestLevelUpDouble()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level += 2;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RefreshCharacterInfo(int requestId, Action<int, string, int> callback)
    {
        _curSelectedPlayerId = requestId;
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            //아래 callback과 위_levelUpcallback의 차이를 알아두면 좋다고 함
            callback.Invoke(curPlayer.UserId, curPlayer.Name, curPlayer.Level);
        }
    }
}
