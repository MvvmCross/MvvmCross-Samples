using System;
namespace StarWarsSample.Core.MvxResults
{
    public class MvxDestructionResult<TEntity>
    {
        public TEntity Entity { get; set; }

        public bool Destroyed { get; set; }
    }
}
