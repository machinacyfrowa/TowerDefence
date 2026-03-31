using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject buildMode;
    int playerGold = 100; //przyk³adowa iloœæ z³ota, któr¹ gracz ma na pocz¹tku
    int playerHealth = 100; //przyk³adowa iloœæ zdrowia, któr¹ gracz ma na pocz¹tku
    //referencje do interfejsu
    public GameObject goldCounter;
    public GameObject healthCounter;
    private void Start()
    {
        //przypisz obiekt BuildMode do zmiennej buildMode
        buildMode = transform.Find("BuildMode").gameObject;
    }
    private void Update()
    {
        //aktualizuj tekst w goldCounter, ¿eby pokazywa³ aktualn¹ iloœæ z³ota
        goldCounter.GetComponent<TextMeshProUGUI>().text = "Gold: " + playerGold;
        //aktualizuj tekst w healthCounter, ¿eby pokazywa³ aktualn¹ iloœæ zdrowia
        healthCounter.GetComponent<TextMeshProUGUI>().text = "Health: " + playerHealth;
    }
    public void EnableBuildMode()
    {
        if(playerGold > 50) //przyk³adowy koszt budowania
        {
            buildMode.SetActive(true);
        }
    }
    public void AddGold(int amount = 1)
    {
        playerGold += amount;
    }
    public void RemoveGold(int amount = 0)
    {
        playerGold -= amount;
    }
    public void RemoveHealth(int amount = 1)
    {
        playerHealth -= amount;
    }
}
