using Dapper;
using EduTrack.Shared.Modules;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

		// Read methods (unchanged)
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

		public async Task<IEnumerable<AssignmentType>> GetAssignmentTypesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<AssignmentType>("spGetAssignmentTypes", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching assignment types: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<ExamType>> GetExamTypesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<ExamType>("spGetExamTypes", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching exam types: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Assignment>> GetAssignmentsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Assignment>("spGetAssignments", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching assignments: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Grade>> GetGradesAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Grade>("spGetGrades", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching grades: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<Account>> GetAccountsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<Account>("spGetAccounts", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching accounts: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<About>> GetAboutsAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<About>("spGetAbouts", commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching abouts: {ex.Message}");
				throw;
			}
		}

		public async Task<IEnumerable<StudentDetailsDto>> GetStudentDetailsAsync(int userId)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<StudentDetailsDto>(
					"spGetStudentDetails",
					new { UserId = userId },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching student details: {ex.Message}");
				throw;
			}
		}

		// Create methods
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
						user.Username,
						user.PasswordHash,
						user.Email,
						user.FirstName,
						user.LastName,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding user: {ex.Message}");
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
						courseType.Name,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
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
						course.UserId,
						course.CourseTypeId,
						course.Name,
						course.DurationYears,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding course: {ex.Message}");
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
						subject.UserId,
						subject.CourseId,
						subject.Name,
						subject.AcademicYear,
						subject.PassMark,
						subject.ClassTestWeight,
						subject.SemesterTestWeight,
						subject.ClassAssignmentWeight,
						subject.SemesterAssignmentWeight,
						subject.ExamWeight,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding subject: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddAssignmentTypeAsync(AssignmentType assignmentType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddAssignmentType",
					new
					{
						assignmentType.Name,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding assignment type: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddExamTypeAsync(ExamType examType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddExamType",
					new
					{
						examType.Name,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding exam type: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddAssignmentAsync(Assignment assignment)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddAssignment",
					new
					{
						assignment.UserId,
						assignment.SubjectId,
						assignment.AssignmentTypeId,
						assignment.ExamTypeId,
						assignment.Title,
						assignment.Deadline,
						assignment.Semester,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding assignment: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddGradeAsync(Grade grade)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddGrade",
					new
					{
						grade.UserId,
						grade.AssignmentId,
						grade.GradeValue,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding grade: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddAccountAsync(Account account)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddAccount",
					new
					{
						account.UserId,
						account.ReceiveEmailNotifications,
						account.ReceivePushNotifications,
						account.ThemePreference,
						account.LastLogin,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding account: {ex.Message}");
				throw;
			}
		}

		public async Task<int> AddAboutAsync(About about)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.ExecuteScalarAsync<int>(
					"spAddAbout",
					new
					{
						about.UserId,
						about.Bio,
						about.AppVersion,
						about.LastUpdated,
						CreatedBy = "System",
						CreatedDate = DateTime.Now,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding about: {ex.Message}");
				throw;
			}
		}

		// Update methods
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
						user.Username,
						user.PasswordHash,
						user.Email,
						user.FirstName,
						user.LastName,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating user: {ex.Message}");
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
						courseType.Name,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
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
						course.UserId,
						course.CourseTypeId,
						course.Name,
						course.DurationYears,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating course: {ex.Message}");
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
						subject.UserId,
						subject.CourseId,
						subject.Name,
						subject.AcademicYear,
						subject.PassMark,
						subject.ClassTestWeight,
						subject.SemesterTestWeight,
						subject.ClassAssignmentWeight,
						subject.SemesterAssignmentWeight,
						subject.ExamWeight,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating subject: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateAssignmentTypeAsync(AssignmentType assignmentType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateAssignmentType",
					new
					{
						assignmentType.Id,
						assignmentType.Name,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating assignment type: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateExamTypeAsync(ExamType examType)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateExamType",
					new
					{
						examType.Id,
						examType.Name,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating exam type: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateAssignmentAsync(Assignment assignment)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateAssignment",
					new
					{
						assignment.Id,
						assignment.UserId,
						assignment.SubjectId,
						assignment.AssignmentTypeId,
						assignment.ExamTypeId,
						assignment.Title,
						assignment.Deadline,
						assignment.Semester,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating assignment: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateGradeAsync(Grade grade)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateGrade",
					new
					{
						grade.Id,
						grade.UserId,
						grade.AssignmentId,
						grade.GradeValue,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating grade: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateAccountAsync(Account account)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateAccount",
					new
					{
						account.Id,
						account.UserId,
						account.ReceiveEmailNotifications,
						account.ReceivePushNotifications,
						account.ThemePreference,
						account.LastLogin,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating account: {ex.Message}");
				throw;
			}
		}

		public async Task UpdateAboutAsync(About about)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spUpdateAbout",
					new
					{
						about.Id,
						about.UserId,
						about.Bio,
						about.AppVersion,
						about.LastUpdated,
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating about: {ex.Message}");
				throw;
			}
		}

		// Delete methods
		public async Task DeleteUserAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteUser",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting user: {ex.Message}");
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
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
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
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting course: {ex.Message}");
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
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting subject: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteAssignmentTypeAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteAssignmentType",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting assignment type: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteExamTypeAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteExamType",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting exam type: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteAssignmentAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteAssignment",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting assignment: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteGradeAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteGrade",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting grade: {ex.Message}");
				throw;
			}
		}

		public async Task DeleteAccountAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteAccount",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting grade: {ex.Message}");
				throw;
			}

		}

		public async Task DeleteAboutAsync(int id)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				await connection.ExecuteAsync(
					"spDeleteAbout",
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting grade: {ex.Message}");
				throw;
			}

		}

		// New Notification methods
		public async Task<IEnumerable<Notification>> GetNotificationsAsync(int userId)
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				var accounts = await connection.QueryAsync<Account>("spGetAccounts", commandType: CommandType.StoredProcedure);
				var account = accounts.FirstOrDefault(a => a.UserId == userId);
				if (account == null || !account.ReceivePushNotifications)
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
						CreatedDate = DateTime.Now,
						CreatedBy = "System",
						LastModifiedBy = "System",
						LastModifiedDate = DateTime.Now
					},
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding notification: {ex.Message}");
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
					new { Id = id, LastModifiedBy = "System", LastModifiedDate = DateTime.Now },
					commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting notification: {ex.Message}");
				throw;
			}
		}
	}
}
