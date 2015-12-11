using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public EColor eColor = new EColor();
    [SerializeField]
    Transform origin;

	bool dragging=false; //for local dragging
	bool locked; //use along with WorldGameManager if item is under clue

    public delegate void ActionInsert(Transform parent, Transform dis);
    public delegate void ActionBeginDrag(GameObject obj);
	public delegate void ActionDrop();
	public ActionDrop OnDrop;
    public static event ActionInsert OnInsert;
    public static event ActionBeginDrag OnBeginDrag;
	//public event delDrop OnDrop;

	#region
	public Transform Origin{
		set{origin = value;}
		get{return origin;}
	}

    public bool Locked
    {
        set { locked = value; }
        get { return locked; }
    }

    #endregion

    void Start () {
		origin = transform.parent;
		//InventoryManager.ins.items.Add(this.gameObject);

	}

 
    public void SetParentToParent()
    {
        origin = transform.parent;
    }

	
	public void Drag()
	{
		if(dragging){
            if (InventoryManager.ins.eDragDir == EDragDirection.all)
            {
                transform.position = Input.mousePosition;
            }
            else if (InventoryManager.ins.eDragDir == EDragDirection.x)
            {
                transform.SetXPos(Input.mousePosition.x);
            }
            else {
                transform.SetXPos(Input.mousePosition.y);
            }
		}

	}

	public void Drop()
	{
       
        if (InventoryManager.ins.IsReparented(this.gameObject)) {
            //reparent happened
            origin = transform.parent;
            if (OnDrop != null) {
                OnDrop();
                transform.SetLocalZRot(transform.parent.GetLocalZRot());   
            }
            if (OnInsert != null)
            {
                //print("webzen");
                OnInsert(transform.parent, this.transform);
            }
            else {
                //print("NO INSERT");
            }
        }
        else if (InventoryManager.ins.IsSwapped(this.gameObject))
        {
            if (OnDrop != null)
            {
                OnDrop();
            }
        }
        else {
            transform.SetParent(origin);
            transform.SetLocalXPos(0);
            transform.SetLocalYPos(0);
            //print("wow");
        }
     
        dragging  =false;
		InventoryManager.ins.Dragging = false;

	}

	public void Begin()
	{
        InventoryManager.ins.TransItemRecentSlot = origin;
        if (!InventoryManager.ins.Dragging && !locked){
            //print("drag begin");
            if (OnBeginDrag != null)
            {
                OnBeginDrag(gameObject);
            }
			//remove object from its slot
			transform.SetParent(InventoryManager.ins.transform);
			InventoryManager.ins.Dragging = true;
			InventoryManager.ins.DraggedObject = this.gameObject;
			dragging = true;
		}
	}

    
}
