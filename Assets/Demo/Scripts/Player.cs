using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player : MonoBehaviour
{
    [SerializeField] RadialMenu menu;
    [SerializeField] List<IPlayerAction> actions = new List<IPlayerAction>();


    private void Start()
    {
        actions = GetComponents<IPlayerAction>().ToList();
        List<Command> commands = new List<Command>();
        foreach (var act in actions)
        {
            commands.Add(CreateCommand(act));
        }
        menu.Build(commands);
    }

    Command CreateCommand(IPlayerAction act)
    {
        return new Command(act.Set, act.icon);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menu.Toggle();
        }
    }
}
