using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IItem
{
    private Camera _camera;
    private PlayerMovement _playerMovement;
    private ItemHolder _itemHolder;
    private bool _canTake = false;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void Take(ItemHolder itemHolder)
    {
        itemHolder.AddItem(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemHolder itemHolder))
        {
            _itemHolder = itemHolder;
            _canTake = true;
        }
    }

    private void Update()
    {
        if (_canTake == false)
            return;

        if (Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (transform == raycastHit.transform)
                {
                    Take(_itemHolder);
                    _playerMovement.CantMove();
                }
            }
        }
        else
        {
            _playerMovement.CantMove();
        }
    }

}
