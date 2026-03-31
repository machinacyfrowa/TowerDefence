using UnityEngine;
using UnityEngine.InputSystem;

public class BuildMode : MonoBehaviour
{
    public GameObject buildingPrefab; //prefab budynku, który bêdzie budowany
    GameObject buildingInstance; //instancja budynku, która bêdzie pokazywana podczas budowania
    private void Start()
    {
        //stwórz instancjê budynku, ale j¹ ukryj
        buildingInstance = Instantiate(buildingPrefab);
        //wy³¹cz kolizjê dla tej instancji, ¿eby nie przeszkadza³a w raycastach
        buildingInstance.GetComponent<Collider>().enabled = false;
        //wy³¹cz skrypt ¿eby duszek nie strzela³
        buildingInstance.GetComponentInChildren<ProjectileSpawner>().enabled = false;

        buildingInstance.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //pobierz pozycjê kursora z naszego skryptu CursorWorldPosition
        //znajduj¹cego siê na g³ównej kamerze
        Vector3? cursorPosition = Camera.main.GetComponent<CursorWorldPosition>().position;
        //poka¿ wizualizacjê budynku na pozycji kursora
        if (cursorPosition != null)
        {
            buildingInstance.SetActive(true);
            buildingInstance.transform.position = cursorPosition.Value;
            //sprawdŸ czy jest naciœniêty lewy przycisk myszy,
            //jeœli tak, to "postaw" budynek na tej pozycji
            if(Mouse.current.leftButton.isPressed)
            {
                
                //sprawdŸ czy jest wolne miejsce
                //jeœli nie ma niczego w promieniu 0.9f od pozycji kursora
                //metr nad ziemi¹ to mo¿na postawiæ budynek
                if (!Physics.CheckSphere(cursorPosition.Value + Vector3.up, 
                                            0.9f))
                {
            

                    //postaw now¹ instacjê wie¿y na pozycji kursora
                    Instantiate(buildingPrefab, 
                                cursorPosition.Value, 
                                Quaternion.identity);
                    //zredukuj z³oto gracza o koszt budowania
                    GameObject.Find("LevelManager").GetComponent<LevelManager>().RemoveGold(50);
                    //usuñ duszka budowania
                    buildingInstance.SetActive(false);
                    gameObject.SetActive(false); //wy³¹cz tryb budowania po postawieniu budynku
                }
                
            }
        }
        else //jeœli pozycja = null, to ukryj wizualizacjê budynku
        {
            buildingInstance.SetActive(false);
        }
    }
}
