using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineApply : MonoBehaviour
{
    public List<PlayableDirector> Playables = new List<PlayableDirector>();
    public List<PlayableAsset> Timelines = new List<PlayableAsset>();
    public List<float> Offsets = new List<float>();

    private void Start()
    {
        for (int i = 0; i < Playables.Count; i++)
        {
            Playables[i].initialTime = Offsets[i];
            Playables[i].playableAsset = Timelines[i];
            Playables[i].Play();
        }
    }
}
