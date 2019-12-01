using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : BaseRogueController, ISpawn
{
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject rogue = Instantiate(prefab) as GameObject;
        rogue.GetComponent<ArmoireComponent>().armoire = armoire;
    }
}
