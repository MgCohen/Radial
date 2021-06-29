using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction<T> : MonoBehaviour, IPlayerAction
{
    Sprite IPlayerAction.icon
    {
        get
        {
            return actionIcon;
        }

        set
        {
            
        }
    }


    public Sprite actionIcon;


    public abstract void Act(T param);

    public abstract void Set();

}


interface IPlayerAction
{
    Sprite icon { get; set; }
    void Set();
}