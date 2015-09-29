using BestSellers.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using System.Collections.Generic;

namespace BestSellers.Touch.Views
{
    public partial class BookView : MvxViewController
    {
        private MvxImageViewLoader _imageHelper;

        public new BookViewModel ViewModel
        {
            get { return base.ViewModel as BookViewModel; }
            set { base.ViewModel = value; }
        }

        public BookView() : base("BookView", null)
        {
            _imageHelper = new MvxImageViewLoader(() => BookImage);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.AddBindings(
                new Dictionary<object, string>()
                    {
                        { TitleLabel, "Text Book.Title" },
                        { AuthorLabel, "Text Book.Author" },
                        { DescriptionLabel, "Text Book.Description" },
                        { _imageHelper, "ImageUrl Book.AmazonImageUrl" },
                        { ActivityIndicator, "Visibility IsLoading,Converter=Visibility" },
                    });
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            ReleaseDesignerOutlets();
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
        }
    }
}