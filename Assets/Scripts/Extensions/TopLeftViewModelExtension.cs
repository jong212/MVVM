// Extension�� ���� Ŭ�������� ���ο� �޼ҵ带 �߰��ϴ� ��ó�� ����� �� �ִ� ���
// Extension�� ����ƽ�̿��� �� 

// Extension�� ����Ѵٴ� ���� ���� �� ��ü�� ����ϰڽ��ϴٿ� ����
// Extension�� �ű��� ���� �긦 ȣ���� �ָ� this�� �Ǵ��� 

// Extension �� ���� ������ �Ķ���Ϳ� �������θ� �����ؾ���
namespace ViewModel.Extensions
{

    public static class TopLeftViewModelExtension
    {
        // �ʱ�ȭ �� ���� �� 
        // �� �ٲ���, ���� ������ �� ����
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            //���Ƿ� 2�� �������� �� ���߿� �Ű����� userid �޾ƿͼ� �ᵵ �� 
            int tempId = 2;

            // ���ӷ��� �Ŵ������� ���� ���� ��û > �������� ������ OnRefreshViewModal �ݹ� ���� (�Ʒ� �ּ� ������ �� �� �������ϰ� Ǯ�� ��)
            // A-1 : RefreshViewModel �޼���� GameLogicManager�� RefreshCharacterInfo �޼��带 ȣ���Ͽ� ���� ������ ��û�մϴ�.
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModal);
        }



        // �ݹ� �Լ��� ���޵� OnRefreshViewModal �޼��尡 ����˴ϴ�
        // A-4 : OnRefreshViewModal �޼���� ���޹��� ���� ������ ����� ������Ƽ�� �����մϴ�.
        public static void OnRefreshViewModal(this TopLeftViewModel vm, int userId, string name, int level)
        {
            //A-5 :  �̶�, Name�� Level ������Ƽ�� set �����ڿ��� OnPropertyChanged �޼��尡 ȣ��Ǿ� PropertyChanged �̺�Ʈ�� �߻���ŵ�ϴ�.
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
            //���ӷ����� �ִ� �̺�Ʈ�� OnResponseLevelUp �Լ��� ��� �س��� ����.

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
