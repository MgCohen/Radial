using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBuilder : MonoBehaviour
{
    [SerializeField] int amount;
    public RadialMenu menu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Build();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            menu.Toggle();
        }

    }

    void Build()
    {
        List<Command> commands = new List<Command>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Numbers");
        for (int i = 0; i < amount; i++)
        {
            int j = i + 1;
            var command = new Command(() => Debug.Log(j), sprites[i]);
            commands.Add(command);
        }
        Debug.Log(commands.Count);
        menu.Build(commands);
    }
}
