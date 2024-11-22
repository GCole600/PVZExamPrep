using UnityEngine;

namespace CommandPattern
{
    public class Shoot : Command
    {
        private DaveController _controller;

        public Shoot(DaveController controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.Shoot();
        }
    }
}
