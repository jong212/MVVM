using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ViewModel.Extensions
{
    // Extension은 기존 클래스에서 새로운 메소드를 추가하는 것처럼 사용할 수 있는 기능
    // Extension을 사용한다는 것은 나는 이 객체를 사용하겠습니다와 같음
    // 일단은 스태틱이여야 함 
    // 여러 인스턴스가 있더라도 
    // static funcion 이랑 그냥 function의 차이는 ? 클래스가 100개면 인스턴스가 100개인데  스태틱 클래스는 클래스가 100개라도 한 인스턴스만 참조
    // 왜 이거 쓰면 코드가 깔끔해 지냐면 전역변수 같은걸 못쓴다 인스턴스가 하나이다 보니 모든 소통이 리턴을 통해서만 이루어진다 전역변수 난잡하게 쓰는게 안 된다 스태틱 func라서 들어오고 나가고를 통해서만 관리가 됨 
    // Extension이 신기한 점은 얘를 호출한 애를 this로 판담함 
    // Extemsion을 쓰면 뭐든지 파라미터와 리턴으로만 소통을 해야 한다.
    public static class TopLeftViewModelExtension
    {

        // 여기서는 요청을 하고 게임로직 매니저에서 받아온 다음에
        // 야 바꿔줘, 갱신 시켜줘
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            int tempId = 2; //임의로 2번 가져오게 함 나중에 매개변수 userid 받아와서 써도 됨 

            // 갱신만 요청하고 뷰한테 다시 안 보냄
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModal);
        }
        public static void OnRefreshViewModal(this TopLeftViewModel vm, int userId, string name, int level)
        {
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
