// Extension 메서드는 기존 클래스에 새로운 메서드를 추가하는 것처럼 사용할 수 있는 기능을 제공합니다.
// Extension 메서드는 반드시 static이어야 합니다.
// Extension을 사용한다는 것은 나는 이 객체를 사용하겠다는 의미입니다.
// Extension 메서드는 호출한 객체를 this로 받아들입니다.
// Extension 메서드는 파라미터와 리턴 값으로만 소통해야 합니다.

namespace ViewModel.Extensions
{

    public static class TopLeftViewModelExtension
    {
        // 초기화 때 실행 됨 (초기화 데이ㅓ터를 뭘로 할건지 여기서 세팅 가능)
        // 야 바꿔줘, 갱신 시켜줘 가 가능
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            // 임시로 userId 2번을 가져오도록 설정, 필요시 매개변수로 userId를 받아올 수 있음
            int tempId = 2;

            // GameLogicManager에게 유저 정보를 요청하고, 정보를 받으면 OnRefreshViewModal 콜백을 실행합니다.
            // A-1 : RefreshViewModel 메서드는 GameLogicManager의 RefreshCharacterInfo 메서드를 호출하여 유저 정보를 요청합니다.
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModal);
        }



        // RefreshCharacterInfo 메서드의 콜백으로 실행되는 메서드
        // A-4 : 전달받은 유저 정보를 ViewModel의 프로퍼티에 설정합니다.
        public static void OnRefreshViewModal(this TopLeftViewModel vm, int userId, string name, int level)
        {
            //A-5 : 이 때, Name과 Level 프로퍼티의 set 접근자에서 OnPropertyChanged 메서드가 호출되어 PropertyChanged 이벤트가 발생합니다.
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }



        /*public static void BindRegiserEventsOnEnable(this TopLeftViewModel vm)
        {
            if (isRegstring)
            {
                GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
            } else
            {
                GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
            }

        }*/
        // ViewModel이 활성화될 때 이벤트를 등록합니다.

        public static void RegisterEventsOnEnable(this TopLeftViewModel vm)
        {
            // GameLogicManager에 OnResponseLevelUp 함수를 레벨업 콜백으로 등록합니다.

            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        }
        public static void UnRegisterEventsOnDisable(this TopLeftViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
        }
        // 레벨업 이벤트 콜백 메서드
        // 유저의 레벨이 변경되었을 때 ViewModel의 레벨을 업데이트합니다
        // (매개변수 userId와 level을 통해 변경된 값을 전달받습니다)

        public static void OnResponseLevelUp(this TopLeftViewModel vm, int userId, int level)
        {
            // 만약 변경된 userId가 현재 ViewModel의 userId와 일치하지 않으면 반환합니다.
            if (vm.UserId != userId)
            {
                return;
            }
            // ViewModel의 Level 프로퍼티를 새로운 레벨 값으로 업데이트합니다.
            vm.Level = level;
        }
    }

}
