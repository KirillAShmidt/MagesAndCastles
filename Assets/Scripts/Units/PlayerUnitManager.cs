using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    public List<Player> playerList = new List<Player>();
    public static PlayerUnitManager Instance;
    public bool isSelectable = false;

    [SerializeField] private Material _materialOnSelected;

    private void Start()
    {
        Instance = this;

        UnitSpawner.Instance.OnUnitSpawned += AddNewPlayer;
    }

    private void AddNewPlayer(Unit unit)
    {
        var player = unit.GetComponent<Player>();

        if(player != null)
        {
            playerList.Add(player);
        }
    }

    public void MakePlayerUnitsVisible()
    {
        isSelectable = true;

        foreach (Player player in playerList)
        {
            if (!player.isAggressive)
                player.MakeVisible();
        }
    }

    public void MakePlayerUnitsRegular()
    {
        isSelectable = false;

        foreach (Player player in playerList)
        {
            player.MakeRegular();
        }
    }

    public void SwitchState() 
    {
        switch (isSelectable)
        {
            case true:
                MakePlayerUnitsRegular();
                isSelectable = false;
                break;
            case false:
                MakePlayerUnitsVisible();
                isSelectable = true;
                break;
        }
    }
}
