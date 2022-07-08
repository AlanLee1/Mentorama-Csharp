using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Module9_WarView : MonoBehaviour
{
    //UI
    //public TextMeshProUGUI InfoPlayer1;
    //public TextMeshProUGUI InfoPlayer2;
    public List<TextMeshProUGUI> players = new List<TextMeshProUGUI>();
    public TextMeshProUGUI Action;

    void Start()
    {
        //Event from UI
        Module7_System.OnCharacter += LifeEventHandler;
        //Module7_System.OnCharacter1 += LifeEventHandler1;
        //Module7_System.OnCharacter2 += LifeEventHandler2;
        Module7_Character.OnAction += ActionEvent;
    }

    //UI
    private void LifeEventHandler(List<Module7_Character> listPlayer)
    {
        int i = 0;
        foreach (TextMeshProUGUI infoPlayer in players)
        {
            infoPlayer.text = ($"{listPlayer[i].Name} \n") +
            (listPlayer[i].Life <= 0 ? "Morreu \n" : $"{listPlayer[i].Life} \n") +
            (listPlayer[i].Weapon == null ? "Sem arma \n" : $"Arma: {listPlayer[i].Weapon.Damage} Dano: {listPlayer[i].Weapon.Damage} \n") +
            (listPlayer[i].Armor == null ? "Sem armadura \n" : $"Armadura: {listPlayer[i].Armor.Name} Proteção: {listPlayer[i].Armor.Protection}");
            i++;
        }
    }

    //private void LifeEventHandler1(Module7_Character player)
    //{
    //    InfoPlayer1.text = ($"{player.Name} \n") +
    //        (player.Life <= 0 ? "Morreu \n" : $"{player.Life} \n") +
    //        (player.Weapon == null ? "Sem arma \n" : $"Arma: {player.Weapon.Damage} Dano: {player.Weapon.Damage} \n") +
    //        (player.Armor == null ? "Sem armadura \n" : $"Armadura: {player.Armor.Name} Proteção: {player.Armor.Protection}");
    //}

    //private void LifeEventHandler2(Module7_Character player)
    //{

    //    InfoPlayer2.text = ($"{player.Name} \n") +
    //        (player.Life <= 0 ? "Morreu \n" : $"{player.Life} \n") +
    //        (player.Weapon == null ? "Sem arma \n" : $"Arma: {player.Weapon.Damage} Dano: {player.Weapon.Damage} \n") +
    //        (player.Armor == null ? "Sem armadura \n" : $"Armadura: {player.Armor.Name} Proteção: {player.Armor.Protection}");
    //}

    private void ActionEvent(string action)
    {
        Action.text = action;
    }
}
