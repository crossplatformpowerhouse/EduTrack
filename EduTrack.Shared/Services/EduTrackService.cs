using Dapper;
using EduTrack.Shared.Models;
using EduTrack.Shared.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EduTrack.Shared.Services
{
	public class EduTrackService : IEduTrackService
	{
		private readonly string _connectionString;

		public EduTrackService(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("EduTrackDb")
				?? throw new ArgumentNullException(nameof(configuration), "Connection string 'EduTrackDb' not found.");
		}

		// Read methods
		public async Task<IEnumerable<UserType>> GetUserTypesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<UserType>("spGetUserTypes", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching user types: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<SchoolType>> GetSchoolTypesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<SchoolType>("spGetSchoolTypes", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching school types: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<School>> GetSchoolsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<School>("spGetSchools", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching schools: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<CourseType>> GetCourseTypesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<CourseType>("spGetCourseTypes", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching course types: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Course>> GetCoursesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Course>("spGetCourses", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching courses: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<User>("spGetUsers", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching users: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Subject>> GetSubjectsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Subject>("spGetSubjects", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching subjects: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Assessment>> GetAssessmentsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Assessment>("spGetAssessments", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching assessments: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Result>> GetResultsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Result>("spGetResults", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching results: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Notification>> GetNotificationsAsync(int userId)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				var users = await connection.QueryAsync<User>("spGetUsers", commandType: CommandType.StoredProcedure);
				var user = users.FirstOrDefault(u => u.Id == userId);
				if (user == null || !user.ReceivePushNotifications)
				{
					return new List<Notification>();
				}
				return await connection.QueryAsync<Notification>(
					"spGetNotifications",
					new { UserId = userId },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching notifications: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<StudentResultDto>> GetStudentResultsAsync(int userId)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<StudentResultDto>(
					"spGetStudentResults",
					new { UserId = userId },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching student results: {ex.Message}");
				throw;
			}
		}

		// Create methods
		public async Task<int> AddUserTypeAsync(UserType userType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddUserType",
					new
					{
						userType.Description,
						userType.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding user type: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddSchoolTypeAsync(SchoolType schoolType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddSchoolType",
					new
					{
						schoolType.Description,
						schoolType.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding school type: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddSchoolAsync(School school)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddSchool",
					new
					{
						school.EMISNumber,
						school.Description,
						school.SchoolTypeId,
						school.Phase,
						school.Level,
						school.Country,
						school.Province,
						school.District,
						school.Circuit,
						school.Municipality,
						school.UrbanRural,
						school.AddressLine1,
						school.AddressLine2,
						school.TownCity,
						school.PostalCode,
						school.PhoneNumber,
						school.Email,
						school.Latitude,
						school.Longitude,
						school.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding school: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddCourseTypeAsync(CourseType courseType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddCourseType",
					new
					{
						courseType.Code,
						courseType.Description,
						courseType.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding course type: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddCourseAsync(Course course)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddCourse",
					new
					{
						course.CourseTypeId,
						course.Code,
						course.Description,
						course.Duration,
						course.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding course: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddUserAsync(User user)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddUser",
					new
					{
						user.UserTypeId,
						user.SchoolId,
						user.CourseId,
						user.Username,
						user.FirstName,
						user.LastName,
						user.PasswordHash,
						user.Email,
						user.Cellphone,
						user.ReceiveEmailNotifications,
						user.ReceivePushNotifications,
						user.ThemePreference,
						user.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding user: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddSubjectAsync(Subject subject)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddSubject",
					new
					{
						subject.CourseId,
						subject.Code,
						subject.Description,
						subject.AcademicYear,
						subject.PassMark,
						subject.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding subject: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddAssessmentAsync(Assessment assessment)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddAssessment",
					new
					{
						assessment.SubjectId,
						assessment.Code,
						assessment.Description,
						assessment.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding assessment: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddResultAsync(Result result)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddResult",
					new
					{
						result.UserId,
						result.CourseId,
						result.SubjectId,
						result.AssessmentId,
						result.Mark,
						result.FinalMark,
						result.Predicate,
						result.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding result: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddNotificationAsync(Notification notification)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddNotification",
					new
					{
						notification.UserId,
						notification.Message,
						notification.NotificationType,
						notification.IsRead,
						notification.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding notification: {ex.Message}");
				throw;
			}
		}

		// Update methods
		public async Task UpdateUserTypeAsync(UserType userType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateUserType",
					new
					{
						userType.Id,
						userType.Description,
						userType.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating user type: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateSchoolTypeAsync(SchoolType schoolType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateSchoolType",
					new
					{
						schoolType.Id,
						schoolType.Description,
						schoolType.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating school type: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateSchoolAsync(School school)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateSchool",
					new
					{
						school.Id,
						school.EMISNumber,
						school.Description,
						school.SchoolTypeId,
						school.Phase,
						school.Level,
						school.Country,
						school.Province,
						school.District,
						school.Circuit,
						school.Municipality,
						school.UrbanRural,
						school.AddressLine1,
						school.AddressLine2,
						school.TownCity,
						school.PostalCode,
						school.PhoneNumber,
						school.Email,
						school.Latitude,
						school.Longitude,
						school.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating school: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateCourseTypeAsync(CourseType courseType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateCourseType",
					new
					{
						courseType.Id,
						courseType.Code,
						courseType.Description,
						courseType.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating course type: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateCourseAsync(Course course)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateCourse",
					new
					{
						course.Id,
						course.CourseTypeId,
						course.Code,
						course.Description,
						course.Duration,
						course.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating course: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateUserAsync(User user)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateUser",
					new
					{
						user.Id,
						user.UserTypeId,
						user.SchoolId,
						user.CourseId,
						user.Username,
						user.FirstName,
						user.LastName,
						user.PasswordHash,
						user.Email,
						user.Cellphone,
						user.ReceiveEmailNotifications,
						user.ReceivePushNotifications,
						user.ThemePreference,
						user.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating user: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateSubjectAsync(Subject subject)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateSubject",
					new
					{
						subject.Id,
						subject.CourseId,
						subject.Code,
						subject.Description,
						subject.AcademicYear,
						subject.PassMark,
						subject.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating subject: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateAssessmentAsync(Assessment assessment)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateAssessment",
					new
					{
						assessment.Id,
						assessment.SubjectId,
						assessment.Code,
						assessment.Description,
						assessment.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating assessment: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateResultAsync(Result result)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateResult",
					new
					{
						result.Id,
						result.UserId,
						result.CourseId,
						result.SubjectId,
						result.AssessmentId,
						result.Mark,
						result.FinalMark,
						result.Predicate,
						result.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating result: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateNotificationAsync(Notification notification)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateNotification",
					new
					{
						notification.Id,
						notification.UserId,
						notification.Message,
						notification.NotificationType,
						notification.IsRead,
						notification.LastModifiedBy
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating notification: {ex.Message}");
				throw;
			}
		}

		// Delete methods
		public async Task DeleteUserTypeAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteUserType",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting user type: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteSchoolTypeAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteSchoolType",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting school type: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteSchoolAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteSchool",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting school: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteCourseTypeAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteCourseType",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting course type: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteCourseAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteCourse",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting course: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteUserAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteUser",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting user: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteSubjectAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteSubject",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting subject: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteAssessmentAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteAssessment",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting assessment: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteResultAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteResult",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting result: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteNotificationAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteNotification",
					new { Id = id },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting notification: {ex.Message}");
				throw;
			}
		}

		// New methods for tAbout
		public async Task<IEnumerable<About>> GetAboutsAsync()
		{
			using var connection = new SqlConnection(_connectionString);
			return await connection.QueryAsync<About>("spGetAbouts", commandType: CommandType.StoredProcedure);
		}

		public async Task AddAboutAsync(About about)
		{
			using var connection = new SqlConnection(_connectionString);
			var parameters = new
			{
				about.UserId,
				about.Bio,
				about.AppVersion,
				about.LastUpdated,
				about.LastModifiedBy
			};
			await connection.ExecuteAsync("spAddAbout", parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task UpdateAboutAsync(About about)
		{
			using var connection = new SqlConnection(_connectionString);
			var parameters = new
			{
				about.Id,
				about.UserId,
				about.Bio,
				about.AppVersion,
				about.LastUpdated,
				about.LastModifiedBy
			};
			await connection.ExecuteAsync("spUpdateAbout", parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task DeleteAboutAsync(int id)
		{
			using var connection = new SqlConnection(_connectionString);
			await connection.ExecuteAsync("spDeleteAbout", new { Id = id }, commandType: CommandType.StoredProcedure);
		}

		// New methods for tAccount
		public async Task<IEnumerable<Account>> GetAccountsAsync()
		{
			using var connection = new SqlConnection(_connectionString);
			return await connection.QueryAsync<Account>("spGetAccounts", commandType: CommandType.StoredProcedure);
		}

		public async Task AddAccountAsync(Account account)
		{
			using var connection = new SqlConnection(_connectionString);
			var parameters = new
			{
				account.UserId,
				account.ReceiveEmailNotifications,
				account.ReceivePushNotifications,
				account.LastLogin,
				account.LastModifiedBy
			};
			await connection.ExecuteAsync("spAddAccount", parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task UpdateAccountAsync(Account account)
		{
			using var connection = new SqlConnection(_connectionString);
			var parameters = new
			{
				account.Id,
				account.UserId,
				account.ReceiveEmailNotifications,
				account.ReceivePushNotifications,
				account.LastLogin,
				account.LastModifiedBy
			};
			await connection.ExecuteAsync("spUpdateAccount", parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task DeleteAccountAsync(int id)
		{
			using var connection = new SqlConnection(_connectionString);
			await connection.ExecuteAsync("spDeleteAccount", new { Id = id }, commandType: CommandType.StoredProcedure);
		}
	}
}