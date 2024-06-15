using UnityEngine.UI;
using UnityEngine;
using System.ComponentModel;
using ViewModel.Extensions;

// 뷰는 뷰모델을 들고 있다
public class TopLeftUiView : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;
    [SerializeField] Image Image_Icon;

    TopLeftViewModel _vm;


    /*초기화 > 이벤트 등록 > */
    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new TopLeftViewModel();
          
            // 초기화 단계에서 미리 등록을 해놔야 이따가 RefeshViewModel 실행될때 이름이 업데이트 될 수 있음
            // 뷰모델의 PropertyChanged 이벤트에 OnPropertyChanged 메서드를 미리 등록하는 개념
            // OnPropertyChanged 메서드를 초기화 단계에서 등록하는 이유는, 나중에 뷰모델의 프로퍼티 값이 변경될 때 뷰가 자동으로 이를 감지하고(PropertyChanged 이벤트 invoke 시킬 때) OnPropertyChanged 함수를 실행되게 해서 UI를 업데이트할 수 있도록 하기 위함.
            _vm.PropertyChanged += OnPropertyChangeds;
            
            // 이벤트 등록 > 콜백을 주지는 않음 왜냐면 확장메서드인 "extention" 에서 역할을 맡았기 때문이며 등록요청에 대한 부분들은 뷰 모델(extension포함)이 하는거지 뷰가 뭔가 하지는 않고 요청만함            
            _vm.RegisterEventsOnEnable();

            // A-0 : UI 오픈될 때 한 번 갱신 시켜주세요
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

    // 중요 ! 바인딩해서 오면 알아서 할 수 있도록 하는  함수? 이건 모든 MVVM의 모든 VIEW에 똑같이 들어가는 함수
    // A-7 : TopLeftUiView의 OnPropertyChanged 메서드가 호출됩니다.
    void OnPropertyChangeds(object sender, PropertyChangedEventArgs e)
    {
        // 프로퍼티 네임들에 따라 처리하겠다
        // 바인딩 된 애들이 값이 변경되면 온프로퍼티,온체인지 부른게 열로 다 들어옴
        switch (e.PropertyName)
        {   
            case nameof(_vm.Name):

                //네임 오면 로컬라이징 받아서 처리하면 좋겠지? 근데 무슨말인지 모르겠네..
                Text_Name.text = _vm.Name;
                break;
            //뷰에 관한 가공처리는 뷰에서 해준다 이것은 뷰 에서만 해도 되는 처리
            //레벨에 따라 캐릭터 색깔이 바뀐다면 여기 늘려서 처리하면 되겠지
            //레벨이 바꼈을때 처리는 여기에만  집약되게 된다 편하다 ..
            // 여기 
            case nameof(_vm.Level):

                Text_Level.text = $"Lv.{_vm.Level}";
                break;
            case nameof(_vm.IconName):
                break;
        }
    }

    // Start is called before the first frame update
}
