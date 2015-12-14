using UnityEngine;
using System.Collections;

public class ExampleScene : MonoBehaviour {

	private Vector3 					 m_vRotationDirection 	= new Vector3( 0.0f, 0.0f, 0.0f );
	private SwipeControl.SWIPE_DIRECTION m_enCurrentDirection;
	private float 						 m_fSpeed				= 500.0f;
	public  GameObject					 m_goSphere;

	void Start () {
		GameObject.Find( "SwipeControl" ).GetComponent<SwipeControl>().SetMethodToCall( MyCallbackMethod );
	}
	
	void Update () {
		m_fSpeed *= 0.95f;
		m_goSphere.transform.Rotate( m_vRotationDirection * Time.deltaTime * m_fSpeed, Space.World );
	}

	void OnGUI() {
		//GUI.Label( new Rect( 0.0f, 0.0f, 200.0f, 200.0f ), m_enCurrentDirection.ToString() );
		GUI.Box( new Rect( Screen.width * 0.5f - 125.0f, 5.0f, 250.0f, 30.0f ), m_enCurrentDirection.ToString() );
	}

	private void MyCallbackMethod( SwipeControl.SWIPE_DIRECTION iDirection ) {

		m_enCurrentDirection = iDirection;

		//this.transform.rotation = Quaternion.identity;
		m_fSpeed = 600.0f;

		switch ( iDirection ) {
		case SwipeControl.SWIPE_DIRECTION.SD_UP:
			m_vRotationDirection = new Vector3( 1.0f, 0.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_DOWN:
			m_vRotationDirection = new Vector3( -1.0f, 0.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_LEFT:
			m_vRotationDirection = new Vector3( 0.0f, 1.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
			m_vRotationDirection = new Vector3( 0.0f, -1.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_DOWN_LEFT:
			m_vRotationDirection = new Vector3( -1.0f, 1.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_DOWN_RIGHT:
			m_vRotationDirection = new Vector3( -1.0f, -1.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_UP_LEFT:
			m_vRotationDirection = new Vector3( 1.0f, 1.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_UP_RIGHT:
			m_vRotationDirection = new Vector3( 1.0f, -1.0f, 0.0f );
			break;
		case SwipeControl.SWIPE_DIRECTION.SD_TOUCH:
			m_vRotationDirection = new Vector3( 0.0f, 0.0f, 0.0f );
			break;
		}
	}
}
