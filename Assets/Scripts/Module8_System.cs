using UnityEngine;

public class Module8_System : MonoBehaviour
{
    private Module8_Character _player1;
    private Module8_Character _player2;

    void Start()
    {
        var sword = new Module8_Sword();
        var dagger = new Module8_Dagger(0.1f);

        var armorGold = new Module7_Armor("Gold Armor", 15);
        var armorIron = new Module7_Armor("Iron Armor", 25);

        _player1 = new Module8_Character("Lee", 100, sword, armorGold);
        _player2 = new Module8_Character("Adriano", 100, dagger, armorIron);
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
            _player1.EquipWeapon(GetRandomWeapon());
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
            _player2.EquipWeapon(GetRandomWeapon());
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

    private Module8_Weapon GetRandomWeapon()
    {
        var randomWeapon = Random.Range(0, 2);

        switch (randomWeapon)
        {
            default:
            case 0:
                return new Module8_Sword();

            case 1:
                return new Module8_Dagger(0.1f);
        }
    }
}
