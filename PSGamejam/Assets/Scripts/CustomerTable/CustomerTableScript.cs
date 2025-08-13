using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerTableScript : MonoBehaviour
{
    private bool IsAvalible = true;
    [SerializeField] private GameObject customer;
    private GameObject customerTemp;
    private Coroutine customerLifetimeCoroutine;

    private void Start()
    {
        // Spawn the first customer at start
        SpawnCustomer();
    }

    private void SpawnCustomer()
    {
        if (!IsAvalible) return;

        customerTemp = Instantiate(customer, transform.position, quaternion.identity);
        IsAvalible = false;

        // Start lifetime timer for the customer
        customerLifetimeCoroutine = StartCoroutine(CustomerLifetimeTimer(30f));
    }

    public void RemoveCustomer()
    {
        if (customerTemp != null)
        {
            Destroy(customerTemp);
            SetAvalible(true);
            // Stop the lifetime timer if customer is removed early
            if (customerLifetimeCoroutine != null)
            {
                StopCoroutine(customerLifetimeCoroutine);
                customerLifetimeCoroutine = null;
            }

            StartCoroutine(RespawnAfterDelay());
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        float delay = Random.Range(5f, 15f);
        print("Respawning customer in: " + delay + " seconds");
        yield return new WaitForSeconds(delay);

        IsAvalible = true;
        SpawnCustomer();
    }

    private IEnumerator CustomerLifetimeTimer(float timeLimit)
    {
        yield return new WaitForSeconds(timeLimit);

        // If still there after timeLimit, they leave
        if (customerTemp != null)
        {
            Debug.Log("Customer left after waiting too long.");
            RemoveCustomer();
        }
    }

    public bool GetAvalible()
    {
        return IsAvalible;
    }

    public void SetAvalible(bool ava)
    {
        IsAvalible = ava;
    }

    public GameObject GetCustomer()
    {
        return customerTemp;        
    }
}
