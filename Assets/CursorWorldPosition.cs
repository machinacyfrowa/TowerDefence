using UnityEngine;
using UnityEngine.InputSystem;

public class CursorWorldPosition : MonoBehaviour
{
    //maska do raycastu
    public LayerMask layerMask;
    //zwracana pozycja kursora w œwiecie gry
    public Vector3? position;
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //hit to bêdzie miejsce "uderzenia" promienia œwiat³a w obiekt
        RaycastHit hit;
        //jeœli raycast zwraca true, to znaczy, ¿e promieñ œwiat³a trafi³ w jakiœ obiekt
        //zapisz wtedy pozycje trafienia w zmiennej hit
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
           position = hit.point;  
        } 
        else
        {
            position = null; //jeœli raycast nie trafi³ w ¿aden obiekt, ustaw pozycjê na null
        }
    }
}
