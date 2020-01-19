using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameObject bar;
    public float fillAmount;

    void Start()
    {
        bar = transform.Find("Bar").gameObject;
    }

    public void UpdateBar(float actualValue, float maxValue)
    {
        bar = transform.Find("Bar").gameObject;
        fillAmount = actualValue / maxValue;
        bar.transform.localScale = new Vector3(fillAmount, 1f);
    }

    public void UpdateBar()
    {
        bar = transform.Find("Bar").gameObject;
        bar.transform.localScale = new Vector3(fillAmount, 1f);
    }

}
