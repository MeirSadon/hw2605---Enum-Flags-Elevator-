using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace hw2605___Elevator_Enum_
{
    class Program
    {
        static public event EventHandler<EventArgs> TheFloorReached;

        static void Main(string[] args)
        {
        Elevator e = new Elevator(ElevatorState.RESTING, 1);

        TheFloorReached += e.FloorReached;
            if (e.GoToFloor(3))
            {
                Thread.Sleep(2000);
                TheFloorReached.Invoke(null, EventArgs.Empty);
            }
            if (e.GoToFloor(3))
            {
                Thread.Sleep(2000);
                TheFloorReached.Invoke(null, EventArgs.Empty);
            }
            e.CloseDoor();
            if (e.GoToFloor(3))
            {
                Thread.Sleep(2000);
                TheFloorReached.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
