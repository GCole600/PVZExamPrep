using UnityEngine;

namespace CommandPattern
{
    public class MoveDown : Command
    {
        private DaveController _controller;

        public MoveDown(DaveController controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.Move(DaveController.Direction.Down);
        }
    }
}
