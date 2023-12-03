using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButtom;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtomClick;

    private void OnEnable()
    {
        _sellButtom.onClick.AddListener(OnButtomClick);
        _sellButtom.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButtom.onClick.RemoveListener(OnButtomClick);
        _sellButtom.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
        {
            _sellButtom.interactable = false;
        }
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    public void OnButtomClick()
    {
        SellButtomClick?.Invoke(_weapon, this);
    }
}
