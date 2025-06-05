using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_Shop : MonoBehaviour
{
    public GameObject mainCam;
    public CinemachineSplineDolly dolly;

    public Shop_Manager manager;
    public UnityEvent shopTrigger = new UnityEvent();

    public float camSpeed;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shopTrigger?.Invoke();
            manager.canShop = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.canShop = false;
        }
    }

    public void Update()
    {
        if (manager.canShop)
        {
            dolly.CameraPosition += camSpeed * Time.deltaTime;
        }
        else
        {
            dolly.CameraPosition -= camSpeed * Time.deltaTime;
        }
    }
}
