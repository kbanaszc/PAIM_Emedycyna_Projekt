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

namespace ZsutPw.Patterns.WindowsApplication.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Windows.UI.Xaml.Data;

  public class ApplicationStateConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      ApplicationState applicationState = (ApplicationState)value;

      string applicationStateName = applicationState.ToString( );

      return applicationStateName;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      string applicationStateName = (string)value;

      ApplicationState applicationState = (ApplicationState)Enum.Parse( typeof( ApplicationState ), applicationStateName );

      return applicationState;
    }
  }
}
