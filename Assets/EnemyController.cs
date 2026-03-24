using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //referencje do dostêpnych materia³ów
    public Material[] materials;
    //obiekt zawieraj¹cy wszystkie punkty trasy
    GameObject waypoints;
    //lista punktów trasy
    List<Transform> points;
    public float walkSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ustaw losowy materia³ dla potomka - modelu
        transform.GetChild(0).GetComponent<MeshRenderer>().material = 
                        materials[Random.Range(0, materials.Length)];
        //znajdŸ obiekt po jego nazwie i przypisz go do zmiennej waypoints
        waypoints = GameObject.Find("Waypoints");
        //pobierz wszystkie komponenty Transform z obiektu waypoints i przypisz je do listy points
        points = waypoints.GetComponentsInChildren<Transform>().
                            //pomiñ rodzica który nie jest punktem trasy
                            Skip(1).
                            //zrób z tego listê
                            ToList();
    }
    void Update()
    {
        if(points.Count > 0)
        {
            //patrz siê na nastêpny punkt trasy
            transform.LookAt(points[0].position);
            //...i poruszaj siê w jego kierunku
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            if (Vector3.Distance(transform.position, points[0].position) < 0.01f)
            {
                //jeœli dotar³eœ do punktu trasy, usuñ go z listy
                points.RemoveAt(0);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //niszczymy nabój
        Destroy(other.gameObject);
        //niszczymy wroga
        Destroy(gameObject);
    }
}
