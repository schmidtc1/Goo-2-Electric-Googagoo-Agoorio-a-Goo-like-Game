using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerCJ : MonoBehaviour
{
    public GameObject SpellText;
    public GameObject HealText;
    public GameObject WeakenText;
    public GameObject AttackText;
    public GameObject SpellText2;
    public GameObject HealText2;
    public GameObject WeakenText2;
    public GameObject AttackText2;

    public int attackVal;
    public int spellVal;
    public int healVal;
    public int weakenVal;

    public int WeakenScore;
    public int HealScore;
    public int AttackScore;
    public int SpellScore;

    public GameObject deckText;
    public GameObject gooHealthText;
    public GameObject scientistHealthText;
    public GameObject scientistBurnText;
    public GameObject scientistAttackText;

    public Scientist currScientist;
    public List<Cards> deck = new List<Cards>();
    public Cards[] hand;
    public Transform[] cardSlots;
    public bool[] emptyCardSlots;
    public int scientistBurn;
    public List<Cards> discard = new List<Cards>();
    public int gooHealth;

    public void DrawCard()
    {
        if(deck.Count > 0)
        {
            Cards drawnCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < emptyCardSlots.Length; i++)
            {
                if (emptyCardSlots[i] == true)
                {
                    drawnCard.gameObject.SetActive(true);
                    drawnCard.transform.position = cardSlots[i].position;
                    drawnCard.position = i;
                    hand[i] = drawnCard;
                    emptyCardSlots[i] = false;
                    deck.Remove(drawnCard);
                    return;
                }
            }
        }
        if(deck.Count == 0)
        {
            int numDiscard = discard.Count;
            for(int i = numDiscard-1; i >-1; i--)
            {
                deck.Add(discard[i]);
                discard.Remove(discard[i]);
            }
            DrawCard();
        }
    }

    public void PlayCard(Cards playedCard)
    {
        emptyCardSlots[playedCard.position] = true;
        playedCard.gameObject.SetActive(false);
        discard.Add(playedCard);
        if(playedCard.name == "WeakenCard")
        {
            currScientist.attack -= weakenVal;
            if(currScientist.attack < 0)
            {
                currScientist.attack = 0;
            }
        }
        if(playedCard.name == "SpellCard")
        {
            scientistBurn += spellVal;
        }
        if(playedCard.name == "AttackCard")
        {
            currScientist.currHealth -= attackVal;
        }
        if(playedCard.name == "HealCard")
        {
            gooHealth += healVal;
            if(gooHealth > 100)
            {
                gooHealth = 100;
            }
        }
    }

    public void startNewTurn()
    {
        for(int i = 0; i < 3; i++)
        {
            if (emptyCardSlots[i] == false)
            {
                discard.Add(hand[i]);
                hand[i].gameObject.SetActive(false);
                emptyCardSlots[i] = true;
            }
        }
        currScientist.currHealth -= scientistBurn;
        scientistBurn--;
        if(scientistBurn < 0)
        {
            scientistBurn = 0;
        }
        if (currScientist.currHealth <= 0)
        {
            currScientist.num++;
            scientistBurn = 0;
            if(currScientist.num == 2)
            {
                currScientist.maxHealth = 75;
                currScientist.currHealth = 75;
                currScientist.maxAttack = 15;
            }
            if (currScientist.num == 3)
            {
                currScientist.maxHealth = 100;
                currScientist.currHealth = 100;
                currScientist.maxAttack = 20;
            }
            if (currScientist.num == 4)
            {
                currScientist.maxHealth = 125;
                currScientist.currHealth = 125;
                currScientist.maxAttack = 25;
            }
            if (currScientist.num == 5)
            {
                currScientist.maxHealth = 150;
                currScientist.currHealth = 150;
                currScientist.maxAttack = 30;
            }
            if(currScientist.num == 6)
            {
                SceneManager.LoadScene("Nature2");
            }
        }
        else
        {
            gooHealth -= currScientist.attack;
            if(gooHealth <= 0)
            {
                Application.Quit();
            }
        }
        currScientist.attack = currScientist.maxAttack;
        DrawCard();
        DrawCard();
        DrawCard();
    }
    // Start is called before the first frame update
    void Start()
    {
        WeakenScore = GetTotalScores.weakScore;
        HealScore = GetTotalScores.healScore;
        SpellScore = GetTotalScores.spellScore;
        AttackScore = GetTotalScores.attackScore;
        weakenVal = 3 * 5 * (WeakenScore / 15);
        healVal = 2 * 5 * (HealScore / 200);
        spellVal = 1 * 5 * (SpellScore / 2);
        attackVal = 2 * 5 * (AttackScore / 3);

        TextMeshPro weakenText = WeakenText.GetComponent<TextMeshPro>();
        weakenText.text = "Prevent " + weakenVal + " Damage";
        TextMeshPro weaken2Text = WeakenText2.GetComponent<TextMeshPro>();
        weaken2Text.text = "Prevent " + weakenVal + " Damage";
        TextMeshPro spell2Text = SpellText2.GetComponent<TextMeshPro>();
        spell2Text.text = "Apply " + spellVal + " Burn";
        TextMeshPro spellText = SpellText.GetComponent<TextMeshPro>();
        spellText.text = "Apply " + spellVal + " Burn";
        TextMeshPro attackText = AttackText.GetComponent<TextMeshPro>();
        attackText.text = "Deal " + attackVal + " Damage";
        TextMeshPro attack2Text = AttackText2.GetComponent<TextMeshPro>();
        attack2Text.text = "Deal " + attackVal + " Damage";
        TextMeshPro healText = HealText.GetComponent<TextMeshPro>();
        healText.text = "Restore " + healVal + " Health";
        TextMeshPro heal2Text = HealText2.GetComponent<TextMeshPro>();
        heal2Text.text = "Restore " + healVal + " Health";

        gooHealth = 110;
        scientistBurn = 0;
        currScientist.num = 1;
        startNewTurn();
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro deckText_ = deckText.GetComponent<TextMeshPro>();
        deckText_.text = deck.Count.ToString();
        TextMeshPro gooHealthText_ = gooHealthText.GetComponent<TextMeshPro>();
        gooHealthText_.text = gooHealth.ToString() + "/100";
        TextMeshPro scientistAttackText_ = scientistAttackText.GetComponent<TextMeshPro>();
        scientistAttackText_.text = currScientist.attack.ToString();
        TextMeshPro scientistBurnText_ = scientistBurnText.GetComponent<TextMeshPro>();
        scientistBurnText_.text = scientistBurn.ToString();
        TextMeshPro scientistHealthText_ = scientistHealthText.GetComponent<TextMeshPro>();
        scientistHealthText_.text = currScientist.currHealth.ToString() + "/" + currScientist.maxHealth.ToString();
    }
}
