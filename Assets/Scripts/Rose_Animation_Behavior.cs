using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose_Animation_Behavior : MonoBehaviour
{
    //Gameobject vars
    private Animator rose_animator;

    //number vars
    [SerializeField] private float animation_progress = 0f;
    [SerializeField] private float animation_amount = 0f;

    void Awake()
    {
        //find rose_animator
        rose_animator = GameObject.FindWithTag("Rose_Tag").GetComponent<Animator>();
    }

    void Start()
    {
        //
    }

    void Update()
    {
        //if animation_amount is greater than zero,...
        if (animation_amount > 0f)
        {
            //make bloom by time
            Make_Bloom(Time.deltaTime);

            //decrement animation_amount
            animation_amount -= Time.deltaTime;
        }
    }

    public void Make_Bloom(float bloom_amount)
    {
        //increment animation_progress
        animation_progress += bloom_amount;

        //play bloom animation, from the base layer (0), and starting from time equal to animation_progress
        rose_animator.Play("Base Layer.Bloom", 0, animation_progress);
    }

    public void Add_To_Animation_Amount(float amount)
    {
        animation_amount += amount;
    }
}
