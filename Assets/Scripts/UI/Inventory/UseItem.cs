using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseItem : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    private PlayerEquip _playerEquip;
    private PlayerHealth _playerhealth;

    private void Awake()
    {
        _playerEquip = FindObjectOfType<PlayerEquip>();
        _playerhealth = FindObjectOfType<PlayerHealth>();
    }

    public void SetItem(Item item)
    {
        _item = item;
    }

    private void Equip()
    {
        if(_item is Weapon)
        {
            _playerEquip.SetWeapon(_item);
        }

        if(_item is Armor)
        {
            _playerEquip.SetArmor(_item);
        }

        if(_item is Ussable)
        {
            Ussable item = _item as Ussable;
            _playerhealth.Treatment(item.HealPonts);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Equip();
    }
}
