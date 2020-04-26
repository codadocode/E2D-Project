using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : UsableGeneric
{
    [SerializeField]
    private bool opened = true;
    [SerializeField]
    private bool locked = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIsOpened();
    }

    private void checkIsOpened()
    {
        bool tmpOpened = this.animator.GetBool("opened");
        if (tmpOpened != this.opened)
        {
            animator.SetBool("opened", this.opened);
        }
    }

    public override void use()
    {
        if (!this.locked)
        {
            if (this.opened)
            {
                this.opened = false;
                this.animator.SetBool("opened", this.opened);
            }
            else
            {
                this.opened = true;
                this.animator.SetBool("opened", this.opened);
            }
        }
    }
}
