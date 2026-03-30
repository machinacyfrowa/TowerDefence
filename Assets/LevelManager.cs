using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject buildMode;
    int playerGold = 100; //przyk³adowa iloœæ z³ota, któr¹ gracz ma na pocz¹tku
    int playerHealth = 100; //przyk³adowa iloœæ zdrowia, któr¹ gracz ma na pocz¹tku
    //referencje do interfejsu
    public GameObject goldCounter;
    private void Start()
    {
        //przypisz obiekt BuildMode do zmiennej buildMode
        buildMode = transform.Find("BuildMode").gameObject;
    }
    private void Update()
    {
        //aktualizuj tekst w goldCounter, ¿eby pokazywa³ aktualn¹ iloœæ z³ota
        goldCounter.GetComponent<TextMeshProUGUI>().text = "Gold: " + playerGold;
    }
    public void EnableBuildMode()
    {
        buildMode.SetActive(true);
    }
    public void AddGold(int amount = 1)
    {
        playerGold += amount;
    }
}
