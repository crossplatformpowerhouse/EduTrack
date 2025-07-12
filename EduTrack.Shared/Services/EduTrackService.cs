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

		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			try
			{
				using var connection = new SqlConnection(_connectionString);
				await connection.OpenAsync();
				return await connection.QueryAsync<User>(
					"spGetUsers",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<CourseType>(
					"spGetCourseTypes",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<Course>(
					"spGetCourses",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<Subject>(
					"spGetSubjects",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<AssignmentType>(
					"spGetAssignmentTypes",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<ExamType>(
					"spGetExamTypes",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<Assignment>(
					"spGetAssignments",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<Grade>(
					"spGetGrades",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<Account>(
					"spGetAccounts",
					commandType: CommandType.StoredProcedure);
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
				return await connection.QueryAsync<About>(
					"spGetAbouts",
					commandType: CommandType.StoredProcedure);
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
	}
}
