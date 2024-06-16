using UnityEngine.UI;
using UnityEngine;
using System.ComponentModel;
using ViewModel.Extensions;

/* 
 * # View
   [핵심] 
   1. 데이터 바인딩을 미리 해놔야 한다!
   2. 뷰모델을 들고 있자 !
   [정리]
   1. 뷰는 데이터를 직접적으로 수정하지 않도록 설계한다. 
   2. 데이터(프로퍼티) "값" 이 변경되는 "곳(스크립트)"은 ViewModel에서 이루어 진다 (데이터와 로직을 분리)
   3. Viwe와 ViewModel의 관계
     가) 이벤트 발생: ViewModel의 프로퍼티 "값"이 변경되면 겟셋의 셋에서 OnPropertyChanged 메서드를 호출 > PropertyChanged 이벤트 발생.
     나) 이벤트 구독: View는 ViewModel의 PropertyChanged 이벤트를 구독하고 있기 때문에 ViewModel의 데이터 변경을 감지할 수 있다.
     다) 이벤트 핸들러 호출: 감지 되면 View의 이벤트 핸들러(OnPropertyChangeds)가 호출 됨
     라) UI 업데이트: View의 이벤트 핸들러는 변경된 값을 ViewModel에서 가져와서 UI를 업데이트합니다. 이 과정에서 View는 ViewModel의 프로퍼티에 접근하여 최신 데이터를 가져오고, 이를 기반으로 UI 요소를 갱신한다.
   4.ViewModel의 프로퍼티 값 변경과 OnPropertyChanged 호출을 통해 PropertyChanged 이벤트가 발생하고, View가 이 이벤트를 구독하여 UI를 업데이트하는 과정을 데이터 바인딩이라고 한다.
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

            // 초기화 단계에서 ViewModel의 PropertyChanged 이벤트에 View의 OnPropertyChanged 메서드를 등록
            // 이 단계에서 미리 등록해두면, 나중에 ViewModel의 프로퍼티 값이 변경될 때 PropertyChanged 이벤트가 발생하고,
            // View의 OnPropertyChanged 메서드가 호출되어 UI를 자동으로 업데이트할 수 있음!
            _vm.PropertyChanged += OnPropertyChangeds;

            // 이벤트 등록: ViewModel에서 이벤트를 처리하는 확장 메서드(extension)가 수행
            // View는 단지 이벤트 등록만 해두고, 구체적인 이벤트 처리는 ViewModel과 그 확장 메서드가 담당(뷰가 직접적으로 데이터를 수정하거나 이벤트를 처리하지 않고, 필요한 구독과 요청을 설정해 놓는다는 의미.)
            _vm.RegisterEventsOnEnable();

            // A-0 : UI 오픈될 때 한 번 ViewModel의 데이터를 갱신하여 최신 상태로 업데이트
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

    // 이 OnPropertyChangeds 함수가 호출된다는 것은 ViewModel의 프로퍼티 값이 수정되었다는 뜻
    // A-7 : TopLeftUiView의 OnPropertyChangeds 메서드가 호출됩니다.
    void OnPropertyChangeds(object sender, PropertyChangedEventArgs e)
    {
        // PropertyChanged 이벤트에서 전달된 PropertyName에 따라 UI 요소를 업데이트합니다.
        // 뷰모델에서 바인딩 된 프로퍼티 값이 변경되면 OnPropertyChanged 메서드가 호출되어 PropertyChanged 이벤트가 발생하고,
        // 이 이벤트를 구독한 OnPropertyChangeds 메서드가 호출됩니다.
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                // Name 프로퍼티가 변경되면 해당 값을 UI의 Text_Name에 반영합니다.
                Text_Name.text = _vm.Name;
                break;

            case nameof(_vm.Level):
                // Level 프로퍼티가 변경되면 해당 값을 UI의 Text_Level에 반영합니다.
                Text_Level.text = $"Lv.{_vm.Level}";
                break;

            case nameof(_vm.IconName):
                // IconName 프로퍼티가 변경되면 아이콘을 업데이트하는 로직을 추가할 수 있습니다.
                // 예: Image_Icon.sprite = ...;
                break;
        }
    }

    // Start is called before the first frame update
}
