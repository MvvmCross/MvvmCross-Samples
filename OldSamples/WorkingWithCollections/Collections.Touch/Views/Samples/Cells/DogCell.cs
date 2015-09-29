using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Collections.Core.ViewModels.Samples.ListItems;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Collections.Touch
{
    [Register("DogCell")]
    public partial class DogCell : MvxTableViewCell
    {
        private MvxImageViewLoader _imageHelper;

        public DogCell()
        {
            InitialiseImageHelper();
            InitialiseBindings();
        }

        public DogCell(IntPtr handle)
            : base(handle)
        {
            InitialiseImageHelper();
            InitialiseBindings();
        }

        public string Name
        {
            get { return MainLabel.Text; }
            set { MainLabel.Text = value; }
        }

        public string ImageUrl
        {
            get { return _imageHelper.ImageUrl; }
            set { _imageHelper.ImageUrl = value; }
        }

        private void InitialiseBindings()
        {
            // this is equivalent to:
            //private const string BindingText = "Name Name;ImageUrl ImageUrl";
            this.DelayBind(() =>
                {
                    this.CreateBinding().For((cell) => cell.Name).To((Dog dog) => dog.Name).Apply();
                    this.CreateBinding().For((cell) => cell.ImageUrl).To((Dog dog) => dog.ImageUrl).Apply();
                });
        }

        public static float GetCellHeight()
        {
            return 120f;
        }

        private void InitialiseImageHelper()
        {
            _imageHelper = new MvxImageViewLoader(() => DogImageView);
        }
    }
}