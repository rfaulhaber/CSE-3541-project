////////////////////////////////////////////////////////////////////////////////
//���������� �������� � �������
var rotationMouseSpeed = 0.5; 			//�������� �������� ������
var space_ship : Transform; 				//�������
var speeds_count = 10; 					//���-�� ���������
var agility = 30; 								//�������� �������� ������� �� �������
var dist_fr_ship = 2.0; 						//��������� ��������� ������ �� �������
var space_ship_rotate_speed = 2.0; 	//�������� �������� �������� �� ��� Z �������

var ship_ctrl : ship_control_v2;

var skin:GUISkin;

//���������� �����
private var alternative_control = false;
///////////////////////////////////////////////////////////////////////////////

function FixedUpdate () {
	if(Input.GetKeyDown("space")) {
		if(!alternative_control) {
			alternative_control = true;
		} else {
			alternative_control = false;
		}
	}

	if (!alternative_control) {
		MousePosition = Input.mousePosition;
		MousePosition.x = (Screen.height/2) - Input.mousePosition.y;
		MousePosition.y = -(Screen.width/2) + Input.mousePosition.x;
		transform.Rotate(MousePosition * Time.deltaTime * rotationMouseSpeed, Space.Self);
	}
}

function Update () {

	ship_ctrl = space_ship.GetComponent(ship_control_v2);
	
	if (!alternative_control) {
		if (Input.GetKey ("d")) 
		{
			transform.Rotate(0,0,-space_ship_rotate_speed);
		}

		if (Input.GetKey ("a")) 
		{
			transform.Rotate(0,0,space_ship_rotate_speed);
		}
	}
	
	if (Input.GetKeyDown ("q")) {
		transform.LookAt(GameObject.Find("Star").transform);
	}
}

function LateUpdate () {
	space_ship.transform.rotation = Quaternion.Lerp (space_ship.rotation, transform.rotation,Time.deltaTime * agility);
	var position = transform.rotation * Vector3(0.0, 1.0, -dist_fr_ship) + space_ship.position; //������ ��������� ������ ������������ �������, ������ ������� �� ��������.
	transform.position = position;
}

function OnGUI() {
    if (skin != null) {
        GUI.skin = skin;
    }
	percent_speed = Mathf.Floor(ship_ctrl.curShipSpeed / speeds_count * 100) + 1;
	GUI.Label (Rect (10, 20, 170, 20), "Speed:"+""+percent_speed+"/100%"); //������� �������� � ���������
	GUI.Label (Rect (10, 40, 170, 20), ""+(Mathf.Floor(ship_ctrl.curShipSpeed) +1)+"/"+speeds_count); //���������� ������� �������� � ���-�� ���������.
}
