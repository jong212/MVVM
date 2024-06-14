using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;
using ViewModel.Extension;

public class CharacterStateView : MonoBehaviour
{
    [SerializeField] Slider Slider_Hp;

    private CharacterStateViewModel _vm;

    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new CharacterStateViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterHpChangedEvent(true);
            _vm.RefreshViewModel();
        }
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_vm.CharacterHp):
                Slider_Hp.value = ((float)_vm.CharacterHp / 100); // 뒤에 100은 임의값 MaxHp 프로퍼티 추가 필요함
                break;
        }
    }

}
