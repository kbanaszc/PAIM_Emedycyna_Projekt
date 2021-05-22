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
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Windows.UI.Xaml.Data;

  using ZsutPw.Patterns.WindowsApplication.Model;

  public class NodeDataConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      NodeData nodeData = (NodeData)value;

      return String.Format( "{0} at ({1},{2})", nodeData.Id, nodeData.Position.X, nodeData.Position.Y );
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      throw new NotImplementedException( );
    }
  }
}
