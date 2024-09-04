using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFiller : MonoBehaviour
{
    public Image Image;

    [SerializeField] private float percentage = 0f;

    [SerializeField] private float nextPercentage;

    public float FillTime;

    public void SetPercentage(float percentage)
    {
        nextPercentage = percentage; 
    }

    public void SetPercentageHard(float percentage)
    {
        nextPercentage = percentage;
        this.percentage = percentage;
        Image.fillAmount = percentage;
    }

    private void Update()
    {
        percentage = Mathf.Lerp(percentage, nextPercentage, Time.deltaTime / FillTime);

        Image.fillAmount = percentage;
    }

}
