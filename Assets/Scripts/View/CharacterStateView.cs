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
}
