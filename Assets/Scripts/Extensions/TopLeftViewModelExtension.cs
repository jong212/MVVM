using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ViewModel.Extensions
{
    // Extension�� ���� Ŭ�������� ���ο� �޼ҵ带 �߰��ϴ� ��ó�� ����� �� �ִ� ���
    // Extension�� ����Ѵٴ� ���� ���� �� ��ü�� ����ϰڽ��ϴٿ� ����
    // �ϴ��� ����ƽ�̿��� �� 
    // ���� �ν��Ͻ��� �ִ��� 
    // static funcion �̶� �׳� function�� ���̴� ? Ŭ������ 100���� �ν��Ͻ��� 100���ε�  ����ƽ Ŭ������ Ŭ������ 100���� �� �ν��Ͻ��� ����
    // �� �̰� ���� �ڵ尡 ����� ���ĸ� �������� ������ ������ �ν��Ͻ��� �ϳ��̴� ���� ��� ������ ������ ���ؼ��� �̷������ �������� �����ϰ� ���°� �� �ȴ� ����ƽ func�� ������ ������ ���ؼ��� ������ �� 
    // Extension�� �ű��� ���� �긦 ȣ���� �ָ� this�� �Ǵ��� 
    // Extemsion�� ���� ������ �Ķ���Ϳ� �������θ� ������ �ؾ� �Ѵ�.
    public static class TopLeftViewModelExtension
    {

        // ���⼭�� ��û�� �ϰ� ���ӷ��� �Ŵ������� �޾ƿ� ������
        // �� �ٲ���, ���� ������
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            int tempId = 2; //���Ƿ� 2�� �������� �� ���߿� �Ű����� userid �޾ƿͼ� �ᵵ �� 

            // ���Ÿ� ��û�ϰ� ������ �ٽ� �� ����
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
        //�������� �Ϸ� ���� �� ��
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
