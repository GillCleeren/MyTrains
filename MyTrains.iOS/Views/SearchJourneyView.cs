using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.Controls;
using MyTrains.iOS.Utility;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class SearchJourneyView : BaseView
    {
        private UIPickerView _fromCityTextPicker;
        private UIPickerView _toCityTextPicker;
        private UIPickerView _depatureTimeTextPicker;

        private const int TextFieldMargin = 10;
        public static readonly int ArrowWidth = 14;

        protected SearchJourneyViewModel SearchJourneyViewModel => ViewModel as SearchJourneyViewModel;

        public SearchJourneyView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();

            var set = this.CreateBindingSet<SearchJourneyView, SearchJourneyViewModel>();

            set.Bind(searchButton).To(vm => vm.SearchCommand);

            CreateFromCityBinding(set);
            CreateToCityBinding(set);
            CreateDepartureBinding(set);

            set.Apply();

            UpdateUi();

            AddPickerToTextField(fromCityTextField, _fromCityTextPicker);
            AddPickerToTextField(toCityTextField, _toCityTextPicker);
            AddPickerToTextField(depatureTimeTextField, _depatureTimeTextPicker);
        }

        private void AddPickerToTextField(UITextField textField, UIPickerView pickerView)
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
            textField.Layer.CornerRadius = 4;
        }

        private void CreateFromCityBinding(MvxFluentBindingDescriptionSet<SearchJourneyView, SearchJourneyViewModel> set)
        {
            set.Bind(fromCityTextField).To(vm => vm.SelectedFromCity).OneWay();
            _fromCityTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var fromPickerViewModel = new MvxPickerViewModel(_fromCityTextPicker);
            _fromCityTextPicker.Model = fromPickerViewModel;
            set.Bind(fromPickerViewModel).For(p => p.ItemsSource).To(vm => vm.FromCities).OneWay();
            set.Bind(fromPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedFromCity).OneWayToSource();
        }

        private void CreateToCityBinding(MvxFluentBindingDescriptionSet<SearchJourneyView, SearchJourneyViewModel> set)
        {
            set.Bind(toCityTextField).To(vm => vm.SelectedToCity).OneWay();
            _toCityTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var toCityPickerViewModel = new MvxPickerViewModel(_toCityTextPicker);
            _toCityTextPicker.Model = toCityPickerViewModel;
            set.Bind(toCityPickerViewModel).For(p => p.ItemsSource).To(vm => vm.ToCities).OneWay();
            set.Bind(toCityPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedToCity).OneWayToSource();
        }

        private void CreateDepartureBinding(MvxFluentBindingDescriptionSet<SearchJourneyView, SearchJourneyViewModel> set)
        {
            set.Bind(depatureTimeTextField).To(vm => vm.SelectedHour).OneWay();
            _depatureTimeTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var departurePickerViewModel = new MvxPickerViewModel(_depatureTimeTextPicker);
            _depatureTimeTextPicker.Model = departurePickerViewModel;
            set.Bind(departurePickerViewModel).For(p => p.ItemsSource).To(vm => vm.PossibleTimes).OneWay();
            set.Bind(departurePickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedHour).OneWayToSource();
        } 

        private UIToolbar CreateToolbar()
        {
            var toolbar = new UIToolbar(new CGRect(0, 0, 320, 44));

            var done = new UIBarButtonItem("OK", UIBarButtonItemStyle.Bordered, (sender, e) =>
            {
                fromCityTextField.ResignFirstResponder();
                toCityTextField.ResignFirstResponder();
                depatureTimeTextField.ResignFirstResponder();
            })
            {
                TintColor = MyTrainsColors.AccentColor
            };

            toolbar.SetItems(new[] { done }, false);

            return toolbar;
        }

        protected void UpdateUi()
        {
            var calendar = CalendarHelper.GetPreconfiguredInstance(
                new CGRect(0, 0, View.Frame.Width-32, 273),
                date => SearchJourneyViewModel.SelectedDate = date);

            calendarContainerView.AddSubview(calendar);
            calendarContainerView.Layer.BorderWidth = 1;
            calendarContainerView.Layer.BorderColor = MyTrainsColors.BorderColor.CGColor;
            calendarContainerView.Layer.CornerRadius = 4;

            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                fromCityTextField.ResignFirstResponder();
                toCityTextField.ResignFirstResponder();
                depatureTimeTextField.ResignFirstResponder();
            }));
        }
    }
}