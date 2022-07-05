using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module7_System : MonoBehaviour
{
    private Module7_Character _player1;
    private Module7_Character _player2;

    void Start()
    {
        var sword = new Module7_Weapon("Sword", 8);
        var bow = new Module7_Weapon("Bow", 4);

        var armorGold = new Module7_Armor("Gold Armor", 15);
        var armorIron = new Module7_Armor("Iron Armor", 25);

        _player1 = new Module7_Character("Lee", 100, sword, armorGold);
        _player2 = new Module7_Character("Adriano", 100, bow, armorIron);
    }

    // Update is called once per frame
    void Update()
    {
        Player1Commands();
        Player2Commands();
    }


    public void Player1Commands()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player1.Attack(_player2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player1.SharpenWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player1.UnequipWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _player1.EquipWeapon(new Module7_Weapon("Arma Aleatória", Random.Range(5, 10)));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _player1.UnequipArmor();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _player1.EquipArmor(new Module7_Armor("Armadura Aleatória", Random.Range(5, 30)));
        }

    }

    public void Player2Commands()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _player2.Attack(_player1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _player2.SharpenWeapon();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _player2.UnequipWeapon();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _player2.EquipWeapon(new Module7_Weapon("Arma Aleatória", Random.Range(5, 10)));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _player2.UnequipWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _player2.EquipArmor(new Module7_Armor("Armadura Aleatória", Random.Range(5, 30)));
        }
    }

}
