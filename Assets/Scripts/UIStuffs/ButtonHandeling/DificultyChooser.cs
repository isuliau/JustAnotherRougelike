using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class DificultyChooser : MonoBehaviour
{
public WaveScript waveScript;
public GameObject DificultySelector;
public GameObject GameUi;
[SerializeField ]private TextMeshProUGUI WaveText;

    void Start()
    {
        Time.timeScale = 0;
    }
    public void Easy()
    {
        waveScript.dificulty = 10;
      DificultySelector.SetActive(false);
      GameUi.SetActive(true);
      Time.timeScale = 1;  
      WaveText.text = "Wave: 1/" + waveScript.dificulty;
    }
    public void Med()
    {
         waveScript.dificulty = 20;
        DificultySelector.SetActive(false);
        GameUi.SetActive(true);
        Time.timeScale = 1;
        WaveText.text = "Wave: 1/" + waveScript.dificulty;
    }
    public void Hard()
    {
         waveScript.dificulty = 30;
        DificultySelector.SetActive(false);
        GameUi.SetActive(true);
        Time.timeScale = 1;
        WaveText.text = "Wave: 1/" + waveScript.dificulty;
    }
}