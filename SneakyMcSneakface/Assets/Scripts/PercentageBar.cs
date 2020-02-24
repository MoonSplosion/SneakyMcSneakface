using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageBar : MonoBehaviour
{
    public float Current = 100.0f;

    public float Max = 100.0f;

    public Image BarImage;

    // Start is called before the first frame update
    void Start()
    {
        BarImage.type = Image.Type.Filled;
        BarImage = gameObject.GetComponent<Image>();
        BarImage.fillMethod = Image.FillMethod.Horizontal;
    }

    // Update is called once per frame
    void Update()
    {
        float percentFilled = Current / Max;
        BarImage.fillAmount = percentFilled;
        if (percentFilled > 0.25)
        {
            BarImage.color = Color.green;
        }
        else
        {
            BarImage.color = Color.red;
        }
    }
}
