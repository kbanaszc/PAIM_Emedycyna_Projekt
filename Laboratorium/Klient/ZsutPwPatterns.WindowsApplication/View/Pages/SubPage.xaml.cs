//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WindowsApplication.View
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Runtime.InteropServices.WindowsRuntime;

  using System.ComponentModel;

  using Windows.Foundation;
  using Windows.Foundation.Collections;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;
  using Windows.UI.Xaml.Controls.Primitives;
  using Windows.UI.Xaml.Data;
  using Windows.UI.Xaml.Input;
  using Windows.UI.Xaml.Media;
  using Windows.UI.Xaml.Navigation;

  using ZsutPw.Patterns.WindowsApplication.Controller;
  using ZsutPw.Patterns.WindowsApplication.Model;
  using ZsutPw.Patterns.WindowsApplication.Utilities;

  public sealed partial class SubPage : Page
  {
    public IData Model { get; private set; }

    public IController Controller { get; private set; }

    public SubPage( )
    {
      this.InitializeComponent( );

      IEventDispatcher dispatcher = new EventDispatcher( ) as IEventDispatcher;

      this.Controller = ControllerFactory.GetController( dispatcher );

      this.Model = this.Controller.Model as IData;

      this.DataContext = this.Controller;
    }
  }
}
