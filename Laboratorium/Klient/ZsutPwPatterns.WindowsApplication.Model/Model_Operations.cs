﻿//===============================================================================
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

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IOperations
  {
    public void LoadNodeList( )
    {
      /* AT
      this.LoadNodesTask( );
      */
      Task.Run( ( ) => this.LoadNodesTask( ) );
    }

    private void LoadNodesTask( )
    {
      INetwork networkClient = NetworkClientFactory.GetNetworkClient( );

      try
      {
        NodeData[ ] nodes = networkClient.GetNodes( this.SearchText );

        this.NodeList = nodes.ToList( );
      }
      catch( Exception )
      {
      }
    }
  }
}
