﻿#pragma checksum "..\..\..\TankManageWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72437914C859ACBCF59119A32AB6339FF84FA2FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FengShuiKoi;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FengShuiKoi {
    
    
    /// <summary>
    /// TankManageWindow
    /// </summary>
    public partial class TankManageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 91 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturn;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTankID;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtShape;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboElement;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSearchElement;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTankData;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\TankManageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FengShuiKoi;V1.0.0.0;component/tankmanagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TankManageWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\TankManageWindow.xaml"
            ((FengShuiKoi.TankManageWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\TankManageWindow.xaml"
            this.btnReturn.Click += new System.Windows.RoutedEventHandler(this.btnReturn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTankID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtShape = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cboElement = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cboSearchElement = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 183 "..\..\..\TankManageWindow.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dgTankData = ((System.Windows.Controls.DataGrid)(target));
            
            #line 196 "..\..\..\TankManageWindow.xaml"
            this.dgTankData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgAdData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 223 "..\..\..\TankManageWindow.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 230 "..\..\..\TankManageWindow.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 237 "..\..\..\TankManageWindow.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 244 "..\..\..\TankManageWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

