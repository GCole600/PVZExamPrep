using UnityEngine;

namespace CommandPattern
{
    public class MoveUp : Command
    {
        private DaveController _controller;

        public MoveUp(DaveController controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.Move(DaveController.Direction.Up);
        }
    }
}
