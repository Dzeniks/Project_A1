using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraMusic : MonoBehaviour
{
    //private Random rnd;
    private List<AudioClip> AudioList = new List<AudioClip>();

    public AudioClip A, B, C, D ,E;
    // Start is called before the first frame update
    void Start()
    {
        AudioList.Add(A);AudioList.Add(B);AudioList.Add(C);AudioList.Add(D);AudioList.Add(E);
        GetComponent<AudioSource>().clip = AudioList[Random.Range(0,AudioList.Count)];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
