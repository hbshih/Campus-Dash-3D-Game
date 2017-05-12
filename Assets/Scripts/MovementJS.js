static var speed : int = 5;
var anim : Animator;

function Start() {
	anim = GetComponent(Animator);
} 
function Update () {
    if (Input.GetKey (KeyCode.UpArrow)) {
    	transform.Translate (Vector3(0,0,1) * Time.deltaTime*speed);
    	anim.SetFloat("Speed_f", 10.0);
    } 
    if (Input.GetKey (KeyCode.DownArrow)) {
    	transform.Translate (Vector3(0,0,-1) * Time.deltaTime*speed);
    	anim.SetFloat("Speed_f", 10.0);
    }
    if (Input.GetKey (KeyCode.LeftArrow)) {
    	transform.Translate (Vector3(-1,0,0) * Time.deltaTime*speed);
    	anim.SetFloat("Speed_f", 10.0);
    }
    if (Input.GetKey (KeyCode.RightArrow)) {
    	transform.Translate (Vector3(1,0,0) * Time.deltaTime*speed);
    	anim.SetFloat("Speed_f", 10.0);
    }
   
 }