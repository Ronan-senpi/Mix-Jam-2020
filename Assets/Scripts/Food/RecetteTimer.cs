using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecetteTimer : MonoBehaviour
{
    [SerializeField]
    int minTimer, maxTimer;
    [SerializeField]
    FillRecette fillRecette;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        ResetTimer();
    }
    public void ResetTimer()
    {
        slider.maxValue = Random.Range(minTimer, maxTimer + 1);

        slider.value = slider.maxValue;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value -= Time.deltaTime;
        if (slider.value == 0)
        {
            this.fillRecette.SetFree();
            FoodManager.Instance.CreateRecette(fillRecette);
            ResetTimer();

        }
    }
}
