﻿#pragma checksum "..\..\..\Dialog\ContrastDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3DAA2C7F8ACDEEC28A042E7F30808710D43DE81C"
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
using InteractiveDataDisplay.WPF;
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
    /// ContrastDialog
    /// </summary>
    public partial class ContrastDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtnLinear;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtnLog;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtnExp;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gboxLinear;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InteractiveDataDisplay.WPF.Chart plotter;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid lines;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RangeSlider HSlider;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RangeSlider VSlider;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown x1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown x2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown y1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy1;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown y2;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy2;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gboxLog;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown logV;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1_Copy;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gboxExp;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1_Copy1;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown expV;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1_Copy2;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtnBal;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox1_Copy1;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Dialog\ContrastDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/CVProject;component/dialog/contrastdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dialog\ContrastDialog.xaml"
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
            this.rbtnLinear = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\..\Dialog\ContrastDialog.xaml"
            this.rbtnLinear.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rbtnLog = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\..\Dialog\ContrastDialog.xaml"
            this.rbtnLog.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbtnExp = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\..\Dialog\ContrastDialog.xaml"
            this.rbtnExp.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gboxLinear = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 5:
            this.plotter = ((InteractiveDataDisplay.WPF.Chart)(target));
            return;
            case 6:
            this.lines = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.HSlider = ((Xceed.Wpf.Toolkit.RangeSlider)(target));
            return;
            case 8:
            this.VSlider = ((Xceed.Wpf.Toolkit.RangeSlider)(target));
            return;
            case 9:
            this.x1 = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            
            #line 33 "..\..\..\Dialog\ContrastDialog.xaml"
            this.x1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.x2 = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            
            #line 35 "..\..\..\Dialog\ContrastDialog.xaml"
            this.x2.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.label_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.y1 = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            
            #line 37 "..\..\..\Dialog\ContrastDialog.xaml"
            this.y1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.label_Copy1 = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.y2 = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            
            #line 39 "..\..\..\Dialog\ContrastDialog.xaml"
            this.y2.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.label_Copy2 = ((System.Windows.Controls.Label)(target));
            return;
            case 17:
            this.gboxLog = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 18:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.logV = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            
            #line 46 "..\..\..\Dialog\ContrastDialog.xaml"
            this.logV.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 20:
            this.label1_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 21:
            this.gboxExp = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 22:
            this.label1_Copy1 = ((System.Windows.Controls.Label)(target));
            return;
            case 23:
            this.expV = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            
            #line 53 "..\..\..\Dialog\ContrastDialog.xaml"
            this.expV.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 24:
            this.label1_Copy2 = ((System.Windows.Controls.Label)(target));
            return;
            case 25:
            this.rbtnBal = ((System.Windows.Controls.RadioButton)(target));
            
            #line 58 "..\..\..\Dialog\ContrastDialog.xaml"
            this.rbtnBal.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 26:
            this.groupBox1_Copy1 = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 27:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\Dialog\ContrastDialog.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Dialog\ContrastDialog.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

