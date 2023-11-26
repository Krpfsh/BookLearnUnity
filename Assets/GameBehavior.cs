using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;
using System;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public Stack<string> lootStack = new Stack<string>();
    public bool showWinScreen = false;

    public string labelText = "Collect all 4 items and win your freedom!";
    public const int maxItems = 1;
    public bool showLossScreen = false;
    private int _itemsCollected = 0;
    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                SetWin("you've found all the items!", true);
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
            Debug.Log($"Items: {_itemsCollected}");
        }
    }
    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                SetLose("You Want another life with that?", true);
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }
            Debug.Log($"HP: {_playerHP}");
        }
    }
    private void SetWin(string Text, bool showScreen)
    {
        labelText = Text;
        showWinScreen = showScreen;
        Time.timeScale = 0;
    }
    public static void Print(string newText)
    {
        Debug.Log(newText);
    }
    private void SetLose(string Text, bool showScreen)
    {
        labelText = Text;
        showLossScreen = showScreen;
        Time.timeScale = 0;
    }
    private void Start()
    {
        Initialize();
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);
    }
    public void Initialize()
    {
        _state = "Manager init";
        _state.FancyDebug();
        Debug.Log(_state);
        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("WingedBoot");
        lootStack.Push("MythrilBracers");
        debug(_state);
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");

        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;
    }

    private void HandlePlayerJump()
    {
        Debug.Log("Player Jumped");
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("delegating the debug task..");
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 -100, Screen.height -50,300,50), labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }
        if(showLossScreen)
        {
            if(GUI.Button(new Rect(Screen.width /2 -100, Screen.height /2 -50, 200, 100), "You Lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }
    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        Debug.Log($"You got a {currentItem} . You have change to get a {nextItem}");
        Debug.Log($"There are {lootStack.Count} random loot items waiting for you!");
    }
}
