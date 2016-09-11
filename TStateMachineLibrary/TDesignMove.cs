namespace TStateMachineLibrary
{
    public struct TDesignMove
    {
        readonly int designMove;

        public TDesignMove(int value)
        {
            this.designMove = value;
        }

        public static implicit operator int(TDesignMove value)
        {
            return value.designMove;
        }

        public static implicit operator TDesignMove(int value)
        {
            return new TDesignMove(value);
        }

        public const int Source = 0;
        public const int FirstHandle = 1;
        public const int Offset = 2;
        public const int LastHandle = 3;
        public const int Destination = 4;
        public const int None = 5;
    }

    //public enum TDesignMove
    //{
    //    Source,
    //    FirstHandle,
    //    Offset,
    //    LastHandle,
    //    Destination,
    //    None
    //}//end TDesignMove
}


