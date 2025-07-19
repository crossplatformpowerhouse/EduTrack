
using EduTrack.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTrack.Shared.Services
{
	public interface IEduTrackService
	{
		// Read methods
		Task<IEnumerable<UserType>> GetUserTypesAsync();
		Task<IEnumerable<SchoolType>> GetSchoolTypesAsync();
		Task<IEnumerable<School>> GetSchoolsAsync();
		Task<IEnumerable<CourseType>> GetCourseTypesAsync();
		Task<IEnumerable<Course>> GetCoursesAsync();
		Task<IEnumerable<User>> GetUsersAsync();
		Task<IEnumerable<Subject>> GetSubjectsAsync();
		Task<IEnumerable<Assessment>> GetAssessmentsAsync();
		Task<IEnumerable<Result>> GetResultsAsync();
		Task<IEnumerable<Notification>> GetNotificationsAsync(int userId);
		Task<IEnumerable<StudentResultDto>> GetStudentResultsAsync(int userId);
		Task<IEnumerable<About>> GetAboutsAsync();
		Task<IEnumerable<Account>> GetAccountsAsync();

		// Create methods
		Task<int> AddUserTypeAsync(UserType userType);
		Task<int> AddSchoolTypeAsync(SchoolType schoolType);
		Task<int> AddSchoolAsync(School school);
		Task<int> AddCourseTypeAsync(CourseType courseType);
		Task<int> AddCourseAsync(Course course);
		Task<int> AddUserAsync(User user);
		Task<int> AddSubjectAsync(Subject subject);
		Task<int> AddAssessmentAsync(Assessment assessment);
		Task<int> AddResultAsync(Result result);
		Task<int> AddNotificationAsync(Notification notification);
		Task AddAboutAsync(About about);
		Task AddAccountAsync(Account account);

		// Update methods
		Task UpdateUserTypeAsync(UserType userType);
		Task UpdateSchoolTypeAsync(SchoolType schoolType);
		Task UpdateSchoolAsync(School school);
		Task UpdateCourseTypeAsync(CourseType courseType);
		Task UpdateCourseAsync(Course course);
		Task UpdateUserAsync(User user);
		Task UpdateSubjectAsync(Subject subject);
		Task UpdateAssessmentAsync(Assessment assessment);
		Task UpdateResultAsync(Result result);
		Task UpdateNotificationAsync(Notification notification);
		Task UpdateAboutAsync(About about);
		Task UpdateAccountAsync(Account account);

		// Delete methods
		Task DeleteUserTypeAsync(int id);
		Task DeleteSchoolTypeAsync(int id);
		Task DeleteSchoolAsync(int id);
		Task DeleteCourseTypeAsync(int id);
		Task DeleteCourseAsync(int id);
		Task DeleteUserAsync(int id);
		Task DeleteSubjectAsync(int id);
		Task DeleteAssessmentAsync(int id);
		Task DeleteResultAsync(int id);
		Task DeleteNotificationAsync(int id);
		Task DeleteAboutAsync(int id);
		Task DeleteAccountAsync(int id);
	}
}