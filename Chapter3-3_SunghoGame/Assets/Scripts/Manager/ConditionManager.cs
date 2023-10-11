using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Condition
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float decayRate;
    public Image uiBar;

    public void Initialize()
    {
        curValue = startValue;
    }

    public void Change(float amount)
    {
        curValue = Mathf.Clamp(curValue + amount, 0f, 100f);
        uiBar.fillAmount = curValue / maxValue;
    }

    public bool IsZero()
    {
        return curValue <= 0f;
    }

    public void Decay()
    {
        Change(-1 * decayRate * Time.deltaTime);
    }
}
public class ConditionManager : MonoBehaviour
{
    [Header("Player Stat")]
    public Condition Health;
    public Condition Hunger;
    void Start()
    {
        Health.Initialize();
        Hunger.Initialize();
        GameManager.Instance.conditionManager = this;
    }

    void Update()
    {
        Hunger.Decay();

        if(Hunger.IsZero())
        {
            Health.Decay();
        }

        if (Health.IsZero())
        {
            GameManager.Instance.inventory.OnUI();
            SceneManager.LoadScene("GameOverScene");
        }
    }


}
