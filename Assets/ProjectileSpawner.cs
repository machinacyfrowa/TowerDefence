using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    List<GameObject> targets;
    public GameObject projectilePrefab;
    void Start()
    {
        targets = new List<GameObject>();
        //strzelaj co sekundê
        InvokeRepeating("Shoot", 0, 1);
    }
    void Update()
    {
        //to nie jest najbardziej efektywne ale na razie zostaje
        targets = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        //posortuj listê w zale¿noœci od odleg³oœci do wie¿y
        targets = targets.OrderBy(t => 
                        Vector3.Distance(t.transform.position, transform.position)).
                        ToList();
        //je¿li lista nie jest pusta to patrz na najbli¿szego wroga
        if(targets.Count > 0)
        {
            transform.LookAt(targets[0].transform.position);
        }
    }
    void Shoot()
    {
        //je¿eli lista nie jest pusta to strzelaj do najbli¿szego wroga
        if (targets.Count > 0)
        {
            //stwórz pocisk i ustaw jego cel na najbli¿szego wroga
            GameObject projectile = Instantiate(projectilePrefab, 
                                                transform.position, 
                                                Quaternion.identity);
            projectile.GetComponent<ProjectileController>().target = targets[0];
        }
    }
}
