using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject target;
    public float projectileSpeed = 20f;
    void Start()
    {
        
    }
    void Update()
    {
        if(target == null)
        {
            //cel z jakiegoœ powodu ju¿ nie istnieje, wiêc zniszcz pocisk
            Destroy(gameObject);
            return;
        }
        transform.LookAt(target.transform.position);
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }
}
