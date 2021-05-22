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

namespace ZsutPw.Patterns.WindowsApplication.Utilities
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Windows.ApplicationModel.Core;
  using Windows.UI.Core;

  public class EventDispatcher : IEventDispatcher
  {
    #region IEventDispatcher

    public async void Dispatch( Action eventAction )
    {
      DispatchedHandler dispatchedHandler = ( ) => eventAction( );

      CoreDispatcher dispatcher = this.GetCoreDispatcher( );

      await dispatcher.RunAsync( CoreDispatcherPriority.Normal, dispatchedHandler );
    }

    public void Dispatch2( Action eventAction )
    {
      DispatchedHandler dispatchedHandler = ( ) => eventAction( );

      CoreDispatcher dispatcher = this.GetCoreDispatcher( );

      Action action = async ( ) => await dispatcher.RunAsync( CoreDispatcherPriority.Normal, dispatchedHandler );

      Task.Run( action );
    }
    #endregion

    private CoreDispatcher GetCoreDispatcher( )
    {
      return CoreApplication.MainView.CoreWindow.Dispatcher;
    }
  }
}
