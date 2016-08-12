using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.Utility;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class SettingsView : BaseView
    {
        private UIPickerView _currencyPickerView;
        private static readonly int TextFieldMargin = 10;
        public static readonly int ArrowWidth = 14;
        private MvxPickerViewModel _currencyPickerViewModel;

        protected SettingsViewModel SettingsViewModel => ViewModel as SettingsViewModel;

        public SettingsView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();

            var set = this.CreateBindingSet<SettingsView, SettingsViewModel>();
            CreateCurrencyBindings(set);

            set.Bind(VisitSiteButton).To(vm => vm.HelpCommand);
            set.Bind(_currencyPickerViewModel).For(b => b.SelectedChangedCommand).To(vm => vm.SwitchCurrencyCommand);
            set.Bind(AboutTextView).To(vm => vm.AboutContent);

            CustomizeTextField(CurrencyTextField, _currencyPickerView);
            set.Apply();
        }

        private void CustomizeTextField(UITextField textField, UIPickerView pickerView)
        {
            textField.TintColor = UIColor.Clear;

            var leftPaddingView = new UIView(
                new CGRect(0, 0, TextFieldMargin, textField.Frame.Height));
            textField.LeftView = leftPaddingView;
            textField.LeftViewMode = UITextFieldViewMode.Always;

            var arrowImageView = new UIImageView(new CGRect(0, 0,
                ArrowWidth + TextFieldMargin, textField.Frame.Height))
            {
                Image = UIImage.FromBundle("arrow-down.png"),
                ContentMode = UIViewContentMode.Left
            };
            textField.RightView = arrowImageView;
            textField.RightViewMode = UITextFieldViewMode.UnlessEditing;

            textField.InputView = pickerView;

            var toolbar = CreateToolbar();

            textField.InputAccessoryView = toolbar;

            textField.Layer.BorderColor = MyTrainsColors.BorderColor.CGColor;
            textField.Layer.BorderWidth = 1;
        }

        private UIToolbar CreateToolbar()
        {
            var toolbar = new UIToolbar(new CGRect(0, 0, 320, 44));
            var done = new UIBarButtonItem("OK", UIBarButtonItemStyle.Bordered, (sender, e) =>
            {
                CurrencyTextField.ResignFirstResponder();
            })
            {
                TintColor = MyTrainsColors.AccentColor
            };
            toolbar.SetItems(new[] { done }, false);
            return toolbar;
        }


        private void CreateCurrencyBindings(MvxFluentBindingDescriptionSet<SettingsView, SettingsViewModel> set)
        {
            set.Bind(CurrencyTextField).To(vm => vm.ActiveCurrency).OneWay();
            _currencyPickerView = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            _currencyPickerViewModel = new MvxPickerViewModel(_currencyPickerView);
            _currencyPickerView.Model = _currencyPickerViewModel;
            set.Bind(_currencyPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Currencies).OneWay();
            set.Bind(_currencyPickerViewModel).For(p => p.SelectedItem).To(vm => vm.ActiveCurrency).OneWayToSource();
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}