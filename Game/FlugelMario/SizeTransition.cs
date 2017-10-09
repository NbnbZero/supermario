using SuperMario.Interfaces;

namespace SuperMario
{
    public static class Transition
    {
        public static void ChangeMario(InputState state, IMarioState marioState)
        {
            if (marioState != null)
            {
                switch (state)
                {
                    case InputState.MakeSmall:
                        marioState.ChangeSizeToSmall();
                        break;
                    case InputState.MakeBig:
                        marioState.ChangeSizeToBig();
                        break;
                    case InputState.MakeFire:
                        marioState.ChangeFireMode();
                        break;
                    case InputState.MakeDead:
                        marioState.Terminated();
                        break;
                    default:
                        marioState.BeIdle();
                        break;
                }
            }
        }

        public static void ChangeBlock(InputState state, IBlockState blockState)
        {
            if (blockState != null)
            {
                switch (state)
                {
                    case InputState.BumpUp:
                        blockState.ChangeToUsedBlock();
                        break;
                    case InputState.ChangeToUsed:
                        blockState.ChangeToUsedBlock();
                        break;
                }
            }
        }
    }
}