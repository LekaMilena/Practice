using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [SerializeField] private GameObject gameplayUi, starGameBtn;
    [SerializeField] private Player player, ai;
    [SerializeField] private Text infoText, playerHpText, aiHpText;
    [SerializeField] private Text playerName,battleLog,aiLog;

    private bool playerAttacking;
    private int raund;

	// Use this for initialization
	void Start () {
        starGameBtn.SetActive(true);
        gameplayUi.SetActive(false);
    }

    public void NewGame()
    {
        raund = 1;
        battleLog.text = "";
        aiLog.text = "";
        player.Hp = 100;
        ai.Hp = 100;
        playerAttacking = true;

        playerHpText.text = "HP: " + player.Hp;
        aiHpText.text = "HP: " + ai.Hp;

        infoText.text = playerAttacking ? "Attack!" : "Defence";

        starGameBtn.SetActive(false);
        aiLog.gameObject.SetActive(false);
        battleLog.gameObject.SetActive(false);
        gameplayUi.SetActive(true);
    }

    public void EndTurn()
    {
        ai.SelectBodyPart(Random.Range(0, 2));
        if (playerAttacking)
        {
            aiLog.text += raund + ": ";
            ai.AttackAtPart(player.SelectedBodyPart, player.Attack);
            aiLog.text += playerName.text + ": " + player.Hp + ", ";
            aiLog.text += "\n";
        }
        else
        {
            battleLog.text += raund + ": ";
            player.AttackAtPart(ai.SelectedBodyPart, ai.Attack);
            battleLog.text += "AI " +  ": " + ai.Hp + ", ";
            battleLog.text += "\n";
        }
        raund++;
        playerHpText.text = "HP: "+player.Hp;
        aiHpText.text = "HP: "+ai.Hp;

        if (player.Hp <= 0)
        {
            
            infoText.text = playerName.text+ " have been killed";
            starGameBtn.SetActive(true);
            battleLog.gameObject.SetActive(true);
            aiLog.gameObject.SetActive(true);
            gameplayUi.SetActive(false);

        }
        else if (ai.Hp <= 0)
        {
            infoText.text = "AI've been killed";
            starGameBtn.SetActive(true);
            aiLog.gameObject.SetActive(true);
            battleLog.gameObject.SetActive(true);
            gameplayUi.SetActive(false);
        }
        else
        {
            playerAttacking = !playerAttacking;
            infoText.text = playerAttacking ? "Attack!" : "Defence";
        }
    }

}
