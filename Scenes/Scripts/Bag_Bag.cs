using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag_Bag : MonoBehaviour
{
    [SerializeField] private GameObject _bag;
    [SerializeField] private GameObject _buttonGranata;
    [SerializeField] private GameObject _buttonDestroyGranat;

    [SerializeField] private GameObject _buttonArmor;
    [SerializeField] private GameObject _buttonDestoryArmor;

    [SerializeField] private GameObject _buttonBodyArmor;
    [SerializeField] private GameObject _buttonDestroyBodyArmor;

    [SerializeField] private GameObject _buttonHelmet;
    [SerializeField] private GameObject _buttonDestroyHelmet;



    public void OpenBag() {
        _bag.SetActive(true);
    }

    public void OpenButtonDestoryGranat() {
        _buttonDestroyGranat.SetActive(true);
    }
    public void ButtonGranat() {
        _buttonGranata.SetActive(false);
    }


    public void OpenButtonDestoryArmor() {
        _buttonDestoryArmor.SetActive(true);
    }
    public void ButtonArmor() {
        _buttonArmor.SetActive(false);
    }

    public void OpenButtonDestroyBodyArmor() {
        _buttonDestroyBodyArmor.SetActive(true);
    }

    public void ButtonBodyArmor() {
        _buttonBodyArmor.SetActive(false);
    }

    public void OpenButtonDestroyHelmet() {
        _buttonDestroyHelmet.SetActive(true);
    }

    public void ButtonHelmet() {
        _buttonHelmet.SetActive(false);
    }
}
