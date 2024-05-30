using UnityEngine;

public class bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 3);
    }
    public float speed;
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
