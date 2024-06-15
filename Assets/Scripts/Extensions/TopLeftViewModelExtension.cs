// Extension은 기존 클래스에서 새로운 메소드를 추가하는 것처럼 사용할 수 있는 기능
// Extension은 스태틱이여야 함 

// Extension을 사용한다는 것은 나는 이 객체를 사용하겠습니다와 같음
// Extension이 신기한 점은 얘를 호출한 애를 this로 판담함 

// Extension 을 쓰면 뭐든지 파라미터와 리턴으로만 소통해야함
namespace ViewModel.Extensions
{

    public static class TopLeftViewModelExtension
    {
        // 초기화 때 실행 됨 
        // 야 바꿔줘, 갱신 시켜줘 가 가능
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            //임의로 2번 가져오게 함 나중에 매개변수 userid 받아와서 써도 됨 
            int tempId = 2;

            // 게임로직 매니저에게 유저 정보 요청 > 유저정보 있으면 OnRefreshViewModal 콜백 실행 (아래 주석 내용은 좀 더 디테일하게 풀어 씀)
            // A-1 : RefreshViewModel 메서드는 GameLogicManager의 RefreshCharacterInfo 메서드를 호출하여 유저 정보를 요청합니다.
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModal);
        }



        // 콜백 함수로 전달된 OnRefreshViewModal 메서드가 실행됩니다
        // A-4 : OnRefreshViewModal 메서드는 전달받은 유저 정보를 뷰모델의 프로퍼티에 설정합니다.
        public static void OnRefreshViewModal(this TopLeftViewModel vm, int userId, string name, int level)
        {
            //A-5 :  이때, Name과 Level 프로퍼티의 set 접근자에서 OnPropertyChanged 메서드가 호출되어 PropertyChanged 이벤트를 발생시킵니다.
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
        public static void RegisterEventsOnEnable(this TopLeftViewModel vm)
        {
            //게임로직에 있는 이벤트에 OnResponseLevelUp 함수를 등록 해놓는 것임.

            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        }
        public static void UnRegisterEventsOnDisable(this TopLeftViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
        }
        //레벨업이 완료 됐을 때 옴
        public static void OnResponseLevelUp(this TopLeftViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId)
            {
                return;
            }

            vm.Level = level;
        }
    }

}
