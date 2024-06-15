
// ����� �����͸� �����ͼ� ������ ���ִ� ���Ҹ� ��(������ ���ε� ���Ҹ� ��)

using System.ComponentModel;
using ViewModel;

public class TopLeftViewModel : ViewModelBase
{
    //userid�� �ĺ����̶� view�� ���� �� �� �׷��� onpropchanged�� �ʿ� ���� �׳� ������Ƽ �����θ� ��� �� 
    private int _userId;
    private string _name;
    private int _level;
    private string _iconName;

    public int UserId
    {
        get { return _userId; }
        set
        {
            _userId = value;
        }
    }


    public string Name
    {
        get { return _name; }
        set
        {
            // (����) ���� �Ȱ����� ������ ��ó��(������ ���ε�)�� �� �ϵ��� return, �ٵ� ���� ���߿� ���� �������� ������  ��Ű�� �ʹٸ� set�� if�� ���ָ� �� 
            if (_name == value)
                return;

            _name = value;

            //�̸��� ����Ǹ� �˾Ƽ� ������ �ּ��� or �̸��� value�� �Ǹ� �˾Ƽ� ������ �ּ���
            OnPropertyChanged(nameof(Name));
        }
    }


     
   public int Level
    {
        get{ return _level; }
        set
        {
            if (_level == value)
                return;
            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

    //���߿� ��ȹ�ڵ��� �� �������� ������ ������ �� �ְ� ���ּ��� ��� �� �� �־ �ϴ� ����
    public string IconName
    {
        get { return _iconName; }
        set
        {
            if (_iconName == value)
                return;
            _iconName = value;
            OnPropertyChanged(nameof(IconName));
        }
    }




}
