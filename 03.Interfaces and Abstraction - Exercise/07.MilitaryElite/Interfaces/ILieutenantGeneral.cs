using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Privates { get; }
        public void AddPrivate(IPrivate @private);
    }
}
