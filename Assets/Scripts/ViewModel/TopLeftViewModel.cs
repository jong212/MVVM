
// �信 ���� ����� �� �˷��ֱ� ���� ������ �޼��ϸ� �� 
// View�� �信���� ��ҵ��� ����ִ� ���̰�, ViewModel�� �����Ϳ� ���� �κе� �����͸� �����ͼ� ������ ���ִ� ������ ������ ���ִ� ���� �� ���ε� ����
//�並 ���������� �� �ȿ��� �������� ���� �信 �����͸� ������
//���� �Ȱ����� ������ ��ó��(������ ���ε�)�� �� �� , �ٵ� ���� ���߿� ���� �������� ������  ��Ű�� �ʹٸ� set�� if�� ���ָ� �� 
using System.ComponentModel;

public class TopLeftViewModel
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

// C#�� OnPropertyChanged 
// 
    #region PropChanged
    public event PropertyChangedEventHandler PropertyChanged;

    // protected �� ������ ���ε��� ���ؼ� ����ϴ� �� �׳� �ϱ��� !
    // ���ͼ��ͷ� ������� ��׵��� ������Ƽ�̰� ������Ƽ������ �츮�� ���߿� ������ �ٰž�...  �̺�Ʈ�� ���� ������Ƽ ���� ����Ǵ� �������� �߻����� �ְڽ��ϴ� ��� ��    
    protected virtual void OnPropertyChanged(string PropertyName)
    {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(PropertyName));
    }
    #endregion


}
