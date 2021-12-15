using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Level/Info", order = 1)]

public class MiniGameInfo : ScriptableObject
{

    public string LevelChallange = "No te caigas";
    public int duration = 5;
    public string SceneName = "Level1";
    public AudioClip levelSong;
}
