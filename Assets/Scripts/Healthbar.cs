using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private ImageFiller _healthBar;
    [SerializeField] private GameObject _healthUnit;

    private Health _unitHealth;

    public void Start()
    {
        _unitHealth = _healthUnit.GetComponent<Health>();
        HpBarUpdateView();

        _unitHealth.ValueChanged += HpBarUpdateView;
    }

    private void HpBarUpdateView()
    {
        _healthBar.UpdateViewCurrentCount(_unitHealth.Current, _unitHealth.Max);
    }

    private void OnDestroy()
    {
        _unitHealth.ValueChanged -= HpBarUpdateView;
    }
}
