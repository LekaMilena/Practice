using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int hp;
    [SerializeField] private int attack;
    private int selectedBodyPart;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int SelectedBodyPart
    {
        get { return selectedBodyPart; }
        set { selectedBodyPart = value; }
    }
    public int Attack
    {
        get { return attack; }
    }

    public void SelectBodyPart(int partIdx)
    {
        selectedBodyPart = partIdx;
    }

    public void AttackAtPart(int partIdx, int strength)
    {
        if(selectedBodyPart == partIdx)
            return;

        hp -= attack;
        if (hp < 0)
            hp = 0;
    }
}
