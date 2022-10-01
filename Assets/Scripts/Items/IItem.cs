
using UnityEngine;

public interface IItem
{
    public Sprite Icon { get; }

    public void Take(ItemHolder itemHolder);
}
