using UnityEngine;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        private DaveController _daveController;
        private Command _buttonW, _buttonS, _buttonLeftClick;        
        void Start()
        {
            _daveController = FindObjectOfType<DaveController>();

            _buttonW = new MoveUp(_daveController);
            _buttonS = new MoveDown(_daveController);
            _buttonLeftClick = new Shoot(_daveController);
        }
        
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.W)) 
                _buttonW.Execute();
                
            if (Input.GetKeyUp(KeyCode.S)) 
                _buttonS.Execute();  
            
            if (Input.GetKeyUp(KeyCode.Mouse0)) 
                _buttonLeftClick.Execute();  
        } 
    }
}