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

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  using ZsutPw.Patterns.WindowsApplication.Utilities;

  public partial class Model : PropertyContainerBase, IModel
  {
    public Model( IEventDispatcher dispatcher ) : base( dispatcher )
    {
    }
  }
}
