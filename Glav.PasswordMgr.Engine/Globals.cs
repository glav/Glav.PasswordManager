using System;

/************************************************************************************
 * Modification History:-
 * Date        Who  CodeIDTag  Comments
 * ~~~~~~~~~~  ~~~  ~~~~~~~~~  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * 04/02/2006   PG             Initial .Net V2.0 Migration 
 * ***********************************************************************************/

//////////////////////////////////////////////////////////////////////////////////////
/// A Collection of "global" objects and types
//////////////////////////////////////////////////////////////////////////////////////
namespace Glav.PasswordMgr.Engine.Globals
{
/////////////////////////////////////////////////////////////////////////////////////
///		Global Classes
////////////////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Static class to hold data file version strings.
	/// Note: The data file version for Version1 files is implicit if there is
	/// no version information, which is typically the case.
	/// </summary>
	public class DataFileVersion
	{
		public static string VERSION1 = "!#V#100#!";
		public static string VERSION2 = "!#V#200#!";
        public static string VERSION3 = "!#V#300#!";
		
		private DataFileVersion(){}
	}

	/// <summary>
	/// Enumeration for file version constants.
	/// </summary>
	public enum FileVersions
	{
		Version1,
		Version2,
		Version3
	}
}

