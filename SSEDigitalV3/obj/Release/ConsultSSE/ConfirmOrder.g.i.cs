﻿#pragma checksum "..\..\..\ConsultSSE\confirmOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "53C248773F6BFB0DA330BCA84FD49FE0E94FB3A19F3718E33D1B40DA6276BD8A"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SSEDigitalV3.ConsultSSE;
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


namespace SSEDigitalV3.ConsultSSE {
    
    
    /// <summary>
    /// confirmOrder
    /// </summary>
    public partial class confirmOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\ConsultSSE\confirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ordemTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ConsultSSE\confirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pathTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\ConsultSSE\confirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button getPathButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\ConsultSSE\confirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertPOButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ConsultSSE\confirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button helpButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SSEDigitalV3;component/consultsse/confirmorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ConsultSSE\confirmOrder.xaml"
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
            this.ordemTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.pathTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.getPathButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\ConsultSSE\confirmOrder.xaml"
            this.getPathButton.Click += new System.Windows.RoutedEventHandler(this.getPathButton_onClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.insertPOButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\ConsultSSE\confirmOrder.xaml"
            this.insertPOButton.Click += new System.Windows.RoutedEventHandler(this.insertPOButton_onClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.helpButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\ConsultSSE\confirmOrder.xaml"
            this.helpButton.Click += new System.Windows.RoutedEventHandler(this.helpButton_onClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

