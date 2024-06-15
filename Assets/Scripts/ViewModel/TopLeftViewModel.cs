
// 뷰에 값이 변경된 걸 알려주기 위한 목적만 달성하면 끝 
// View는 뷰에관한 요소들을 들고있는 애이고, ViewModel은 데이터에 관한 부분들 데이터를 가져와서 뷰한테 쏴주는 역할임 뷰한테 쏴주는 역할 즉 바인딩 역할
//뷰를 직접적으로 이 안에서 수정하지 않음 뷰에 데이터만 수정함
//값이 똑같은게 들어오면 뷰처리(데이터 바인딩)을 안 함 , 근데 만약 나중에 값이 같은데도 갱신을  시키고 싶다면 set의 if문 빼주면 됨 
using System.ComponentModel;

public class TopLeftViewModel
{
    //userid는 식별용이라 view에 노출 안 됨 그래서 onpropchanged쓸 필요 없음 그냥 프로퍼티 용으로만 사용 됨 
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
            //이름이 변경되면 알아서 수정해 주세요 or 이름이 value가 되면 알아서 수정해 주세요
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

    //나중에 기획자들이 저 아이콘은 데이터 가져올 수 있게 해주세요 라고 할 수 있어서 일단 선언
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

// C#의 OnPropertyChanged 
// 
    #region PropChanged
    public event PropertyChangedEventHandler PropertyChanged;

    // protected 는 데이터 바인들을 위해서 사용하는 것 그냥 암기임 !
    // 게터세터로 만들어진 얘네들은 프로퍼티이고 프로퍼티네임을 우리가 나중에 전달해 줄거야...  이벤트를 위의 프로퍼티 값이 변경되는 시점에서 발생시켜 주겠습니다 라는 뜻    
    protected virtual void OnPropertyChanged(string PropertyName)
    {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(PropertyName));
    }
    #endregion


}
