﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;

namespace Rock.FieldTypes
{
    /// <summary>
    /// Field used to save and dispaly a numeric value
    /// </summary>
    public class Integer : Field
    {
        /// <summary>
        /// Tests the value to ensure that it is a valid value.  If not, message will indicate why
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public override bool IsValid( string value, out string message )
        {
            int result;

            if ( Int32.TryParse( value, out result ) )
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = "The input provided is not a valid integer.";
                return true;
            }
        }
    }
}