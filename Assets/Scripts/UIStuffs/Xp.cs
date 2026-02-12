using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Xp : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI TextXp;
    public GameObject choices;
    public PopUpChooser popUpChooser1;
        public PopUpChooser popUpChooser2;
            public PopUpChooser popUpChooser3;
    public bool levelup = false;

    
public void SetXp(float xp)
    {
        slider.value = xp;
    }
    void Update()
    {
       if(slider.value >= slider.maxValue)
        {
            levelup = true;
            choices.gameObject.SetActive(true);
            slider.maxValue =  Mathf.Round(slider.maxValue * 1.2f);
            TextXp.text = "Xp: " + slider.value + "/" + slider.maxValue;
popUpChooser1.levelup();
popUpChooser2.levelup();
popUpChooser3.levelup();
        }
}
}