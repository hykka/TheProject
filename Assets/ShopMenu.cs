using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopMenu : MonoBehaviour
{
    public Text Coin;
    public YsoCorp.DataManager data;
    public GameObject []skin;

    public void UpdateData() {
        Coin.text = data.getCoin().ToString();
        if (data.getSkint(0) == true)
            skin[0].SetActive(false);
        if (data.getSkint(1) == true)
            skin[1].SetActive(false);
    }

    void Start()
    {
        UpdateData();
    }

    void Update()
    {
        
    }

    public void check(int value)
    {
        if (data.getCoin()>= value)
        {
            data.setCoin(-value);
            Coin.text = data.getCoin().ToString();
            if (value == 10)
            {
                data.setSkin(true, 0);
                skin[0].SetActive(false);
            }
            else if (value == 15)
            {
                data.setSkin(true, 1);
                skin[1].SetActive(false);
            }
        }
    }
}
