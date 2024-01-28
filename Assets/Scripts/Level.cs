using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Game;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Level : MonoBehaviour
{
    public GameObject level1Player;
    public List<GameObject> collectedItems = new List<GameObject>();
    Player _player;
    public bool isPickupEnabled = false;
    Coroutine pickupDelayCoroutine;
    public int numOfRedeemedItems = 0;
    public TextMeshProUGUI redeemedItemsText, winText, pickupInstructionText;
    public int totalNumOfParts = 5;
    private void Awake()
    {
        _addEventListeners();
        numOfRedeemedItems = 0;
    }

    void _addEventListeners()
    {
        EventManifest.eventLevel1Start += StartLevel1;
        EventManifest.eventGameFinish += FinishLevel1;
        EventManifest.eventIsTouchingItem += ToggleItemPickupMessage;
    }
    private void OnDestroy()
    {
        _removeEventListeners();
    }

    void _removeEventListeners()
    {
        EventManifest.eventLevel1Start -= StartLevel1;
        EventManifest.eventGameFinish -= FinishLevel1;
        EventManifest.eventIsTouchingItem -= ToggleItemPickupMessage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q key pressed!");
            DropAllItems();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed!");
            EnablePickup();
        }
    }

    void StartLevel1()
    {
        _player = Instantiate(level1Player, transform).GetComponent<Player>();
        _player.camController.disableInput = false;
        _player.ActivateThirdPerson();
        ToggleItemPickupMessage(false);
    }

    void FinishLevel1()
    {
        winText.gameObject.SetActive(true);
    }

    void ToggleItemPickupMessage(bool toggle)
    {
        pickupInstructionText.gameObject.SetActive(toggle);
    }

    public void CollectItem(GameObject g)
    {
        collectedItems.Add(g);
    }

    public void DropAllItems()
    {
        foreach(GameObject g in collectedItems)
        {
            StartCoroutine(Drop_IE(g));
            //g.transform.parent = null;
            //g.AddComponent<Rigidbody>();
            //g.GetComponent<Rigidbody>().isKinematic = true;
            //g.GetComponent<Collider>().isTrigger = true;
        }
        collectedItems.Clear();
    }

    public Transform GetPlayerTransform()
    {
        return _player.headTransform;
    }

    public void EnablePickup()
    {
        if(pickupDelayCoroutine == null)
        {
            pickupDelayCoroutine = StartCoroutine(EnablePickup_IE());
        }
        else
        {
            return;
        }
        
    }

    IEnumerator EnablePickup_IE()
    {
        Debug.Log("Enabling pickup");
        isPickupEnabled = true;
        yield return new WaitForSeconds(0.5f);
        isPickupEnabled = false;
        pickupDelayCoroutine = null;
        Debug.Log("Disabling pickup");
    }


    public void RedeemItem(GameObject g)
    {
        collectedItems.Remove(g);
        numOfRedeemedItems++;
        redeemedItemsText.text = "Parts collected: " + numOfRedeemedItems.ToString();
        if (numOfRedeemedItems == totalNumOfParts)
        {
            gameInstance.changeGameState(GameState.FINISH);
        }
        return;
    }

    IEnumerator Drop_IE(GameObject g)
    {
        g.transform.parent = null;
        g.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2);
        g.GetComponent<Rigidbody>().isKinematic = true;
        g.GetComponent<Collider>().isTrigger = true;
    }
}
