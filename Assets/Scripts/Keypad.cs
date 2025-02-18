using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private GameObject Light;
    [SerializeField] private Canvas Victory;

    private string Answer = "1983";

    public void Number(int number)
    {
        if (Ans.text.Length < 4)
        {
            Ans.text += number.ToString();
        }
    }

    public void Intro()
    {
        if (Ans.text == Answer)
        {
            Ans.color = Color.green;
            Ans.text = "CORRECTO";
            Light.GetComponent<Renderer>().material.color = Color.green;
            Victory.enabled = true;
            
        }

        else
        {
            StartCoroutine(Incorrect());
        }
    }

    private IEnumerator Incorrect()
    {
        Ans.color = Color.red;
        Ans.text = "INCORRECTO";
        yield return new WaitForSeconds(2);
        Ans.text = ""; 
        Ans.color = Color.black;
    }
}
