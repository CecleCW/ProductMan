/////////////////////////////////////////////////////////////////////////////
//
// (c) 2007 BinaryComponents Ltd.  All Rights Reserved.
//
// http://www.binarycomponents.com/
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryComponents.WinFormsUtility.Commands
{
	public interface ICommandControl
	{
		Command Command
		{
			get;
		}

		CommandControlSet CommandControlSet
		{
			get;
			set;
		}

		void UpdateState();
	}
}
