using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartridges : MonoBehaviour
{
    public int Numbercartridges = 500;
    [SerializeField] private TMPro.TMP_Text _cartridgesTest;
    [SerializeField] private GameObject _buttoncartridges;

    private void Start() {
        UpdateCountcartridgesText();
    }

    public void Countcartridges() {

        Numbercartridges--;
        string numberString = "Осталось патронов: "  +   Numbercartridges.ToString();
        _cartridgesTest.text = numberString;
    }
    public void UpdateCountcartridgesText() {
        _cartridgesTest.text = Numbercartridges.ToString();
    }
}
