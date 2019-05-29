using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2605___Elevator_Enum_
{
    class Elevator
    {
        private ElevatorState _elevatorState;
        private int _currentFloor;
        private int _goToFloor;

        public Elevator(ElevatorState elevatorState, int currentFloor)
        {
            _elevatorState = elevatorState;
            _currentFloor = currentFloor;
        }

        // Change Floor.
        public bool GoToFloor(int newFloor)
        {
            _goToFloor = newFloor;
            if (_elevatorState == ElevatorState.RESTING)
            {
                if (_currentFloor == newFloor)
                {
                    Console.WriteLine("Same Floor");
                    _elevatorState = ElevatorState.OPEN_DOORS;
                }
                if (_currentFloor < newFloor)
                {
                    Console.WriteLine("Need Go Up");
                    _elevatorState = ElevatorState.GOING_UP;
                }
                if (_currentFloor > newFloor)
                {
                    Console.WriteLine("Need Go Down");
                    _elevatorState = ElevatorState.GOING_DOWN;
                }
                return true;
            }
            Console.WriteLine("Elevator In Other Action Right Now.");
            return false;
        }
        private void OnReachedFloor()
        {

        }

        //Floor Reached.
        public void FloorReached(object sender, EventArgs e)
        {
            if (_elevatorState == ElevatorState.OPEN_DOORS || _elevatorState == ElevatorState.RESTING)
            {
                Console.WriteLine($"The Elevator Already In {_currentFloor} Floor, Or Doors Are Already Open");
            }
            else
            {
                _elevatorState = ElevatorState.OPEN_DOORS;
                _currentFloor = _goToFloor;
                Console.WriteLine($"The Elevator Reach Floor {_currentFloor}");
            }

        }

        //Close Doors.
        public bool CloseDoor()
        {
            if(_elevatorState == ElevatorState.OPEN_DOORS)
            {
                Console.WriteLine($"Elevator Closing The Doors");
                _elevatorState = ElevatorState.RESTING;
                return true;
            }
            return false;
        }
    }
}
