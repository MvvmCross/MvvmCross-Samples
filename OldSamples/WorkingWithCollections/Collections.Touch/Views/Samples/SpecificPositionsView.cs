using Collections.Core.ViewModels.Samples.SpecificPositions;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Collections.Touch
{
    public partial class SpecificPositionsView : MvxViewController
    {
        private MvxImageViewLoader _felixImageHelper;
        private MvxImageViewLoader _secondImageHelper;

        public SpecificPositionsView()
            : base("SpecificPositionsView", null)
        {
            Title = "Specific Positions";
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitialiseImageHelpers();

            // old syntax
            //this.AddBindings(
            //	new Dictionary<object, string>()
            //	{
            //		{ this._secondImageHelper, "ImageUrl Kittens[2].ImageUrl" },
            //		{ this.SecondLabel, "Text Kittens[2].Name" },
            //		{ this._felixImageHelper, "ImageUrl Lookup[Felix].ImageUrl" },
            //		{ this.FelixLabel, "Text Lookup[Felix].Name" },
            //	});

            // new  syntax:
            this.CreateBinding(_secondImageHelper).To((SpecificPositionsViewModel vm) => vm.Kittens[2].ImageUrl).Apply();
            this.CreateBinding(SecondLabel).To((SpecificPositionsViewModel vm) => vm.Kittens[2].Name).Apply();
            this.CreateBinding(_felixImageHelper)
                .To((SpecificPositionsViewModel vm) => vm.Lookup["Felix"].ImageUrl)
                .Apply();
            this.CreateBinding(FelixLabel).To((SpecificPositionsViewModel vm) => vm.Lookup["Felix"].Name).Apply();
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();

            // Clear any references to subviews of the main view in order to
            // allow the Garbage Collector to collect them sooner.
            //
            // e.g. myOutlet.Dispose (); myOutlet = null;

            ReleaseDesignerOutlets();
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
        }

        private void InitialiseImageHelpers()
        {
            _secondImageHelper = new MvxImageViewLoader(() => SecondImageView);
            _felixImageHelper = new MvxImageViewLoader(() => FelixImageView);
        }
    }
}