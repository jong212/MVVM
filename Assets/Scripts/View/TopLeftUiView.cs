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


    /*�ʱ�ȭ > �̺�Ʈ ��� > */
    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new TopLeftViewModel();
          
            // �ʱ�ȭ �ܰ迡�� �̸� ����� �س��� �̵��� RefeshViewModel ����ɶ� �̸��� ������Ʈ �� �� ����
            // ����� PropertyChanged �̺�Ʈ�� OnPropertyChanged �޼��带 �̸� ����ϴ� ����
            // OnPropertyChanged �޼��带 �ʱ�ȭ �ܰ迡�� ����ϴ� ������, ���߿� ����� ������Ƽ ���� ����� �� �䰡 �ڵ����� �̸� �����ϰ�(PropertyChanged �̺�Ʈ invoke ��ų ��) OnPropertyChanged �Լ��� ����ǰ� �ؼ� UI�� ������Ʈ�� �� �ֵ��� �ϱ� ����.
            _vm.PropertyChanged += OnPropertyChangeds;
            
            // �̺�Ʈ ��� > �ݹ��� ������ ���� �ֳĸ� Ȯ��޼����� "extention" ���� ������ �þұ� �����̸� ��Ͽ�û�� ���� �κе��� �� ��(extension����)�� �ϴ°��� �䰡 ���� ������ �ʰ� ��û����            
            _vm.RegisterEventsOnEnable();

            // A-0 : UI ���µ� �� �� �� ���� �����ּ���
            _vm.RefreshViewModel();
        }
    }
    
    private void OnDisable()
    {
        if (_vm != null)
        {
            _vm.UnRegisterEventsOnDisable();
            _vm.PropertyChanged -= OnPropertyChangeds;
           _vm = null;
        }
    }

    // �߿� ! ���ε��ؼ� ���� �˾Ƽ� �� �� �ֵ��� �ϴ�  �Լ�? �̰� ��� MVVM�� ��� VIEW�� �Ȱ��� ���� �Լ�
    // A-7 : TopLeftUiView�� OnPropertyChanged �޼��尡 ȣ��˴ϴ�.
    void OnPropertyChangeds(object sender, PropertyChangedEventArgs e)
    {
        // ������Ƽ ���ӵ鿡 ���� ó���ϰڴ�
        // ���ε� �� �ֵ��� ���� ����Ǹ� ��������Ƽ,��ü���� �θ��� ���� �� ����
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
