using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ColorButtonClick : MonoBehaviour, IPointerClickHandler {

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{				
		if(ColorButton.activeButton == null)
		{
			ColorButton.activeButton = this.transform.parent;
			ColorButton.activeButton.GetComponent<ColorButton>().myAnimator.enabled = true;
<<<<<<< HEAD
			ColorButton.activeButton.GetComponent<ColorButton>().RawImageAlpha(new Color32(255, 255, 255, 255));

            Colors.selectedColor = ColorButton.activeButton.GetComponent<ColorButton>().ButtonColor;
            Colors.instance.SelectedColor();            
=======
			ColorButton.activeButton.GetComponent<ColorButton>().RawImageAlpha(new Color32(255, 255, 255, 255));

            Colors.selectedColor = ColorButton.activeButton.GetComponent<ColorButton>().ButtonColor;
            Colors.instance.SelectedColor();            
>>>>>>> master
        }
		else
		{
			ColorButton.activeButton.GetComponent<ColorButton>().myAnimator.enabled= false;
			ColorButton.activeButton.GetComponent<ColorButton>().RawImageAlpha(new Color32(255, 255, 255, 0));
			ColorButton.activeButton = this.transform.parent;
			ColorButton.activeButton.GetComponent<ColorButton>().myAnimator.enabled = true;
<<<<<<< HEAD
			ColorButton.activeButton.GetComponent<ColorButton>().RawImageAlpha(new Color32(255, 255, 255, 255));

            Colors.selectedColor = ColorButton.activeButton.GetComponent<ColorButton>().ButtonColor;
            Colors.instance.SelectedColor();            
=======
			ColorButton.activeButton.GetComponent<ColorButton>().RawImageAlpha(new Color32(255, 255, 255, 255));

            Colors.selectedColor = ColorButton.activeButton.GetComponent<ColorButton>().ButtonColor;
            Colors.instance.SelectedColor();            
>>>>>>> master
        }
	}
	#endregion
}
