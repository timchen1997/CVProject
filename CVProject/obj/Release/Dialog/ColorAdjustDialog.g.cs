﻿#pragma checksum "..\..\..\Dialog\ColorAdjustDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E920F47B0A0E5D87DFEF19C3ADBA112A390D556B"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using CVProject.Dialog;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace CVProject.Dialog {
    
    
    /// <summary>
    /// ColorAdjustDialog
    /// </summary>
    public partial class ColorAdjustDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider HSlider;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DecimalUpDown Hue;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SSlider;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DecimalUpDown Saturation;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider LSlider;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DecimalUpDown Lightness;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Dialog\ColorAdjustDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CVProject;component/dialog/coloradjustdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dialog\ColorAdjustDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 2:
            this.Hue = ((Xceed.Wpf.Toolkit.DecimalUpDown)(target));
            
            #line 28 "..\..\..\Dialog\ColorAdjustDialog.xaml"
            this.Hue.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 4:
            this.Saturation = ((Xceed.Wpf.Toolkit.DecimalUpDown)(target));
            
            #line 31 "..\..\..\Dialog\ColorAdjustDialog.xaml"
            this.Saturation.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 6:
            this.Lightness = ((Xceed.Wpf.Toolkit.DecimalUpDown)(target));
            
            #line 34 "..\..\..\Dialog\ColorAdjustDialog.xaml"
            this.Lightness.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Dialog\ColorAdjustDialog.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
