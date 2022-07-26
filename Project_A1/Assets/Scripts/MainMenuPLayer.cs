using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPLayer : MonoBehaviour
{
    public AudioClip ChestOpen, BuyItem, ChooseItem, StartGame;

    private AudioSource rcs;
    public GameObject PointLight;
    // Start is called before the first frame update
    void Start()
    {
        rcs = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
            PointLight.transform.Rotate(new Vector3(0, 72, 0) * Time.deltaTime);
        }
    }

    public void ChestOpenSound(){
        rcs.clip = ChestOpen;
        rcs.Play();
    }

    public void BuyItemSound(){
        rcs.clip = BuyItem;
        rcs.Play();
    }

    public void ChooseItemSound(){
        rcs.clip = ChooseItem;
        rcs.Play();
    }

    public void StartGameSound(){
        rcs.clip = StartGame;
        rcs.Play();
    }
}
