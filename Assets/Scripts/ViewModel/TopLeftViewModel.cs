

/*  # ViewModel
 *  [핵심] 
 *  1. 프로퍼티 값이 변경되면 Invoke 되도록 get/set 위주의 코드만 작성하고, View에서 알 수 있도록 데이터 바인딩을 위해 set에서 OnPropertyChanged 호출 시키도록 한다.
 *   ㄴ 즉, 뷰모델은 뷰한테 야 너 데이터 변경 됐어 ! 라고 알려주는 역할만 해야함.
 */



using System.ComponentModel;
using ViewModel;

public class TopLeftViewModel : ViewModelBase
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
            // (공통) 값이 똑같은게 들어오면 뷰처리(데이터 바인딩)를 안 하도록 return, 근데 만약 나중에 값이 같은데도 갱신을  시키고 싶다면 set의 if문 빼주면 됨 
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




}
