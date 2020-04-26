using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private int life = 100;
    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private int mouseSensitivity = 10;
    private Rigidbody rb;
    [SerializeField]
    private Camera characterCamera;
    private Dictionary<string, Item> inventory;
    private float Hvalue = 0;
    private float Vvalue = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.inventory = new Dictionary<string, Item>();
        Cursor.lockState = CursorLockMode.Locked;
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        checkLockCursor();
        rotateCamera();
    }

    private void FixedUpdate() {
        move();
    }

    private void checkRaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.characterCamera.transform.position, this.characterCamera.transform.forward * 5, out hit, 8))
        {
            GameObject functionalObject = hit.collider.gameObject;
            Debug.Log(functionalObject.ToString());
            if (functionalObject.CompareTag("Funcional"))
            {
                Debug.Log("Objeto Funcional");
                Usable objectUsable = functionalObject.GetComponentInParent<Usable>();
                objectUsable.use();
            }
        }
    }

    private void checkInput()
    {
        Hvalue = Input.GetAxis("Horizontal");
        Vvalue = Input.GetAxis("Vertical");
        //Debug.Log("X:" + Hvalue.ToString() + "," + "Y:" + Vvalue.ToString());
        if (Vvalue == 0 && Hvalue == 0)
        {
            rb.MovePosition(rb.position);
        }
        if (Input.GetButtonDown("Use"))
        {
            checkRaycastHit();
        }
    }

    private void move()   {
        if (Hvalue != 0)
        {
            if (Hvalue > 0.5)//right
            {
                //Debug.Log("Right");
                rb.MovePosition(rb.position + (transform.right * moveSpeed) * Time.deltaTime);

            }
            else if (Hvalue < -0.5)//left
            {
                //Debug.Log("Left");
                rb.MovePosition(rb.position + (-transform.right * moveSpeed) * Time.deltaTime);
            }
        }
        if (Vvalue != 0)
        {
            if (Vvalue > 0.5)//front
            {
                //Debug.Log("Front");
                rb.MovePosition(rb.position + (transform.forward * moveSpeed) * Time.deltaTime);
            }
            else if (Vvalue < -0.5)//back
            {
                //Debug.Log("Back");
                rb.MovePosition(rb.position + (-transform.forward * moveSpeed) * Time.deltaTime);
            }
        }
    }

    private void checkLockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void rotateCamera()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            //Debug.Log(this.characterCamera.transform.rotation.eulerAngles.x.ToString());
            if (mouseX != 0)
            {
                this.transform.Rotate(new Vector3(0, (mouseX * this.mouseSensitivity), 0));
            }
            if (mouseY != 0)
            {
                Vector3 tmpRotation = this.characterCamera.transform.rotation.eulerAngles;
                this.characterCamera.transform.Rotate((-mouseY * this.mouseSensitivity), 0, 0);
                if (tmpRotation.x > 60 && tmpRotation.x < 90)
                {
                    this.characterCamera.transform.rotation = Quaternion.Euler(new Vector3(60, tmpRotation.y, tmpRotation.z));
                }else if (tmpRotation.x < 290 && tmpRotation.x > 90)
                {
                    this.characterCamera.transform.rotation = Quaternion.Euler(new Vector3(290, tmpRotation.y, tmpRotation.z));
                }
            }
        }
    }
    public void addItemToInventory(Item item)
    {
        this.inventory.Add(item.getItemName(), item);
    }
    public void deleteItemFromInventory(Item item)
    {
        if (this.inventory.ContainsKey(item.getItemName()))
        {
            this.inventory.Remove(item.getItemName());
        }
    }
    public void dropItemFromInventory(Item item)
    {
        if (this.inventory.ContainsKey(item.getItemName()))
        {
            this.inventory.Remove(item.getItemName());
            item.dropItem();
        }
    }


}
