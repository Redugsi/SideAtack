﻿using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private BotController botController;

    [SerializeField]
    private SpawnerComponent spawner;

    [SerializeField]
    private GameComponent game;

    public ScoreObject score;
}
