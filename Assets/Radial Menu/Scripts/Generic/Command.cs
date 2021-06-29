using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Command
{
    public Command(Action _action, Sprite _sprite)
    {
        action = _action;
        sprite = _sprite;
    }

    readonly Action action;
    public readonly Sprite sprite;

    public void Execute()
    {
        action.Invoke();
    }
}
