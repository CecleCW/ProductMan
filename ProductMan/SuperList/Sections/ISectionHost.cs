/////////////////////////////////////////////////////////////////////////////
//
// (c) 2007 BinaryComponents Ltd.  All Rights Reserved.
//
// http://www.binarycomponents.com/
//
/////////////////////////////////////////////////////////////////////////////

using System.Drawing;
using System.Windows.Forms;

namespace BinaryComponents.SuperList.Sections
{
	public interface ISectionHost
	{
		/// <summary>
		/// Will perform a layout when convenient.
		/// </summary>
		/// <param name="section"></param>
		void LazyLayout( Section section );

		/// <summary>
		/// Causes the section to be painted.
		/// </summary>
		/// <param name="section"></param>
		void Invalidate( Section section );

		/// <summary>
		/// Returns a graphics object.
		/// </summary>
		/// <returns></returns>
		Graphics CreateGraphics();

		/// <summary>
		/// Forces the host to process any pending layouts.
		/// </summary>
		void ProcessLayoutsNow();

		/// <summary>
		/// Returns the font for the host.
		/// </summary>
		Font Font
		{
			get;
		}

		/// <summary>
		/// Returns the text color for the host.
		/// </summary>
		Color TextColor
		{
			get;
		}

		/// <summary>
		/// Returns any object attached (tagged) to this host
		/// </summary>
		object Tag
		{
			get;
		}


		/// <summary>
		/// Returns the current (if any) section who has the mouse over it.
		/// </summary>
		Section SectionMouseOver
		{
			get;
		}

		/// <summary>
		/// Returns true if we're in a drag operation.
		/// </summary>
		bool IsInDragOperation
		{
			get;
		}

		/// <summary>
		/// Returns the section with something being dragged over it.
		/// </summary>
		Section CurrentSectionDraggedOver
		{
			get;
		}

		/// <summary>
		/// Returns the section factory for this control.
		/// </summary>
		SectionFactory SectionFactory
		{
			get;
		}

		/// <summary>
		/// Converts a client point into a screen point.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		Point PointToScreen( Point pt );

		/// <summary>
		/// Converts a screen point to client point.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		Point PointToClient( Point pt );

		/// <summary>
		/// Sets or gets the currently focused item. The focused item
		/// will receive all keyboard input.
		/// </summary>
		Section FocusedSection
		{
			get;
			set;
		}

		/// <summary>
		/// Represents the hosts control collection. Useful for attaching real windows 
		/// generated by child sections.
		/// </summary>
		Control.ControlCollection ControlCollection
		{
			get;
		}

		/// <summary>
		/// Returns true if the control is created.
		/// </summary>
		bool IsControlCreated
		{
			get;
		}

		/// <summary>
		/// Starts a drag operation on a given section.
		/// </summary>
		/// <param name="sectionToDrag"></param>
		void DoDragDropOperation( Section sectionToDrag );

		/// <summary>
		/// Grabs mouse capture for a given section
		/// </summary>
		void StartMouseCapture( Section section );

		/// <summary>
		/// Ends a mouse capture session.
		/// </summary>
		void EndMouseCapture();

		/// <summary>
		/// Returns the current section with mouse capture
		/// </summary>
		Section SectionWithMouseCapture
		{
			get;
		}

		/// <summary>
		/// Returns the section given a client point.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		Section SectionFromClientPoint( Point pt );

		/// <summary>
		/// Gets and sets the current cursor.
		/// </summary>
		Cursor Cursor
		{
			get;
			set;
		}
	}
}