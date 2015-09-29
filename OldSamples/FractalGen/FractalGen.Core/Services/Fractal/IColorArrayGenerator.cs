using System.Collections.Generic;
using Cirrious.CrossCore.UI;

namespace FractalGen.Core.Services.Fractal
{
    public interface IColorArrayGenerator
    {
        List<MvxColor> NextColorArray();
    }
}