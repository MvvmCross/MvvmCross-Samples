using System.Collections.Generic;
using MvvmCross.Platform.UI;

namespace FractalGen.Core.Services.Fractal
{
    public interface IColorArrayGenerator
    {
        List<MvxColor> NextColorArray();
    }
}