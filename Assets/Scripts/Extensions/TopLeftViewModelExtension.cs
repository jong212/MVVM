// Extension �޼���� ���� Ŭ������ ���ο� �޼��带 �߰��ϴ� ��ó�� ����� �� �ִ� ����� �����մϴ�.
// Extension �޼���� �ݵ�� static�̾�� �մϴ�.
// Extension�� ����Ѵٴ� ���� ���� �� ��ü�� ����ϰڴٴ� �ǹ��Դϴ�.
// Extension �޼���� ȣ���� ��ü�� this�� �޾Ƶ��Դϴ�.
// Extension �޼���� �Ķ���Ϳ� ���� �����θ� �����ؾ� �մϴ�.

namespace ViewModel.Extensions
{

    public static class TopLeftViewModelExtension
    {
        // �ʱ�ȭ �� ���� �� (�ʱ�ȭ ���̤��͸� ���� �Ұ��� ���⼭ ���� ����)
        // �� �ٲ���, ���� ������ �� ����
        public static void RefreshViewModel(this TopLeftViewModel vm)
        {
            // �ӽ÷� userId 2���� ���������� ����, �ʿ�� �Ű������� userId�� �޾ƿ� �� ����
            int tempId = 2;

            // GameLogicManager���� ���� ������ ��û�ϰ�, ������ ������ OnRefreshViewModal �ݹ��� �����մϴ�.
            // A-1 : RefreshViewModel �޼���� GameLogicManager�� RefreshCharacterInfo �޼��带 ȣ���Ͽ� ���� ������ ��û�մϴ�.
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModal);
        }



        // RefreshCharacterInfo �޼����� �ݹ����� ����Ǵ� �޼���
        // A-4 : ���޹��� ���� ������ ViewModel�� ������Ƽ�� �����մϴ�.
        public static void OnRefreshViewModal(this TopLeftViewModel vm, int userId, string name, int level)
        {
            //A-5 : �� ��, Name�� Level ������Ƽ�� set �����ڿ��� OnPropertyChanged �޼��尡 ȣ��Ǿ� PropertyChanged �̺�Ʈ�� �߻��մϴ�.
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
        // ViewModel�� Ȱ��ȭ�� �� �̺�Ʈ�� ����մϴ�.

        public static void RegisterEventsOnEnable(this TopLeftViewModel vm)
        {
            // GameLogicManager�� OnResponseLevelUp �Լ��� ������ �ݹ����� ����մϴ�.

            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        }
        public static void UnRegisterEventsOnDisable(this TopLeftViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
        }
        // ������ �̺�Ʈ �ݹ� �޼���
        // ������ ������ ����Ǿ��� �� ViewModel�� ������ ������Ʈ�մϴ�
        // (�Ű����� userId�� level�� ���� ����� ���� ���޹޽��ϴ�)

        public static void OnResponseLevelUp(this TopLeftViewModel vm, int userId, int level)
        {
            // ���� ����� userId�� ���� ViewModel�� userId�� ��ġ���� ������ ��ȯ�մϴ�.
            if (vm.UserId != userId)
            {
                return;
            }
            // ViewModel�� Level ������Ƽ�� ���ο� ���� ������ ������Ʈ�մϴ�.
            vm.Level = level;
        }
    }

}
