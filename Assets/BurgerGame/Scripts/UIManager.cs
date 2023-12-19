using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
    
{
    [SerializeField] private TMP_Text liveText;
    private BurgerMan burgerMan;

    // Start is called before the first frame update
    void Start()
    {
        burgerMan = FindObjectOfType<BurgerMan>();
        burgerMan.OnItemPickUp.AddListener(updateText);
    }

    void updateText()
    {
        liveText.SetText("You've picked up something");
    }
}
