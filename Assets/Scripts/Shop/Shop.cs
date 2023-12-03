using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapon;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContiner;



    private void Start()
    {
        for (int i = 0; i < _weapon.Count; i++)
        {
            AddItem(_weapon[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContiner.transform);
        view.SellButtomClick += OnSellButtomClick;
        view.Render(weapon);
    }

    private void OnSellButtomClick(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();

            view.SellButtomClick -= OnSellButtomClick;
        }
    }
}
