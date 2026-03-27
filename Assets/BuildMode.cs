using UnityEngine;

public class BuildMode : MonoBehaviour
{
    public GameObject buildingPrefab; //prefab budynku, który bêdzie budowany
    GameObject buildingInstance; //instancja budynku, która bêdzie pokazywana podczas budowania
    private void Start()
    {
        //stwórz instancjê budynku, ale j¹ ukryj
        buildingInstance = Instantiate(buildingPrefab);
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
        }
        else //jeœli pozycja = null, to ukryj wizualizacjê budynku
        {
            buildingInstance.SetActive(false);
        }
    }
}
