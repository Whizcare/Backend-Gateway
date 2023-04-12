using System;
using df=Audit_DataEntites.Entity;
using M=Audit_Models;
namespace Audit_BusinessLogic
{
	public static class Mapper
	{
		public static df.AuditDatum AuditMapper(M.Audit_Data audit)
		{
			return new df.AuditDatum
			{
				Id = audit.Id,
				PatientnameFirstName = audit.PatientnameFirstName,
				PatientnameLastName = audit.PatientnameLastName,
				PatientEmail =audit.PatientEmail,
				Date = audit.Date,
				DoctorName = audit.DoctorName,
                Dignosis = audit.Dignosis,
				Height = audit.Height,
				Weight = audit.Weight,
				Temperature = audit.Temperature,
				Spo2 = audit.Spo2,
				BloodPressure = audit.BloodPressure,
				SugarLevel = audit.SugarLevel,
				AdditioanlDetails = audit.AdditioanlDetails,
				Allergies = audit.Allergies,
				
			};
		}
		public static M.Audit_Data AuditMapper(df.AuditDatum audit)
		{
			return new M.Audit_Data
			{
				Id = audit.Id,
				PatientnameFirstName = audit.PatientnameFirstName,
				PatientnameLastName = audit.PatientnameLastName,
				PatientEmail = audit.PatientEmail,
				Date = audit.Date,
				DoctorName = audit.DoctorName,
                Dignosis = audit.Dignosis,
				Height = audit.Height,
				Weight = audit.Weight,
				Temperature = audit.Temperature,
				Spo2 = audit.Spo2,
				BloodPressure = audit.BloodPressure,
				SugarLevel = audit.SugarLevel,
				AdditioanlDetails = audit.AdditioanlDetails,
				Allergies = audit.Allergies,
				
			};
		}
		

    }
}

