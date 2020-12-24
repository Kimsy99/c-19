using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class BgFadeInOut : MonoBehaviour
{
   
  
    public TextMeshProUGUI text;
   

    public float showTime = 3;
    public float ShowTimeTrigger = 0;
    public float fadeTime = 5;
    public float fadeTimeTrigger = 0;
    private bool show = true;
    private bool showstory = false;

    [SerializeField] public GameObject Story;
    [SerializeField] public GameObject NextStory;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       if(Story == true)
        { 

            ShowTimeTrigger += Time.deltaTime;
            if (ShowTimeTrigger > showTime)
            {
                show = true;
                if (fadeTimeTrigger >= 0 && fadeTimeTrigger < fadeTime)
                {
                    fadeTimeTrigger += Time.deltaTime;
                    if (show)
                    {
                        text.color = new Color(1, 1, 1, 1 - (fadeTimeTrigger / fadeTime));

                    }
                    else 
                    {
                        text.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));
                     

                }
                   
                }
                else if (fadeTimeTrigger >= fadeTime)
                {
                  Story.SetActive(false);
                  NextStory.SetActive(true);


                }
            }
        }


    }
}
