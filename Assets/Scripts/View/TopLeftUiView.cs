using UnityEngine.UI;
using UnityEngine;
using System.ComponentModel;
using ViewModel.Extensions;

/* 
 * # View
   [�ٽ�] 
   1. ������ ���ε��� �̸� �س��� �Ѵ�!
   2. ����� ��� ���� !
   [����]
   1. ��� �����͸� ���������� �������� �ʵ��� �����Ѵ�. 
   2. ������(������Ƽ) "��" �� ����Ǵ� "��(��ũ��Ʈ)"�� ViewModel���� �̷�� ���� (�����Ϳ� ������ �и�)
   3. Viwe�� ViewModel�� ����
     ��) �̺�Ʈ �߻�: ViewModel�� ������Ƽ "��"�� ����Ǹ� �ټ��� �¿��� OnPropertyChanged �޼��带 ȣ�� > PropertyChanged �̺�Ʈ �߻�.
     ��) �̺�Ʈ ����: View�� ViewModel�� PropertyChanged �̺�Ʈ�� �����ϰ� �ֱ� ������ ViewModel�� ������ ������ ������ �� �ִ�.
     ��) �̺�Ʈ �ڵ鷯 ȣ��: ���� �Ǹ� View�� �̺�Ʈ �ڵ鷯(OnPropertyChangeds)�� ȣ�� ��
     ��) UI ������Ʈ: View�� �̺�Ʈ �ڵ鷯�� ����� ���� ViewModel���� �����ͼ� UI�� ������Ʈ�մϴ�. �� �������� View�� ViewModel�� ������Ƽ�� �����Ͽ� �ֽ� �����͸� ��������, �̸� ������� UI ��Ҹ� �����Ѵ�.
   4.ViewModel�� ������Ƽ �� ����� OnPropertyChanged ȣ���� ���� PropertyChanged �̺�Ʈ�� �߻��ϰ�, View�� �� �̺�Ʈ�� �����Ͽ� UI�� ������Ʈ�ϴ� ������ ������ ���ε��̶�� �Ѵ�.
 */


public class TopLeftUiView : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;
    [SerializeField] Image Image_Icon;

    TopLeftViewModel _vm;

    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new TopLeftViewModel();

            // �ʱ�ȭ �ܰ迡�� ViewModel�� PropertyChanged �̺�Ʈ�� View�� OnPropertyChanged �޼��带 ���
            // �� �ܰ迡�� �̸� ����صθ�, ���߿� ViewModel�� ������Ƽ ���� ����� �� PropertyChanged �̺�Ʈ�� �߻��ϰ�,
            // View�� OnPropertyChanged �޼��尡 ȣ��Ǿ� UI�� �ڵ����� ������Ʈ�� �� ����!
            _vm.PropertyChanged += OnPropertyChangeds;

            // �̺�Ʈ ���: ViewModel���� �̺�Ʈ�� ó���ϴ� Ȯ�� �޼���(extension)�� ����
            // View�� ���� �̺�Ʈ ��ϸ� �صΰ�, ��ü���� �̺�Ʈ ó���� ViewModel�� �� Ȯ�� �޼��尡 ���(�䰡 ���������� �����͸� �����ϰų� �̺�Ʈ�� ó������ �ʰ�, �ʿ��� ������ ��û�� ������ ���´ٴ� �ǹ�.)
            _vm.RegisterEventsOnEnable();

            // A-0 : UI ���µ� �� �� �� ViewModel�� �����͸� �����Ͽ� �ֽ� ���·� ������Ʈ
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

    // �� OnPropertyChangeds �Լ��� ȣ��ȴٴ� ���� ViewModel�� ������Ƽ ���� �����Ǿ��ٴ� ��
    // A-7 : TopLeftUiView�� OnPropertyChangeds �޼��尡 ȣ��˴ϴ�.
    void OnPropertyChangeds(object sender, PropertyChangedEventArgs e)
    {
        // PropertyChanged �̺�Ʈ���� ���޵� PropertyName�� ���� UI ��Ҹ� ������Ʈ�մϴ�.
        // ��𵨿��� ���ε� �� ������Ƽ ���� ����Ǹ� OnPropertyChanged �޼��尡 ȣ��Ǿ� PropertyChanged �̺�Ʈ�� �߻��ϰ�,
        // �� �̺�Ʈ�� ������ OnPropertyChangeds �޼��尡 ȣ��˴ϴ�.
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                // Name ������Ƽ�� ����Ǹ� �ش� ���� UI�� Text_Name�� �ݿ��մϴ�.
                Text_Name.text = _vm.Name;
                break;

            case nameof(_vm.Level):
                // Level ������Ƽ�� ����Ǹ� �ش� ���� UI�� Text_Level�� �ݿ��մϴ�.
                Text_Level.text = $"Lv.{_vm.Level}";
                break;

            case nameof(_vm.IconName):
                // IconName ������Ƽ�� ����Ǹ� �������� ������Ʈ�ϴ� ������ �߰��� �� �ֽ��ϴ�.
                // ��: Image_Icon.sprite = ...;
                break;
        }
    }

    // Start is called before the first frame update
}
