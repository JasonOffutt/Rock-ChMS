//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;

namespace Rock.Util.DTO
{
    /// <summary>
    /// Job Data Transfer Object.
    /// </summary>
	/// <remarks>
	/// Data Transfer Objects are a lightweight version of the Entity object that are used
	/// in situations like serializing the object in the REST api
	/// </remarks>
    public partial class Job
    {
        /// <summary>
        /// The Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        /// <value>
        /// The GUID.
        /// </value>
        public Guid Guid { get; set; }

		/// <summary>
		/// Gets or sets the System.
		/// </summary>
		/// <value>
		/// Determines whether the job is a system job..
		/// </value>
		public bool? System { get; set; }

		/// <summary>
		/// Gets or sets the Active.
		/// </summary>
		/// <value>
		/// Determines is the job is currently active..
		/// </value>
		public bool? Active { get; set; }

		/// <summary>
		/// Gets or sets the Name.
		/// </summary>
		/// <value>
		/// Friendly name for the job..
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the Description.
		/// </summary>
		/// <value>
		/// Notes about the job..
		/// </value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the Assemby.
		/// </summary>
		/// <value>
		/// Assembly (.dll) that contains the job class..
		/// </value>
		public string Assemby { get; set; }

		/// <summary>
		/// Gets or sets the Class.
		/// </summary>
		/// <value>
		/// The class name of the job to run..
		/// </value>
		public string Class { get; set; }

		/// <summary>
		/// Gets or sets the Cron Expression.
		/// </summary>
		/// <value>
		/// The cron expression that is used to determine the schedule of the job (see http://www.quartz-scheduler.org/documentation/quartz-1.x/tutorials/crontrigger for syntax.).
		/// </value>
		public string CronExpression { get; set; }

		/// <summary>
		/// Gets or sets the Last Successful Run.
		/// </summary>
		/// <value>
		/// Date and time the job last completed successfully..
		/// </value>
		public DateTime? LastSuccessfulRun { get; set; }

		/// <summary>
		/// Gets or sets the Last Run Date.
		/// </summary>
		/// <value>
		/// Last date and time the job attempted to run..
		/// </value>
		public DateTime? LastRunDate { get; set; }

		/// <summary>
		/// Gets or sets the Last Run Duration.
		/// </summary>
		/// <value>
		/// Number of seconds that the last job took to finish..
		/// </value>
		public int? LastRunDuration { get; set; }

		/// <summary>
		/// Gets or sets the Last Status.
		/// </summary>
		/// <value>
		/// The completion status from the last time the job was run (valid values 'Success', 'Exception', 'Error Loading Job')..
		/// </value>
		public string LastStatus { get; set; }

		/// <summary>
		/// Gets or sets the Last Status Message.
		/// </summary>
		/// <value>
		/// Message from the last run.  Usually used to store the exception message..
		/// </value>
		public string LastStatusMessage { get; set; }

		/// <summary>
		/// Gets or sets the Last Run Scheduler Name.
		/// </summary>
		/// <value>
		/// Name of the scheduler that the job ran under.  This is used to determine if a job ran in IIS or the Windows service..
		/// </value>
		public string LastRunSchedulerName { get; set; }

		/// <summary>
		/// Gets or sets the Notification Emails.
		/// </summary>
		/// <value>
		/// Email addresses (separated with commas) to be used for notification..
		/// </value>
		public string NotificationEmails { get; set; }

		/// <summary>
		/// Gets or sets the Notification Status.
		/// </summary>
		/// <value>
		/// States that should be used to determine when to notify (valid values = All = 1, Success = 2, Error = 3, None = 4  Enum[JobNotificationStatus].
		/// </value>
		public int NotificationStatus { get; set; }

		/// <summary>
		/// Gets or sets the Created Date Time.
		/// </summary>
		/// <value>
		/// Created Date Time.
		/// </value>
		public DateTime? CreatedDateTime { get; set; }

		/// <summary>
		/// Gets or sets the Modified Date Time.
		/// </summary>
		/// <value>
		/// Modified Date Time.
		/// </value>
		public DateTime? ModifiedDateTime { get; set; }

		/// <summary>
		/// Gets or sets the Created By Person Id.
		/// </summary>
		/// <value>
		/// Created By Person Id.
		/// </value>
		public int? CreatedByPersonId { get; set; }

		/// <summary>
		/// Gets or sets the Modified By Person Id.
		/// </summary>
		/// <value>
		/// Modified By Person Id.
		/// </value>
		public int? ModifiedByPersonId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobDTO"/> class.
        /// </summary>
		public Job()
		{
		}
	}
}
