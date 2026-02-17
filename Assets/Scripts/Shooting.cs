using UnityEngine;
using UnityEngine.InputSystem;
public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject lazer;

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        Instantiate(lazer,firepoint.position,firepoint.rotation);
    }
}
