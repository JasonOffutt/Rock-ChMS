﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;

namespace Rock.SystemGuid
{
    /// <summary>
    /// Static Guids used by the Rock ChMS application
    /// </summary>
    public static class DefinedType
    {
        public static Guid PERSON_RECORD_TYPE { get { return new Guid( "26be73a6-a9c5-4e94-ae00-3afdcf8c9275" ); } }
        public static Guid PERSON_RECORD_STATUS { get { return new Guid( "8522badd-2871-45a5-81dd-c76da07e2e7e" ); } }
        public static Guid PERSON_RECORD_STATUS_REASON { get { return new Guid( "e17d5988-0372-4792-82cf-9e37c79f7319" ); } }
        public static Guid PERSON_STATUS { get { return new Guid( "2e6540ea-63f0-40fe-be50-f2a84735e600" ); } }
        public static Guid PERSON_TITLE { get { return new Guid( "4784cd23-518b-43ee-9b97-225bf6e07846" ); } }
        public static Guid PERSON_SUFFIX { get { return new Guid( "16f85b3c-b3e8-434c-9094-f3d41f87a740" ); } }
        public static Guid PERSON_MARITAL_STATUS { get { return new Guid( "b4b92c3f-a935-40e1-a00b-ba484ead613b" ); } }
    }
}