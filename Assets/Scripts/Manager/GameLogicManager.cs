using System;
using System.Collections.Generic;
using System.Diagnostics;
// GameLogicManager는 게임 로직을 처리하는 싱글톤 클래스입니다.
// 강화 버튼을 누르면 요청을 받아 처리하지만, 데이터 변경 및 관리는 모델과 뷰모델을 통해 이루어집니다.
// GameLogicManager는 하나만 존재해야 합니다.
// 모델을 수정하면 관련된 모든 뷰모델에게 알려야 합니다.
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

    // 플레이어 정보를 저장하는 딕셔너리
    private static Dictionary<int, Player> _playerDic = new Dictionary<int, Player>();

    // 레벨업 콜백을 저장하는 액션
    private Action<int, int> _levelUpCallback;

    // 싱글톤 인스턴스를 반환합니다.
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

    // 임시로 플레이어 리스트를 초기화합니다.
    public static void TempInitPlayerList()
    {
        _playerDic.Add(1, new Player(1, "죠스바"));
        _playerDic.Add(2, new Player(2, "쌍쌍바"));
        _playerDic.Add(3, new Player(3, "바밤바"));
    }

    // 레벨업 콜백을 등록합니다.
    public void RegisterLevelUpCallback(Action<int, int> levelupCallback)
    {       
        _levelUpCallback += levelupCallback;
    }

    public void UnRegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback -= levelupCallback;
    }

    // 버튼 클릭 시 호출되는 메서드로, 등록된 이벤트들을 실행합니다.
    // 모델(Player)의 데이터를 수정하고 관련된 뷰모델에 알립니다.
    public void RequestLevelUp()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];

            // 모델이 수정되면 관련된 모든 뷰모델에게 알립니다.
            // 이때 _levelUpCallback.Invoke 메서드를 호출하여 구독하고 있는 모든 뷰모델에 변경된 데이터를 전달합니다.
            curPlayer.Level++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    // 버튼 클릭 시 호출되는 메서드로, 등록된 이벤트들을 실행합니다.
    // 모델(Player)의 데이터를 수정하고 관련된 뷰모델에 알립니다.
    public void RequestLevelUpDouble()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];

            // 모델이 수정되면 관련된 모든 뷰모델에게 알립니다.
            // 이때 _levelUpCallback.Invoke 메서드를 호출하여 구독하고 있는 모든 뷰모델에 변경된 데이터를 전달합니다.
            curPlayer.Level += 2;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    // 유저 정보를 갱신합니다.
    // A-2 : RefreshCharacterInfo 메서드는 requestId에 해당하는 유저 정보를 _playerDic 딕셔너리에서 검색합니다.
    public void RefreshCharacterInfo(int requestId, Action<int, string, int> callback)
    {
        _curSelectedPlayerId = requestId;
        // 유저 정보를 찾으면, 
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            //아래 callback과 위_levelUpcallback의 차이를 알아두면 좋다고 함
            // A-3 : 유저 정보를 찾으면, 콜백 함수 vm.OnRefreshViewModal을 호출합니다.
            callback.Invoke(curPlayer.UserId, curPlayer.Name, curPlayer.Level);
        }
    }
}
