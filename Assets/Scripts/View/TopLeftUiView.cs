using UnityEngine.UI;
using UnityEngine;
using System.ComponentModel;
using ViewModel.Extensions;

// ��� ����� ��� �ִ�
public class TopLeftUiView : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;
    [SerializeField] Image Image_Icon;

    TopLeftViewModel _vm;


    // start wake 
    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new TopLeftViewModel();
            // ����� PropertyChanged �̺�Ʈ�� OnPropertyChanged �޼��带 ����մϴ�.
            // OnPropertyChanged �޼��带 �ʱ�ȭ �ܰ迡�� ����ϴ� ������, ���߿� ����� ������Ƽ ���� ����� �� �䰡 �ڵ����� �̸� �����ϰ� UI�� ������Ʈ�� �� �ֵ��� �ϱ� ����.
            _vm.PropertyChanged += OnPropertyChanged;
            
            // �̺�Ʈ ��� > �ݹ��� ������ ���� �ֳĸ� extention���� �׷� ������ �þұ� ���� ��Ͽ�û�� ���� �κе��� �� ���� �ϴ°��� �䰡 ���� ������ �ʰ� ��û����
            _vm.RegisterEventsOnEnable();

            //UI ���µ� �� �� �� ���� �����ּ���
            _vm.RefreshViewModel();
        }
    }
    
    private void OnDisable()
    {
        if (_vm != null)
        {
            _vm.UnRegisterEventsOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
           _vm = null;
        }
    }

    //�߿� ! ���ε��ؼ� ���� �˾Ƽ� �� �� �ֵ��� �ϴ�  �Լ�? �̰� ��� MVVM�� ��� VIEW�� �Ȱ��� ���� �Լ� 
    void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // ������Ƽ ���ӵ鿡 ���� ó���ϰڴ�
        //���ε� �� �ֵ��� ���� ����Ǹ� ��������Ƽ,��ü���� �θ��� ���� �� ����
        switch (e.PropertyName)
        {   
            case nameof(_vm.Name):

                //���� ���� ���ö���¡ �޾Ƽ� ó���ϸ� ������? �ٵ� ���������� �𸣰ڳ�..
                Text_Name.text = _vm.Name;
                break;
            //�信 ���� ����ó���� �信�� ���ش� �̰��� �� ������ �ص� �Ǵ� ó��
            //������ ���� ĳ���� ������ �ٲ�ٸ� ���� �÷��� ó���ϸ� �ǰ���
            //������ �ٲ����� ó���� ���⿡��  ����ǰ� �ȴ� ���ϴ� ..
            // ���� 
            case nameof(_vm.Level):

                Text_Level.text = $"Lv.{_vm.Level}";
                break;
            case nameof(_vm.IconName):
                break;
        }
    }

    // Start is called before the first frame update
}
